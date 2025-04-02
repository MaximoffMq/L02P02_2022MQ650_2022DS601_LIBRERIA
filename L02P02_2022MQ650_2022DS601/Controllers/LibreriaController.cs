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

            // Obtener el autor seleccionado
            var autor = _context.autores.FirstOrDefault(a => a.id == id);

            // Obtener los libros de ese autor
            var libros = _context.libros.Where(l => l.id_autor == id).ToList();

            // Pasar datos a la vista
            ViewData["autorSeleccionado"] = autor?.autor;
            ViewData["librosDelAutor"] = libros;


            return View();
        }

        public IActionResult Comentarios(int id, string nombre, string nombre_autor)
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
            ViewBag.nombre = nombre;
            ViewBag.nombre_autor = nombre_autor;
            ViewBag.id_libro = id;

            return View();
        }

        [HttpPost]
        public IActionResult Confirmacion(int id, string nombre, string nombre_autor, string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                ModelState.AddModelError("descripcion", "El comentario no puede estar vacío.");
                return View();
            }

            var comentario = new comentarios_libros
            {
                id_libro = id,
                comentarios = descripcion,
                usuario = "Mario Morales",
                created_at = DateTime.Now
            };

            _context.comentarios_libros.Add(comentario);
            _context.SaveChanges();

            var listaDeComentarios = _context.comentarios_libros
                .Where(m => m.id_libro == id)
                .ToList();

            ViewData["listadoDeComentarios"] = listaDeComentarios;
            ViewBag.nombre = nombre;
            ViewBag.nombre_autor = nombre_autor;
            ViewBag.id_libro = id;

            return View();
        }


    }
}
