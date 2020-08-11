using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Common;

namespace FinalProject.DataModels
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public string IdCust { get; set; }
        public string NameCust { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public string PassWord { get; set; }
        public bool Status { get; set; }
        public string RandomKey { get; set; }

        public ICollection<DonHang> DonHangs { get; set; }

        public Customer()
        {
            DonHangs = new HashSet<DonHang>();
        }
      
    }
}
