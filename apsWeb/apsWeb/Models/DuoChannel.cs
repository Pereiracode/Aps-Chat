using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apsWeb.Models
{
    [Table("DUO_CHANNEL")]
    public partial class DuoChannel
    {
        [Key]
        [Column("CHANNEL_ID", TypeName = "decimal(18, 0)")]
        public decimal ChannelId { get; set; }

        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("DuoChannel")]
        public virtual Channel Channel { get; set; }
    }
}
