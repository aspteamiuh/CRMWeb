namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderItemProducts = new HashSet<OrderItemProduct>();
            OrderItemServices = new HashSet<OrderItemService>();
            OrderStatus = new HashSet<OrderStatu>();
        }

        public int ID { get; set; }

        public int IDCustomer { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(111)]
        public string Detail { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItemProduct> OrderItemProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItemService> OrderItemServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderStatu> OrderStatus { get; set; }
    }
}
