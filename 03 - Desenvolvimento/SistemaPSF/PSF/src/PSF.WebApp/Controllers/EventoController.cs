using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;
using PSF.Dominio.ValueObjects;
using PSF.WebApp.Filters;
using PSF.WebApp.Models;
using System.Data.SqlTypes;
using System.Text;

namespace PSF.WebApp.Controllers
{
    [PaginaUsuarioLogado]
    public class EventoController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult IMAB()
        {
            var usuarios = db.Usuario.ToList();
            ViewBag.Usuarios = new SelectList(usuarios, "UsuarioId", "Nome");

            var entidade = new IMAPViewModel
            {
                Indicadores = db.Indicador.ToList(),
                // certifique-se de inicializar outras propriedades, se necessário
            };

            return View(entidade);
        }

        public IActionResult Inserir()
        {

            // var esf = db.Indicador.ToList();
            // ViewBag.Indicador = new SelectList(esf, "EsfId", "Nome");
            var usuarios = db.Usuario.ToList();
            ViewBag.Usuarios = new SelectList(usuarios, "UsuarioId", "Nome");
            var evento = new Evento();
            return View(evento);

        }

        [HttpPost]
        public IActionResult IMAB_Confirmar([FromBody] List<IMAPRespostaViewModel> entidade, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (entidade == null || entidade.Count == 0)
                {
                    return BadRequest(new { success = false, message = "Nenhum dado recebido para registro" });
                }

                foreach (var resposta in entidade)
                {
                    if (resposta.UsuarioId == 0)
                    {
                        throw new InvalidOperationException("UsuarioId não fornecido.");
                    }

                    var usuarioExistente = db.Usuario.Find(resposta.UsuarioId);

                    if (usuarioExistente == null)
                    {
                        throw new InvalidOperationException($"O UsuarioId {resposta.UsuarioId} não existe na tabela Usuario.");
                    }

                    // Verifique se já existe um evento para o usuário, indicador e data selecionados
                    var eventoExistente = db.Evento
                        .FirstOrDefault(e => e.UsuarioId == resposta.UsuarioId &&
                                              e.IndicadorId == resposta.IndicadorId &&
                                              e.Data == startDate);

                    if (eventoExistente != null)
                    {
                        // Se existir, atualize o valor
                        eventoExistente.Valor = resposta.Valor;
                    }
                    else
                    {
                        // Se não existir, crie um novo evento
                        var novoEvento = new Evento
                        {
                            IndicadorId = resposta.IndicadorId,
                            Data = startDate,
                            Valor = resposta.Valor,
                            UsuarioId = resposta.UsuarioId
                        };

                        db.Evento.Add(novoEvento);
                    }
                }

                db.SaveChanges();
                //TempData["MensagemSucesso"] = "Valores do IMAB registrados com sucesso";
                return Json(new { success = true, message = "Valores do IMAB registrados com sucesso" });
            }
            catch (Exception ex)
            {
                //TempData["MensagemErro"] = $"Erro ao registrar valores do IMAB: {ex.Message}";
                return Json(new { success = false, message = $"Erro ao registrar valores do IMAB: {ex.Message}" });
            }
        }



        public IActionResult SelecionarRelatorio()
        {
            // Lógica para obter os usuários que você deseja exibir no dropdown
            var usuarios = db.Usuario.Select(u => new SelectListItem
            {
                Value = u.UsuarioId.ToString(),
                Text = u.Nome
            }).ToList();

            ViewBag.Usuarios = usuarios;

            return View();
        }
        [HttpGet]
        public IActionResult GerarRelatorio(DateTime startDate, DateTime endDate, int usuarioId)
        {
            // Valide as datas para garantir que estejam dentro do intervalo suportado pelo SQL Server
            startDate = startDate < SqlDateTime.MinValue.Value ? SqlDateTime.MinValue.Value : startDate;
            endDate = endDate > SqlDateTime.MaxValue.Value ? SqlDateTime.MaxValue.Value : endDate;

            // Obtenha os dados do banco de dados ou de onde quer que estejam armazenados
            var dadosRelatorio = db.Evento
                .Include(e => e.Indicador)
                .Include(e => e.Usuario)
                .Where(e => e.Data >= startDate && e.Data <= endDate && e.UsuarioId == usuarioId)
                .Select(e => new RelatorioViewModel
                {
                    Data = e.Data,
                    Usuario = e.Usuario,
                    Indicador = new Indicador
                    {
                        Titulo = e.Indicador.Titulo
                    },
                    Valor = e.Valor
                })
                .ToList();

            // Crie o conteúdo do arquivo CSV
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Data,Usuário,Indicador,Valor");

            foreach (var item in dadosRelatorio)
            {
                csvContent.AppendLine($"{item.Data},{item.Usuario.Nome},{item.Indicador.Titulo},{item.Valor}");
            }

            // Crie o nome do arquivo
            var fileName = $"relatorio_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.csv";

            // Devolva o arquivo CSV
            return File(Encoding.UTF8.GetBytes(csvContent.ToString()), "text/csv", fileName);
        }


    }
}
