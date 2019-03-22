using System.Collections.Generic;
using System.Linq;
using FuncsApi.Modelos;
using Microsoft.Extensions.Configuration;
using MongoDB.driver;

namespace FuncsApi.Servicos
{
    public class FuncionarioService
    {
        private readonly IMongoCollection<Funcionario> _funcionarios;

        public FuncionarioService(Iconfiguration config)
        {
            var cliente = new MongoClient(config.GetConnectionString("FuncionariosDB"));
            var bd = cliente.GetDatabase("FuncionariosDB");
            _funcionarios = bd.GetCollection<Funcionario>("Funcionarios");
        }

        public List<Funcionario> Get()
        {
            return _funcionarios.Find(funcionario => true).ToList();
        }

        public Funcionario GetFuncionario(string id)
        {
            return _funcionarios.Find<Funcionario>(funcionario => funcionario.Id == id).FirstOrDefault();
        }

        public Funcionario Criar(Funcionario funcionario)
        {
            _funcionarios.InsertOne(funcionario);
            return funcionario;
        }

        public void Atualizar(string id, Funcionario funcionarioIn)
        {
            _funcionarios.ReplaceOne(funcionario => funcionario.Id == id, funcionarioIn);
        }

        public void Remover(Funcionario funcionarioIn){
            _funcionarios.DeleteOne(funcionarioIn => funcionario.Id == funcionarioIn.Id);
        }

        public void Remover(string id)
        {
            _funcionarios.DeleteOne(funcionario => funcionario.Id = id);
        }
    }
}