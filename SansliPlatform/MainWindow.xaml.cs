using MahApps.Metro.Controls;
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

namespace SansliPlatform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] != null && e.AddedItems[0].GetType() != null)
            {
                var isType = e.AddedItems[0].GetType().Name == "TabItem";
                if (isType)
                {
                    var ttt2 = (System.Windows.Controls.TabItem)e.AddedItems[0];
                    var ttt = (MahApps.Metro.Controls.MetroTabControl)sender;
                    foreach (System.Windows.Controls.TabItem item in ttt.Items)
                    {
                        if (item == ttt2)
                        {
                            item.BorderThickness = new Thickness(0, 8, 0, 0);
                        }
                        else
                        {
                            item.BorderThickness = new Thickness(0, 0, 0, 0);
                        }
                    }
                }
            }
        }
    }
}
