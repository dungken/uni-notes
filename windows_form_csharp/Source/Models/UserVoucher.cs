namespace Source.Models
{
    public class UserVoucher
    {
        public Guid UserID { get; set; }
        public Guid VoucherID { get; set; }

        public User User { get; set; }
        public Voucher Voucher { get; set; }
    }
}
