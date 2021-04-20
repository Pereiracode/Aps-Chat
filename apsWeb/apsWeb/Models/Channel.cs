using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apsWeb.Models
{
    [Table("CHANNEL")]
    public partial class Channel
    {
        public Channel()
        {
            MessageTables = new HashSet<MessageTable>();
            UserChannels = new HashSet<UserChannel>();
        }

        [Key]
        [Column("CHANNEL_ID", TypeName = "decimal(18, 0)")]
        public decimal ChannelId { get; set; }

        [InverseProperty("Channel")]
        public virtual DuoChannel DuoChannel { get; set; }
        [InverseProperty("Channel")]
        public virtual MultiChannel MultiChannel { get; set; }
        [InverseProperty(nameof(MessageTable.Channel))]
        public virtual ICollection<MessageTable> MessageTables { get; set; }
        [InverseProperty(nameof(UserChannel.Channel))]
        public virtual ICollection<UserChannel> UserChannels { get; set; }
    }
}
