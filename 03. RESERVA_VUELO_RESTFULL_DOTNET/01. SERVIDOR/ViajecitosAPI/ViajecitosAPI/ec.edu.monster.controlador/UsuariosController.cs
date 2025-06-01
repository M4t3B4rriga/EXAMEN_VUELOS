using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViajecitosAPI.Data;
using ViajecitosAPI.ec.edu.monster.modelo;

namespace ViajecitosAPI.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ViajecitosContext _context;

        public UsuariosController(ViajecitosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<int>> GetUsuarioIdPorEmail(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.email == email);
            if (usuario == null)
                return NotFound("Usuario no encontrado.");
            return Ok(usuario.id_usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        // Nueva clase para recibir datos de login
        public class LoginRequest
        {
            public string email { get; set; }
            public string contrasena { get; set; }
        }

        // POST: api/Usuarios/login
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.email) || string.IsNullOrEmpty(request.contrasena))
                return BadRequest("El correo y la contraseña son obligatorios.");

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.email == request.email && u.contrasena == request.contrasena);

            if (usuario == null)
                return Unauthorized("Credenciales inválidas.");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id_usuario }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.id_usuario) return BadRequest();
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
