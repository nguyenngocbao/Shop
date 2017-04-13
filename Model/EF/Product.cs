namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public long? CategoriesID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        public Product findByID(long? id)
        {
            throw new NotImplementedException();
        }
    }
}
