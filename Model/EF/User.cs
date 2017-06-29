namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên ")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên Số điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }

        public bool? Status { get; set; }
    }
}
