namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
            Tickets = new HashSet<Ticket>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Tên Khách Hàng")]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "địa chỉ E-mail")]
        public string Mail { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
