using Microsoft.AspNetCore.Mvc;
using CrudClientes.Datos;
using CrudClientes.Models;

namespace CrudClientes.Controllers
{
    public class MantenedorController : Controller
    {
        ClienteDatos _ClienteDatos = new ClienteDatos();
        public IActionResult Listar()
        {
            var lista = _ClienteDatos.Listar();

            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel cliente)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ClienteDatos.Guardar(cliente);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }


        }

        public IActionResult Editar(int idCli)
        {
            var cliente = _ClienteDatos.Obtener(idCli);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ClienteDatos.Editar(cliente);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int idCli) {

            var cliente = _ClienteDatos.Obtener(idCli);
            return View(cliente);

        }

        [HttpPost]
        public IActionResult Eliminar(ClienteModel cliente)
        {

            var respuesta = _ClienteDatos.Eliminar(cliente.idCli);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

    }
}
