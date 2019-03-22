using System.Collections.Generic;
using FuncsApi.Modelos;
using FuncsApi.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace FuncsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionariosController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public ActionResult<List<Funcionarios>> GetAction()
        {
            return _funcionarioService.Get();
        }

        [HttpGet("{id:length(24)}", Name="GetFuncionario")]
        public ActionResult<Funcionarios> Get(string id)
        {
            var funcionario = _funcionarioService.Get(id);

            if(funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        [HttpPost]
        public ActionResult<Funcionarios> Criar(Funcionarios funcionario)
        {
            _funcionarioService.Criar(funcionario);

            return CreatedAtRoute("GetFuncionario", new { id = funcionario.Id.ToString() }, funcionario);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Atualizar(string id, Funcionarios funcionarioIn)
        {
            var funcionario = _funcionarioService.Get(id);

            if(funcionario == null)
            {
                return NotFound();
            }

            _funcionarioService.Atualizar(id, funcionarioIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var funcionario = _funcionarioService.Get(id);

            if(funcionario == null)
            {
                return NotFound();
            }

            _funcionarioService.Remover(funcionario.Id);

            return NoContent();
        }
    }
}