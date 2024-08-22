using System.ComponentModel.DataAnnotations;
using System;

namespace MySocialAppAPI.ResponnceModel
{
    public class ResPost
    {
        [StringLength(100)]
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int? UserId { get; set; }
        public string PostText { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
