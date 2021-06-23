using System.Collections.Generic;
using E_Players_MVC.Models;

namespace E_Players_MVC.Interfaces
{
    public interface IJogador
    {
        void Criar(Jogador j);
        List<Jogador> LerTodos();
        void Alterar (Jogador j);
        void Deletar (int id);
    }
}