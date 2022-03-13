using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfZad1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal LotteryMachine Machine;
        public MainWindow()
        {
            InitializeComponent();

            Machine = new LotteryMachine();
        }

        private void AddCoupon_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(InputCoupon.Text))
            {
                Machine.AddNewCoupon(InputCoupon.Text);
                InputCoupon.Text = "";

                ShowResult.Content = "Successfully added a new coupon.\n\n" +
                    "Current machine tickets: \n" + Machine.GetAllCoupons();

            }
            else
            {
                MessageBox.Show("Input field cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetCoupon_Click(object sender, RoutedEventArgs e)
        {
            if(Machine.CouponsAvailable())
            {
                string randomCoupon = Machine.GetRandomCoupon();

                ShowResult.Content = "Sucessfully got random coupon.\n\n" +
                    "Random coupon: \n" + randomCoupon + "\n\n" + 
                    "Current machine tickets: \n" + Machine.GetAllCoupons();
            }
            else
            {
                ShowResult.Content = "There aren't any coupons in the machine.\n\n" +
                    "Current machine tickets: \n" + Machine.GetAllCoupons();
            }
        }
    }
}
