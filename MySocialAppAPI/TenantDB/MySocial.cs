using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MySocialAppAPI.TenantDB
{
    [Table("MySocial")]
    public partial class MySocial
    {
        public MySocial()
        {
            FriendFromUsers = new HashSet<Friend>();
            FriendToUsers = new HashSet<Friend>();
            Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AccountCreated { get; set; }

        [InverseProperty(nameof(Friend.FromUser))]
        public virtual ICollection<Friend> FriendFromUsers { get; set; }
        [InverseProperty(nameof(Friend.ToUser))]
        public virtual ICollection<Friend> FriendToUsers { get; set; }
        [InverseProperty(nameof(Post.User))]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
