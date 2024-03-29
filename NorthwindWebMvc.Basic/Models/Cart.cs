﻿using NorthwindWebMvc.Basic.Models.Enum;
using NorthwindWebMvc.Basic.Models.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebMvc.Basic.Models
{
    [Table("Carts", Schema = "sales")]
    public class Cart : IIdentityModel
    {
        [Key]
        [Column("CartId")]
        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public StatusType Status { get; set; }


    }
}
