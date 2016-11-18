using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace AppMonitorWPF
{
    /// <summary>
    /// Interaction logic for winOptions.xaml
    /// </summary>
    public partial class winOptions : Window
    {
        public winOptions()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReadOptions();
        }

        private void ReadOptions()
        {
            minTimeLimitTextBox.Text = AppMonitorWPF.Properties.Settings.Default.MinTimeLimit.ToString();
            //
            if (AppMonitorWPF.Properties.Settings.Default.HiddenApps != null)
            {
                hiddenAppsListBox.Items.Clear();
                foreach (string happ in AppMonitorWPF.Properties.Settings.Default.HiddenApps)
                {
                    hiddenAppsListBox.Items.Add(happ);
                }
            }
        }

        private void SaveOptions()
        {
            try
            {
                AppMonitorWPF.Properties.Settings.Default.MinTimeLimit = Convert.ToInt32(minTimeLimitTextBox.Text);
                //
                ArrayList happs = new ArrayList();
                foreach (string happ in hiddenAppsListBox.Items)
                {
                    happs.Add(happ);
                }
                AppMonitorWPF.Properties.Settings.Default.HiddenApps = happs;
                //
                AppMonitorWPF.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SaveOptions();
            this.Close();
        }

        private void addAppButton_Click(object sender, RoutedEventArgs e)
        {
            winInputBox ib = new winInputBox();
            ib.ShowDialog();
            if (ib.DialogResult == true)
            {
                hiddenAppsListBox.Items.Add(ib.newValue);
            }
        }

        private void delAppButton_Click(object sender, RoutedEventArgs e)
        {
            if (hiddenAppsListBox.SelectedIndex >= 0)
            {
                hiddenAppsListBox.Items.RemoveAt(hiddenAppsListBox.SelectedIndex);
            }
        }
    }
}
