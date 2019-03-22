using System.Collections.Generic;
using System.Linq;
using FuncsApi.Modelos;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FuncsApi.Servicos
{
    public class FuncionarioService
    {
        private readonly IMongoCollection<Funcionarios> _funcionarios;

        public FuncionarioService(IConfiguration config)
        {
            var cliente = new MongoClient(config.GetConnectionString("FuncionariosDB"));
            var bd = cliente.GetDatabase("FuncionariosDB");
            _funcionarios = bd.GetCollection<Funcionarios>("Funcionarios");
        }

        public List<Funcionarios> Get()
        {
            return _funcionarios.Find(funcionario => true).ToList();
        }

        public Funcionarios Get(string id)
        {
            return _funcionarios.Find<Funcionarios>(funcionario => funcionario.Id == id).FirstOrDefault();
        }

        public Funcionarios Criar(Funcionarios funcionario)
        {
            _funcionarios.InsertOne(funcionario);
            return funcionario;
        }

        public void Atualizar(string id, Funcionarios funcionarioIn)
        {
            _funcionarios.ReplaceOne(funcionario => funcionario.Id == id, funcionarioIn);
        }

        public void Remover(Funcionarios funcionarioIn){
            _funcionarios.DeleteOne(funcionario => funcionario.Id == funcionarioIn.Id);
        }

        public void Remover(string id)
        {
            _funcionarios.DeleteOne(funcionario => funcionario.Id == id);
        }
    }
}