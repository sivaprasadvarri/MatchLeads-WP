using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MatchLeads.UserControls;

namespace MatchLeads.MBE
{
    public partial class CorporateSearch : PhoneApplicationPage
    {
        public CorporateSearch()
        {
            InitializeComponent();           
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void tbAllCorporate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbAllCorporate.Text == "Corporate Search")
            {
                tbAllCorporate.Text = "";
                tbAllCorporate.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbAllCorporate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbAllCorporate.Text.Trim().Length <= 0)
            {
                tbAllCorporate.Text = "Corporate Search";
                tbAllCorporate.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void tbIndustry_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbIndustry.Text == "Industry Search")
            {
                tbIndustry.Text = "";
                tbIndustry.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbIndustry_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbIndustry.Text.Trim().Length <= 0)
            {
                tbIndustry.Text = "Industry Search";
                tbIndustry.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void tbCompany_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbCompany.Text == "Company Search")
            {
                tbCompany.Text = "";
                tbCompany.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbCompany_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbCompany.Text.Trim().Length <= 0)
            {
                tbCompany.Text = "Company Search";
                tbCompany.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void tbNAICS_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbNAICS.Text == "NAICS Search")
            {
                tbNAICS.Text = "";
                tbNAICS.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbNAICS_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbNAICS.Text.Trim().Length <= 0)
            {
                tbNAICS.Text = "NAICS Search";
                tbNAICS.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void LBAllCorporate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
                {
                    NavigationService.Navigate(new Uri("/MBE/CorporateDetails.xaml", UriKind.Relative));
                });
        }

       
    }
}