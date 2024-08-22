using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MySocialAppAPI.ResponnceModel
{
    public class ResLogin
    {

        [Key]
        [Column("_id")]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Column("_password")]
        [StringLength(100)]
        public string Password { get; set; }

    }
}
