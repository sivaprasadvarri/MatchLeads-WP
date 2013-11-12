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
using MatchLeads.Model;

namespace MatchLeads
{
    public partial class Login : PhoneApplicationPage
    {
        // Constructor
        public Login()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {           
            btnLogin.Visibility = Visibility.Visible;
            btnLoginDisable.Visibility = Visibility.Collapsed;
        }

        private void hyperlinkSignUp_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
                {
                    NavigationService.Navigate(new Uri("/Register.xaml", UriKind.Relative));
                });
        }

        private void tbEmail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Text = "";
                tbEmail.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text.Trim().Length <= 0)
            {
                tbEmail.Text = "Email";
                tbEmail.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void pbPwd_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (pbPwd.Password == "vspwd")
            {
                pbPwd.Password = "";
                pbPwd.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void pbPwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pbPwd.Password.Trim().Length <= 0)
            {
                pbPwd.Password = "vspwd";
                pbPwd.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            btnLoginDisable.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Collapsed;
            CustprogressBar.Visibility = Visibility.Visible;

            //Call Authorization service
            WebClient wc_Oauth = new WebClient();
            wc_Oauth.Headers["Accept"] = "application/json";
            wc_Oauth.UploadStringCompleted += wc_Oauth_UploadStringCompleted;
            wc_Oauth.UploadStringAsync(new Uri(MLServiceURLs.ML_OAuthUrl), "POST", string.Empty);
        }

        void wc_Oauth_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                string response = e.Result;
                ServiceResponseParsing.OAuthResponseParsing(response);

                // Login service
                WebClient wbLogin = new WebClient();
                string loginServiceUrl = string.Format(GlobalValues.serviceInstanceUrl + MLServiceURLs.ML_LoginUrl, tbEmail.Text, pbPwd.Password);
                wbLogin.UploadStringCompleted += wbLogin_UploadStringCompleted;
                wbLogin.Headers["Accept"] = "application/json";
                wbLogin.Headers["Authorization"] = "OAuth " + GlobalValues.accessToken;
                wbLogin.UploadStringAsync(new Uri(loginServiceUrl), "POST", string.Empty);

            }
        }

        void wbLogin_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                bool IsValidUser = ServiceResponseParsing.LoginResponseParsing(e.Result);
                if (IsValidUser == false)
                {
                    MessageBox.Show("Invalid credentials");
                }
                else if (IsValidUser == true)
                {
                    CustprogressBar.Visibility = Visibility.Collapsed;
                    //Navigate to Appointments
                    Dispatcher.BeginInvoke(() =>
                    {
                        NavigationService.Navigate(new Uri("/MBE/Appointments.xaml", UriKind.Relative));
                    });
                }
            }
        }

        private void hyperlinkForgotPWD_Click(object sender, RoutedEventArgs e)
        {
            //Navigate Forgot Password page
            Dispatcher.BeginInvoke(() =>
                {
                    NavigationService.Navigate(new Uri("/View/userForgotPwd.xaml", UriKind.RelativeOrAbsolute));
                });
        }

      

    }
}