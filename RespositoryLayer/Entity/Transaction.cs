using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RespositoryLayer.Entity
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        [Required]
        public string PaymentType { get; set; }

        public string PaymentTransactionId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
