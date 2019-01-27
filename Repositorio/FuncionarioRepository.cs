using System.Collections.Generic;
using System.Linq;
using webapi.Models;

namespace webapi.Repositorio
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly FuncionarioDbContext _context;
        public FuncionarioRepository (FuncionarioDbContext context)
        {
            _context = context;
        }
        public void Add(Funcionario obj)
        {
            _context.Funcionarios.Add(obj);
            _context.SaveChanges();
        }

        public Funcionario Find(int id)
        {
            return _context.Funcionarios.FirstOrDefault(f => f.IdFuncionario == id);
        }

        public IEnumerable<Funcionario> GetAll()
        {
            return _context.Funcionarios.ToList();
        }

        public void Remove(int id)
        {
            var func = _context.Funcionarios.First(f => f.IdFuncionario == id);
            _context.Funcionarios.Remove(func);
            _context.SaveChanges();
        }

        public void Update(Funcionario obj)
        {
            _context.Funcionarios.Update(obj);
            _context.SaveChanges();
        }
    }
}