using E_Players_MVC.Interfaces;

namespace E_Players_MVC.Models
{
    public class Noticia : EPlayersBase, INoticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
    }
}