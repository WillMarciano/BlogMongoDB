namespace BlogMongoDB.Models
{
    public class PublicacaoModel
    {
        public PublicacaoModel()
        {
            NovoComentario = new NovoComentarioModel();
        }
        public PublicacaoModel(Publicacao publicacao)
        {
            Publicacao = publicacao;
            NovoComentario = new NovoComentarioModel
            {
                PublicacaoId = publicacao.Id
            };
        }

        public Publicacao Publicacao { get; private set; }

        public NovoComentarioModel NovoComentario { get; private set; }
    }
}
