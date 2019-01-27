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
    }
}