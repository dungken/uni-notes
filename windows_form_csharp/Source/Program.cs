

using Source.Views;
using Source.Views.Admin;
using Source.Views.Admin.Inventory;
using Source.Views.Custommer;

namespace Source
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new MainForm());
            Application.Run(new Login());
            //Application.Run(new OrderInvoices());
            //Application.Run(new Cart());
            //Application.Run(new ProductDetails());
            //Application.Run(new ReviewProduct());
            //Application.Run(new WatchReview());
            //Application.Run(new MainFormAdmin());
            //Application.Run(new CategoryList());
            //Application.Run(new CategoriesEdit());
            //Application.Run(new VouchersList());
            //Application.Run(new CouponsEdit());
            //Application.Run(new OrdersList());
            //Application.Run(new OrderDetails());
            //Application.Run(new CustomersList());
            //Application.Run(new CustomersDetails());
            //Application.Run(new StockList());
            //Application.Run(new TestAccountService());
            //Application.Run(new PhuongAnh_Test());
            //Application.Run(new MainForm());
            //Application.Run(new PaymentCustomer());
            //Application.Run(new ProductAdd());
            //Application.Run(new ProductsCustomer());
            //Application.Run(new OptionVourcher());
            //Application.Run(new OrderInvoices());
        }
    }

}