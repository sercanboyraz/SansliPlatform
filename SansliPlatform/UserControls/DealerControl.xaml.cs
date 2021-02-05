using SansliPlatform.Models;
using System;
using System.Collections.Generic;
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

namespace SansliPlatform.UserControls
{
    /// <summary>
    /// Interaction logic for DealerControl.xaml
    /// </summary>
    public partial class DealerControl : UserControl
    {
        //public List<DealerExpenseDto> DealerExpenses { get; set; }
        public DealersDto DealersDto { get; set; }
        public DealerControl()
        {
            InitializeComponent();
            this.Loaded += DealerControl_Loaded;
            //DealerExpenses = new List<DealerExpenseDto>();
        }

        private void DealerControl_Loaded(object sender, RoutedEventArgs e)
        {
            var ttt = new List<DealerExpenseDto>();
            var rnd1 = new Random();
            var rnd2 = new Random();
            for (int i = 1; i < 10; i++)
            {
                var rnd11 = rnd1.Next(3000, 9000);
                var rnd22 = rnd2.Next(500, 2000);
                var datetime = DateTime.Now;
                datetime = datetime.AddDays((i - (i + i)));
                DealerExpenseDto dealerExpenseDto = new DealerExpenseDto();
                dealerExpenseDto.Id = i;
                dealerExpenseDto.Name = "Sercan Boyraz";
                dealerExpenseDto.TotalPrice = rnd11.ToString("0#,##")+" ₺";
                dealerExpenseDto.DealerPrice = rnd22.ToString("0#,##")+ " ₺";
                dealerExpenseDto.ExpenseDate = datetime.ToShortDateString();
                ttt.Add(dealerExpenseDto);
            }
            dealerGrd.ItemsSource = ttt;

            DealersDto = new DealersDto()
            {
                Address = "İstasyon Mah. 2312. Sok. 4/3 Etimesgut/Ankara",
                DealerCode = 185265,
                DeviceId = 546513213,
                Id = 1,
                Name = "Sercan",
                Surname = "Boyraz",
                PhoneNumber = "5415665446"
            };
        }
    }
}
