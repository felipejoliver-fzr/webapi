using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Repositorio;

namespace webapi.Controllers
{
    [Route("webapi/[Controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioController(IFuncionarioRepository funcionarioRepo)
        {
            _funcionarioRepository = funcionarioRepo;
        }

        [HttpGet]
        public IEnumerable<Funcionario> GetAll()
        {
            return _funcionarioRepository.GetAll();
        }

        [HttpGet("{id}", Name="GetFuncionario")]
        public IActionResult GetById(int id){
            var funcionario = _funcionarioRepository.Find(id);

            if(funcionario == null){
                return NotFound();
            }else{
                return new OkObjectResult(funcionario);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Funcionario funcionario)
        {
            if(funcionario == null){
                return BadRequest();
            }else{
                _funcionarioRepository.Add(funcionario);

                return CreatedAtRoute("GetFuncionario", new{id = funcionario.IdFuncionario}, funcionario);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Funcionario funcionario)
        {
            if(funcionario == null || funcionario.IdFuncionario != id){
                return BadRequest();
            }else{
                var funcionarioExiste = _funcionarioRepository.Find(id);

                if(funcionarioExiste == null)
                {
                    return NotFound();
                }else{
                    funcionarioExiste.Nome = funcionario.Nome;
                    funcionarioExiste.Email = funcionario.Email;

                    _funcionarioRepository.Update(funcionarioExiste);

                    return new NoContentResult();
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var funcionario = _funcionarioRepository.Find(id);

            if(funcionario == null)
            {
                return NotFound();
            }else
            {
                _funcionarioRepository.Remove(id);
                return new NoContentResult();



            }



        }
    }
}