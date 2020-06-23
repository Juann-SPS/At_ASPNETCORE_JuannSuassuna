using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoPessoa.Models;
using GerenciamentoPessoa.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GerenciamentoPessoa.Controllers {
    public class PessoaController : Controller {
        private PessoaRepository PessoaRepository { get; set; }

        public PessoaController(PessoaRepository pessoaRepository) {
            this.PessoaRepository = pessoaRepository;
        }

        [Route("Pessoa/NivDia")]
        public ActionResult NivDia() {
            DateTime DiaHj = DateTime.Today;
            var pessoa = PessoaRepository.GetAll().Where(pessoa => pessoa.DataNascimento.Day.Equals(DiaHj.Day) && pessoa.DataNascimento.Month.Equals(DiaHj.Month));

            return View(pessoa);
        }

        public ActionResult Index() {
            var model = this.PessoaRepository.GetAll();

            return View(model);
        }

        public ActionResult Details(int id) {
            var model = this.PessoaRepository.GetPessoaById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Search([FromQuery] string query) {
            var model = this.PessoaRepository.Search(query);

            return View("Index", model);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa) {
            try {
                if (ModelState.IsValid == false)
                    return View();
                this.PessoaRepository.Save(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var model = this.PessoaRepository.GetPessoaById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoa model) {
            try {
                model.Id = id;
                this.PessoaRepository.Update(model);

                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        public ActionResult Delete(int id) {
            var model = this.PessoaRepository.GetPessoaById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pessoa model) {
            try {
                model.Id = id;
                this.PessoaRepository.Delete(model);

                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
