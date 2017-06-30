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

       

        [StringLength(250)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

      
        public long? CategoriesID { get; set; }

        

        public DateTime? InsertDate { get; set; }

       
    }
}
