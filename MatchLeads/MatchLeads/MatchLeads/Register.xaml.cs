using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MatchLeads.Model;
using System.Windows.Media;


namespace MatchLeads
{
    public partial class Register : PhoneApplicationPage
    {
        string UserType = string.Empty;
        public Register()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
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

                // Call Register Service
                WebClient wc_Register = new WebClient();
                string strRegisterUrl = string.Format(GlobalValues.serviceInstanceUrl + MLServiceURLs.ML_RegisterUrl, tbEmail.Text, tbPwd.Password, UserType);
                wc_Register.Headers["Authorization"] = "OAuth " + GlobalValues.accessToken;
                wc_Register.Headers["Accept"] = "application/json";
                wc_Register.UploadStringCompleted += wc_Register_UploadStringCompleted;
                wc_Register.UploadStringAsync(new Uri(strRegisterUrl), "POST", string.Empty);

            }


        }

        void wc_Register_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                string IsRegisterStatus = ServiceResponseParsing.RegisterParsing(e.Result);

                if (IsRegisterStatus == "You have already signed up!")
                {
                    MessageBox.Show("You have already signed up!");
                }
                else if (IsRegisterStatus != "You have already signed up!")
                {
                    MessageBox.Show("sucess");
                }
            }
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

        private void tbPwd_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbPwd.Password == "vspwd")
            {
                tbPwd.Password = "";
                tbPwd.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbPwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPwd.Password.Trim().Length <= 0)
            {
                tbPwd.Password = "vspwd";
                tbPwd.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            UserType = rb.Content.ToString();
            if (UserType == "Corporate")
            {
                recPageDisable.Visibility = Visibility.Visible;
                grdCorporateAlert.Visibility = Visibility.Visible;
            }
        }

        private void btnCorporateAlertOK_Click(object sender, RoutedEventArgs e)
        {
            recPageDisable.Visibility = Visibility.Collapsed;
            grdCorporateAlert.Visibility = Visibility.Collapsed;
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}