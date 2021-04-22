using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apsWeb.Models
{
    [Table("MESSAGE_TABLE")]
    public partial class MessageTable
    {
        [Key]
        [Column("MESSAGE_ID", TypeName = "decimal(18, 0)")]
        public decimal MessageId { get; set; }
        [Key]
        [Column("CHANNEL_ID", TypeName = "decimal(18, 0)")]
        public decimal ChannelId { get; set; }
        [Key]
        [Column("USER_LOGIN")]
        [StringLength(256)]
        public string UserLogin { get; set; }
        [Column("SENDING_TIME", TypeName = "datetime")]
        public DateTime? SendingTime { get; set; }
        [Column("CONTENT")]
        [StringLength(2000)]
        public string Content { get; set; }

        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("MessageTables")]
        public virtual Channel Channel { get; set; }
        [ForeignKey(nameof(UserLogin))]
        [InverseProperty(nameof(UserTable.MessageTables))]
        public virtual UserTable UserLoginNavigation { get; set; }
    }
}
