using System;
using System.IO;
using E_Players_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_MVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadormodel = new Jogador();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.jogadores = jogadormodel.LerTodos();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha = form["Senha"];

            jogadormodel.Criar(novoJogador);
            ViewBag.jogadores = jogadormodel.LerTodos();

            return LocalRedirect("~/Jogador/Listar");
        }
    }
}