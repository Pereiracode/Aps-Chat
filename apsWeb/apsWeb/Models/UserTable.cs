using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apsWeb.Models
{
    [Table("USER_TABLE")]
    public partial class UserTable
    {
        public UserTable()
        {
            MessageTables = new HashSet<MessageTable>();
            MultiChannels = new HashSet<MultiChannel>();
            UserChannels = new HashSet<UserChannel>();
        }

        [Key]
        [Column("USER_LOGIN")]
        [StringLength(256)]
        public string UserLogin { get; set; }
        [Required]
        [Column("USER_PASSWORD")]
        [StringLength(30)]
        public string UserPassword { get; set; }
        [Required]
        [Column("USERNAME")]
        [StringLength(30)]
        public string Username { get; set; }

        [InverseProperty(nameof(MessageTable.UserLoginNavigation))]
        public virtual ICollection<MessageTable> MessageTables { get; set; }
        [InverseProperty(nameof(MultiChannel.Manager))]
        public virtual ICollection<MultiChannel> MultiChannels { get; set; }
        [InverseProperty(nameof(UserChannel.UserLoginNavigation))]
        public virtual ICollection<UserChannel> UserChannels { get; set; }
    }
}
