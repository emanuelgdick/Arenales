namespace Api.Models
{
    public class RegisterRequestDTO
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string? ApeyNom { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public long? IdLocalidad { get; set; }
    }
}
