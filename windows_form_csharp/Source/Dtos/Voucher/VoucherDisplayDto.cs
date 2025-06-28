using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Dtos.Voucher
{
    public class VoucherDisplayDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public decimal MinOrder { get; set; }
        public int? Limit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
