using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;

namespace SansliPlatform.UserControls
{
    /// <summary>
    /// Interaction logic for MasterControl.xaml
    /// </summary>
    public partial class MasterControl : System.Windows.Controls.UserControl
    {
        private decimal price = 0;
        public MasterControl()
        {
            InitializeComponent();
            totalPrice.Content = "0";
        }

        private void createPrintTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var random = new Random();
                var randomnumber = random.Next(100000, 999999);
                POSPrinter.Printer.GiftItems("ITherm280", randomnumber.ToString());
                price += 15;
                totalPrice.Content = price.ToString("#.00");
            }
            catch (Exception ex)
            {
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            price = 0;
            totalPrice.Content = price.ToString("0");
        }
    }
}
