using System;
using System.Collections.Generic;
using System.IO;
using E_Players_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_MVC.Controllers
{

    [Route("Login")]
    public class LoginController : Controller
    {

        [TempData]
        public string Mensagem { get; set; }
        Jogador jogadormodel = new Jogador();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> jogadorescsv = jogadormodel.LerTodasLinhasCSV("Database/jogador.csv");

            var logado = jogadorescsv.Find(x => x.Split(";")[3] == form["Email"] &&
            x.Split(";")[4] == form["Senha"]);

            if (logado != null)
            {
                HttpContext.Session.SetString("Usuario", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos!!! Por favor tente novamente";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Usuario");
            return LocalRedirect("~/");
        }
    }
}