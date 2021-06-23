using System.Collections.Generic;
using E_Players_MVC.Models;

namespace E_Players_MVC.Interfaces
{
    public interface IEquipe
    {
         void Criar(Equipe e);
         List<Equipe> LerTodas();
         void Alterar(Equipe e);
         void Deletar(int id);
    }
}