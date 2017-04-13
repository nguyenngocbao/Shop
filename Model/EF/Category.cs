namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long ID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string MetaTitle { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(10)]
        public string ParentID { get; set; }

        [StringLength(10)]
        public string ShowOnHome { get; set; }
    }
}
