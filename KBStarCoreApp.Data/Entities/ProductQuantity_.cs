﻿using KBStarCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace KBStarCoreApp.Data.Entities
{
    [Table("ProductQuantities")]
    public class ProductQuantity_ : DomainEntity<int>
    {

        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Column(Order = 2)]
        public int SizeId { get; set; }


        [Column(Order = 3)]
        public int ColorId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product_ Product { get; set; }

        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }
}
