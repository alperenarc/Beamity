using System.ComponentModel.DataAnnotations;

namespace Beamity.Application.DTOs.TokenDTOs
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}