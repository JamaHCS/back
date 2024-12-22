using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public record RegisterDTO
    {
        public string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string LastName { get; init; }
        public string MotherLastName { get; set; }
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public record LoginDTO
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class AuthResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
