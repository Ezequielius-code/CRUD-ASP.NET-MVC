using Microsoft.AspNetCore.Mvc;
using CRUD_Web.Datos;
using CRUD_Web.Models;

namespace CRUD_Web.Controllers
{
    public class CRUDController : Controller
    {
        ClienteDatos clienteDatos = new ClienteDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var listaClientes = clienteDatos.Listar();
            return View(listaClientes);
        }

        //Va a mostrar una ventana para añadir los datos del nuevo registro
        public IActionResult Guardar()
        {
            return View();
        }

        //Va a guardar el registro con los datos que indicamos
        [HttpPost]
        public IActionResult Guardar(ModelCliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = clienteDatos.Guardar(cliente);

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
