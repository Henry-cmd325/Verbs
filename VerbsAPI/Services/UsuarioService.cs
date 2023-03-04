using VerbsAPI.Context;
using VerbsAPI.Models.Requests;
using VerbsAPI.Models.Responses;
using VerbsAPI.Tools;

namespace VerbsAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly EnglishContext _context;
        public UsuarioService(EnglishContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var dbUsuario = _context.Usuarios.Where(u => u.CveUsuarios == id).FirstOrDefault();

            if (dbUsuario == null)
                return false;

            _context.Usuarios.Remove(dbUsuario);
            _context.SaveChanges();

            return true;
        }

        public ServerResponse<UserResponse> GetUsuario(int id)
        {
            ServerResponse<UserResponse> response = new();

            var dbUsuario = _context.Usuarios.Where(u => u.CveUsuarios == id).FirstOrDefault();

            if (dbUsuario == null)
            {
                response.Success = false;
                response.Error = "El id otorgado no corresponde con ningun registro de usuario";

                return response;
            }

            response.Data = new UserResponse()
            {
                cveUsuarios = dbUsuario.CveUsuarios,
                Contraseña = dbUsuario.Contraseña,
                Correo = dbUsuario.Contraseña
            };

            return response;
        }

        public ServerResponse<UserResponse> LoginUsuario(UserRequest request)
        {
            ServerResponse<UserResponse> response = new();

            var dbUsuario = _context.Usuarios.Where(u => u.Correo == request.Correo && Encrypt.GetSha256(request.Contraseña) == u.Contraseña).FirstOrDefault();

            if (dbUsuario == null)
            {
                response.Success = false;
                response.Error = "El usuario y la contraseña no corresponde con ningun usuario registrado";

                return response;
            }

            response.Data = new()
            {
                cveUsuarios = dbUsuario.CveUsuarios,
                Contraseña = dbUsuario.Contraseña,
                Correo = dbUsuario.Correo
            };

            return response;
        }

        public ServerResponse<UserResponse> PostUsuario(UserRequest request)
        {
            ServerResponse<UserResponse> response = new();

            var dbUsuario = _context.Usuarios.Where(u => u.Correo == request.Correo).FirstOrDefault();

            if (dbUsuario != null)
            {
                response.Success = false;
                response.Error = "El correo otorgado ya esta registrado";

                return response;
            }

            dbUsuario = new()
            {
                Contraseña = Encrypt.GetSha256(request.Contraseña),
                Correo = request.Correo
            };

            _context.Usuarios.Add(dbUsuario);
            _context.SaveChanges();

            response.Data = new()
            {
                cveUsuarios = dbUsuario.CveUsuarios,
                Correo = dbUsuario.Correo,
                Contraseña = dbUsuario.Contraseña
            };

            return response;
        }

        public ServerResponse<UserResponse> PutUsuario(int id, UserRequest request)
        {
            ServerResponse<UserResponse> response = new();

            var dbUsuario = _context.Usuarios.Where(u => u.CveUsuarios == id).FirstOrDefault();

            if (dbUsuario == null)
            {
                response.Success = false;
                response.Error = "El id introducido no corresponde con ningun registro";

                return response;
            }

            dbUsuario.Correo = request.Correo;
            dbUsuario.Contraseña = Encrypt.GetSha256(request.Contraseña);

            _context.Entry(dbUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            response.Data = new()
            {
                Contraseña = dbUsuario.Contraseña,
                Correo = dbUsuario.Correo
            };

            return response;
        }
    }
}
