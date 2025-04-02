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

        public IActionResult Comentarios(int id)
        {
            // Obtener la lista de comentarios del libro con el id especificado
            var listaDeComentarios = (from m in _context.comentarios_libros
                                      where m.id_libro == id
                                      select new comentarios_libros
                                      {
                                          id = m.id,
                                          id_libro = m.id_libro,
                                          comentarios = m.comentarios,
                                          usuario = m.usuario,
                                          created_at = m.created_at
                                      }).ToList();

            // Pasar la lista de comentarios a la vista usando ViewData
            ViewData["listadoDeComentarios"] = listaDeComentarios;

            return View();
        }

        public IActionResult Confirmacion()
        {
            return View();
        }

        
    }
}
