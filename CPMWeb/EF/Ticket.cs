namespace CPMWeb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int IDCustomer { get; set; }

        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Detail { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
