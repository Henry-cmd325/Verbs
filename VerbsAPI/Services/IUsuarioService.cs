using VerbsAPI.Models.Requests;
using VerbsAPI.Models.Responses;

namespace VerbsAPI.Services
{
    public interface IUsuarioService
    {
        public ServerResponse<UserResponse> GetUsuario(int id);
        public ServerResponse<UserResponse> PostUsuario(UserRequest request);
        public ServerResponse<UserResponse> PutUsuario(int id, UserRequest request);
        public ServerResponse<UserResponse> LoginUsuario(UserRequest request);
        public string GenerateToken(UserRequest request, IConfiguration config);
        public bool Delete(int id);
    }
}
