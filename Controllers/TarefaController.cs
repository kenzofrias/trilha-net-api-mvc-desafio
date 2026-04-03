using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using trilha_net_api_mvc_desafio.Context;
using trilha_net_api_mvc_desafio.Models.Entities;

namespace trilha_net_api_mvc_desafio.Controllers
{
    public class TarefaController : Controller
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult Buscar(string busca)
        {
            var tarefas = _context.Tarefas.AsQueryable(); //realiza uma pesquisa mais precisa

            if (!string.IsNullOrEmpty(busca)) //checa se o valor de 'busca' é null ou vazio
            {
                busca = busca.ToLower(); //deixa tudo minusculo para analisar

                if (busca == "pendente")
                {
                    tarefas = tarefas.Where(x => x.Status == EnumStatusTarefa.Pendente);
                }
                else if (busca == "finalizado")
                {
                    tarefas = tarefas.Where(x => x.Status == EnumStatusTarefa.Finalizado);
                }
                else if (DateTime.TryParse(busca, out DateTime data)) //tenta converter para data
                {
                    tarefas = tarefas.Where(x => x.Data.Date == data.Date);
                }
                else
                {
                    tarefas = tarefas.Where(x => x.Titulo.ToLower().Contains(busca));
                }
            }

            return View("Index", tarefas.ToList());
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public IActionResult Editar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof
            (Index));
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}