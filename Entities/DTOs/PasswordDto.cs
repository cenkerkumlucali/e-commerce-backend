using Core.Entities;

namespace Entities.DTOs
{
    public class PasswordDto:IDto
    {
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}