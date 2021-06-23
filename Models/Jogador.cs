using System;
using System.Collections.Generic;
using System.IO;
using E_Players_MVC.Interfaces;

namespace E_Players_MVC.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public const string CAMINHO = "Database/jogador.csv";

        public Jogador()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe};{j.Email};{j.Senha}";
        }

        public void Criar(Jogador j)
        {
            string[] linha = { PrepararLinha(j) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();

                jogador.IdJogador = Int32.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.IdEquipe = Int32.Parse(linha[2]);
                jogador.Email = linha[3];
                jogador.Senha = linha[4];

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(PrepararLinha(j));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }
    }
}
