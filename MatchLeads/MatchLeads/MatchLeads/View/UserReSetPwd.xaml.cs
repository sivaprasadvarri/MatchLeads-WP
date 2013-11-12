using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace MatchLeads.View
{
    public partial class UserReSetPwd : PhoneApplicationPage
    {
        public UserReSetPwd()
        {
            InitializeComponent();
        }

       

        private void txtNewpwd_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbNewpwd.Text == "New Password")
            {
                tbNewpwd.Text = "";
                tbNewpwd.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtNewpwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbNewpwd.Text.Trim().Length <= 0)
            {
                tbNewpwd.Text = "New Password";
                tbNewpwd.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void txtOldpwd_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbOldpwd.Text == "Current Password")
            {
                tbOldpwd.Text = "";
                tbOldpwd.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtOldpwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbOldpwd.Text.Trim().Length <= 0)
            {
                tbOldpwd.Text = "Current Password";
                tbOldpwd.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            btnSubmit.Visibility = Visibility.Collapsed;
            btnSubmitDisable.Visibility = Visibility.Visible;

            //call Reset Password service

        }
    }
}