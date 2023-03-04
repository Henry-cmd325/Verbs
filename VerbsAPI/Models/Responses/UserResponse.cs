namespace VerbsAPI.Models.Responses
{
    public class UserResponse
    {
        public int cveUsuarios { get; set; }
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
}
