using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MySocialAppAPI.TenantDB
{
    [Table("Post")]
    public partial class Post
    {
        [Key]
        [Column("PostID")]
        public int PostId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [StringLength(500)]
        public string PostText { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDateTime { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(MySocial.Posts))]
        public virtual MySocial User { get; set; }
    }
}
