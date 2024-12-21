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
        [Required]
        [MaxLength(100)]
        public string FirstName { get; init; }

        [MaxLength(100)]
        public string? MiddleName { get; init; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; init; }

        [Required]
        [MaxLength(100)]
        public string MotherLastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; init; }

        [Required]
        [MaxLength (100)]
        [MinLength(8)]
        public string Password { get; init; }
    }

    public record LoginDTO
    {
        [Required]
        public string Email { get; init; }

        [Required]
        [MinLength(8)]
        public string Password { get; init; }
    }

    public class AuthResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
