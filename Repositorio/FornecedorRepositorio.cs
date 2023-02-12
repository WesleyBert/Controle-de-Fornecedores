
using Microsoft.EntityFrameworkCore;
using Registro_de_Fornecedores.Data;
using Registro_de_Fornecedores.Models;

namespace Registro_de_Fornecedores.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
   
        private readonly BancoContext _context;

        public FornecedorRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public FornecedorModel ListarPorId(int id)
        {
            return _context.Fornecedores.FirstOrDefault(x => x.Id == id);
        }
        public List<FornecedorModel> BuscarTodos()
        {
            return _context.Fornecedores.ToList();
        }
        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();

            return (fornecedor);
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDB = ListarPorId(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na atualização!");

            fornecedorDB.Name = fornecedor.Name;
            fornecedorDB.CNPJ = fornecedor.CNPJ;
            fornecedorDB.Especialidade = fornecedor.Especialidade;

            _context.Fornecedores.Update(fornecedorDB);
            _context.SaveChanges();

            return fornecedorDB; 
        }
        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListarPorId(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na tentativa de deletar!");

            _context.Fornecedores.Remove(fornecedorDB);
            _context.SaveChanges();

            return true;
        }
    }
    }

