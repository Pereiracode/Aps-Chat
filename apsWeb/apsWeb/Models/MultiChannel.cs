using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apsWeb.Models
{
    [Table("MULTI_CHANNEL")]
    public partial class MultiChannel
    {
        [Key]
        [Column("CHANNEL_ID", TypeName = "decimal(18, 0)")]
        public decimal ChannelId { get; set; }
        [Column("MANAGER_ID")]
        [StringLength(256)]
        public string ManagerId { get; set; }
        [Column("NAME")]
        [StringLength(20)]
        public string Name { get; set; }

        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("MultiChannel")]
        public virtual Channel Channel { get; set; }
        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(UserTable.MultiChannels))]
        public virtual UserTable Manager { get; set; }
    }
}
