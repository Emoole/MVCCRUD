using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;


namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        //referencia a la clase de AlumnosDatos donde estan las operaciones.
        AlumnosDatos _AlumnosDatos= new AlumnosDatos();

        public IActionResult Listar()
        {
            //La vista mostrara la lista de alumnos.
            var oLista = _AlumnosDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Solo devuelve la vista
            return View();
        }
        //
        [HttpPost]
        public IActionResult Guardar(AlumnosModel oAlumno)
        {
            //Recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var rpta = _AlumnosDatos.Guardar(oAlumno);
            if (rpta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Editar(int Id)
        {
            //Muestra el contacto Id
            var oAlumno = _AlumnosDatos.Obtener(Id);
            return View(oAlumno);
        }
        [HttpPost]
        public IActionResult Editar(AlumnosModel oAlumno)
        {
            var rpta = _AlumnosDatos.Editar(oAlumno);
            if (rpta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int Id)
        {
            //Muestra el contacto Id
            var oAlumno = _AlumnosDatos.Obtener(Id);
            return View(oAlumno);
        }

        [HttpPost]
        public IActionResult Eliminar(AlumnosModel oAlumno)
        {
            //int id = oAlumno.Id;
            var rpta = _AlumnosDatos.Eliminar(oAlumno.Id);

            if (rpta)
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
