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
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            this.Loaded += SettingsControl_Loaded;
        }

        private void SettingsControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbButtonRight.SelectedIndex = Properties.Settings.Default.Game_Button_Right;
        }

        private void cmbButtonRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbButtonRight.SelectedIndex >= 0)
            {
                Properties.Settings.Default.Game_Button_Right = cmbButtonRight.SelectedIndex;
                Properties.Settings.Default.Save();
            }
        }
    }
}
