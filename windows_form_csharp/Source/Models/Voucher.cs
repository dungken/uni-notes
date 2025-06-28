using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class Voucher
    {
        public Guid VoucherID { get; set; } = Guid.NewGuid();
        public string VoucherCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinimumOrderValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UsageLimit { get; set; }
        public int TimesUsed { get; set; } 
        public bool IsActive { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

      
    }
}
