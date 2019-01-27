using System.Collections.Generic;
using webapi.Models;

namespace webapi.Repositorio
{
    public interface IFuncionarioRepository
    {
        //serviços da webapi

        void Add(Funcionario obj);

        IEnumerable<Funcionario> GetAll();

        Funcionario Find(int id);

        void Remove (int id);

        void Update(Funcionario obj);

    }
}