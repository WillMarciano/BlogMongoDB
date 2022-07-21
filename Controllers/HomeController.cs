using BlogMongoDB.Data;
using BlogMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlogMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AcessoMongoDB _repository = new AcessoMongoDB();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publicacoesRecentes = await BuscarPublicacoesRecentes();
            var model = new IndexModel(publicacoesRecentes);
            return View(model);
        }

        [HttpGet]
        public ActionResult NovaPublicacao()
        {
            return View(new NovaPublicacaoModel());
        }

        [HttpPost]
        public async Task<ActionResult> NovaPublicacao(NovaPublicacaoModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var post = new Publicacao(User.Identity.Name, model.Titulo, model.Conteudo, model.Tags);
            await _repository.Publicacoes.InsertOneAsync(post);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> Publicacao(string id)
        {
            var publicacao = await _repository.Publicacoes.Find(x => x.Id == id).SingleOrDefaultAsync();
            if (publicacao == null)
                return RedirectToAction("Index");
            var model = new PublicacaoModel(publicacao);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Publicacoes(string tag = null)
        {
            var posts = new List<Publicacao>();
            if (tag == null)
            {
                var filtro = new BsonDocument();
                posts = await _repository.Publicacoes.Find(filtro).SortByDescending(x => x.DataCriacao).Limit(10).ToListAsync();
            }
            else
            {
                posts = await _repository.Publicacoes
                    .Find(Builders<Publicacao>.Filter.AnyEq(x => x.Tags, tag))
                    .SortByDescending(x => x.DataCriacao)
                    .Limit(10)
                    .ToListAsync();
            }
            return View(posts);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        [HttpPost]
        public async Task<ActionResult> NovoComentario(NovoComentarioModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Publicacao", new { id = model.PublicacaoId });

            var comment = new Comentario(User.Identity.Name, model.Conteudo);

            var condicao = Builders<Publicacao>.Filter.Eq(x => x.Id, model.PublicacaoId);
            var condicaoAlteracao = Builders<Publicacao>.Update.Push(x => x.Comentarios, comment);
            await _repository.Publicacoes.UpdateOneAsync(condicao, condicaoAlteracao);

            return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
        }

        private async Task<List<Publicacao>> BuscarPublicacoesRecentes()
        {
            var filtro = new BsonDocument();
            var publicacoesRecentes = await _repository.Publicacoes
                .Find(filtro)
                .SortByDescending(x => x.DataCriacao)
                .Limit(10)
                .ToListAsync();
            return publicacoesRecentes;
        }
    }
}
