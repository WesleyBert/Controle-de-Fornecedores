using System.ComponentModel.DataAnnotations;

namespace Registro_de_Fornecedores.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Fornecedor")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o CNPJ do Fornecedor")]
        public int CNPJ { get; set; }
        
        public string Especialidade { get; set; }
    }
}
