using Microsoft.AspNetCore.Mvc;
using Registro_de_Fornecedores.Models;
using Registro_de_Fornecedores.Repositorio;

namespace Registro_de_Fornecedores.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index()
        {
            List<FornecedorModel> fornecedor = _fornecedorRepositorio.BuscarTodos();
            return View(fornecedor);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            bool apagado = _fornecedorRepositorio.Apagar(id);
            try
            {
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Fornecedor apagado com sucesso";

                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu fornecedor";

                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu fornecedor,mais detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    

    [HttpPost]
    public IActionResult Criar(FornecedorModel fornecedor)
    {
         try
           {
             if (ModelState.IsValid)
               {
                   _fornecedorRepositorio.Adicionar(fornecedor);
                   TempData["MensagemSucesso"] = "Fornecedor cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                    return View(fornecedor);
            }
            catch (System.Exception erro)
            {
                _fornecedorRepositorio.Adicionar(fornecedor);
                TempData["MensagemErro"] = $"Ops,não conseguimos adicionar o cadastrado, mais informações :{erro.Message}";
                     return RedirectToAction("Index");
            }
    }

    [HttpPost]
    public IActionResult Alterar(FornecedorModel fornecedor)
    {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Atualizar(fornecedor);
                    TempData["MensagemSucesso"] = "fornecedor atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                     return View("Editar", fornecedor);
            }
             catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,não conseguimos atualizar o cadastrado, mais informações :{erro.Message}";
                return RedirectToAction("Index");
            }
    }
}
}
    

