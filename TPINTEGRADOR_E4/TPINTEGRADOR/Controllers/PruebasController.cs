using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PruebasController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext _context;

        public PruebasController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("test")]
        [HttpGet]
        public string GetDePrueba()
        {
            object result = new
            {
                status = true,
                message = "TU VIEJA",
                content = "PRUEBA EXITOSA"
            };

            return JsonHelper.SerializeObject(result, 1);
        }

        [Route("save")]
        [HttpPost]
        public string SavePrueba([FromBody] Usuario user) //[FromQuery]
        {
            // validar propiedades del usuario

            Usuario usuarioACrear = new Usuario();
            usuarioACrear.Activo = true;
            if(user.PersonaId != 0) usuarioACrear.PersonaId = user.PersonaId;
            usuarioACrear.Contrasenia = user.Contrasenia;
            usuarioACrear.CorreoElectronico = user.CorreoElectronico;

            _context.Usuarios.Add(usuarioACrear);
            _context.SaveChanges();

            object result = new
            {
                status = true,
                message = "Persona guardada correctamente",
                content = new {}
            };

            return JsonHelper.SerializeObject(result, 1);
        }
    }
}