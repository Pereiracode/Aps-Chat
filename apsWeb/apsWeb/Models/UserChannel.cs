using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apsWeb.Models
{
    [Table("USER_CHANNEL")]
    public partial class UserChannel
    {
        [Key]
        [Column("CHANNEL_ID", TypeName = "decimal(18, 0)")]
        public decimal ChannelId { get; set; }
        [Key]
        [Column("USER_LOGIN")]
        [StringLength(256)]
        public string UserLogin { get; set; }

        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("UserChannels")]
        public virtual Channel Channel { get; set; }
        [ForeignKey(nameof(UserLogin))]
        [InverseProperty(nameof(UserTable.UserChannels))]
        public virtual UserTable UserLoginNavigation { get; set; }
    }
}
