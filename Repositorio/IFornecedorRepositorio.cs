using Registro_de_Fornecedores.Models;

namespace Registro_de_Fornecedores.Repositorio
{
    public interface IFornecedorRepositorio
    {
        FornecedorModel ListarPorId(int id);
        List<FornecedorModel> BuscarTodos();
        FornecedorModel Adicionar(FornecedorModel fornecedor);

        FornecedorModel Atualizar(FornecedorModel fornecedor);

        bool Apagar(int id);
    }
}
