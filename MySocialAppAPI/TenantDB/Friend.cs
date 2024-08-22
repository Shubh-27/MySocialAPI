using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MySocialAppAPI.TenantDB
{
    [Table("Friend")]
    public partial class Friend
    {
        [Key]
        [Column("FriendID")]
        public int FriendId { get; set; }
        [Column("FromUserID")]
        public int FromUserId { get; set; }
        [Column("ToUserID")]
        public int ToUserId { get; set; }
        public bool? Status { get; set; }

        [ForeignKey(nameof(FromUserId))]
        [InverseProperty(nameof(MySocial.FriendFromUsers))]
        public virtual MySocial FromUser { get; set; }
        [ForeignKey(nameof(ToUserId))]
        [InverseProperty(nameof(MySocial.FriendToUsers))]
        public virtual MySocial ToUser { get; set; }
    }
}
