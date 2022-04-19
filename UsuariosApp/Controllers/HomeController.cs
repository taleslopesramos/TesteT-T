using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using Services.Interfaces;
using UsuariosApp.Models;

namespace UsuariosApp.Controllers;

public class HomeController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public IActionResult Index()
    {
        return View(_usuarioService.GetAll());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(UsuarioCreateModel usuario)
    {
        if (_usuarioService.Add(usuario))
            return RedirectToAction("Index");
        else
            return RedirectToAction("Warning", new
            {
                title = "Erro ao criar Usuário",
                message = "As novas senhas não são iguais!"
            });
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var usuario = _usuarioService.GetById(id);
        if (usuario == null) return Error();

        UsuarioEditModel model = new UsuarioEditModel()
        {
            Id = usuario.Id,
            Ativo = usuario.Ativo,
            Nome = usuario.Nome,
            RG = usuario.RG,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(UsuarioEditModel usuario)
    {
        if (_usuarioService.Update(usuario))
            return RedirectToAction("Index");
        else
            return RedirectToAction("Warning", new
            {
                title = "Erro ao atualizar Usuário",
                message = "A senha antiga está errada ou as novas senhas não são iguais!"
            });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Warning(string title, string message)
    {
        return View(new WarningViewModel() { Message = message, Title = title });
    }

}
