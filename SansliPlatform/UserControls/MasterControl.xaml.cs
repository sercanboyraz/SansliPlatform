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
        private Font printFont;
        private StreamReader streamToPrint;
        public MasterControl()
        {
            InitializeComponent();
        }

        private void createPrintTicket_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var randomnumber = random.Next(100000, 999999);
            SansliPlatform.POSPrinter.Printer.GiftItems("ITherm280", randomnumber.ToString());
        }
    }
}
