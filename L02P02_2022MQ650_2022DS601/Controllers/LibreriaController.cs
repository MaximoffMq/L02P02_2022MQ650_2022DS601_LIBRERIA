using L02P02_2022MQ650_2022DS601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L02P02_2022MQ650_2022DS601.Controllers
{
    public class LibreriaController : Controller
    {
        private readonly libreriaDbContex _context;

        // Constructor con inyección de dependencias
        public LibreriaController(libreriaDbContex context)
        {
            _context = context;
        }

        public IActionResult Autores()
        {
            // Obtener lista de autores desde la base de datos
            var listaDeAutores = (from m in _context.autores
                                  select m).ToList();

            // Pasar la lista de autores a la vista usando ViewData
            ViewData["listadoDeAutores"] = new SelectList(listaDeAutores, "id", "autor");

            return View();
        }
        public IActionResult Libros(int id)
        {

            return View();
        }

        public IActionResult Comentarios()
        {
            return View();
        }
        public IActionResult Confirmacion()
        {
            return View();
        }

        
    }
}
