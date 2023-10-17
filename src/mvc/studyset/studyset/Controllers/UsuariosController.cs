using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studyset.Models;

namespace studyset.Controllers
{
    public class UsuariosController : Controller {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context) {
            _context = context;
        }
    }
}
