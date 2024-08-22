using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MySocialAppAPI.RequestModel
{
    public class ReqRegister
    {
        [Required]
        [Column("_name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("_username")]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [Column("_password")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
