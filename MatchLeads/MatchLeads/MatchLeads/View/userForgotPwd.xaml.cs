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
using MatchLeads.Model;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace MatchLeads.View
{
    public partial class userForgotPwd : PhoneApplicationPage
    {
        public userForgotPwd()
        {
            InitializeComponent();
        }

        private void txtForgotpwd_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbForgotpwd.Text == "Email")
            {
                tbForgotpwd.Text = "";
                tbForgotpwd.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtForgotpwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbForgotpwd.Text.Trim().Length <= 0)
            {
                tbForgotpwd.Text = "Email";
                tbForgotpwd.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            btnSubmit.Visibility = Visibility.Collapsed;
            btnSubmitDisable.Visibility = Visibility.Visible;


            if (string.IsNullOrEmpty(GlobalValues.accessToken))
            {
                //Call Authorization service
                WebClient wc_Oauth = new WebClient();
                wc_Oauth.Headers["Accept"] = "application/json";
                wc_Oauth.UploadStringCompleted += wc_Oauth_UploadStringCompleted;
                wc_Oauth.UploadStringAsync(new Uri(MLServiceURLs.ML_OAuthUrl), "POST", string.Empty);
            }
            else if (!string.IsNullOrEmpty(GlobalValues.accessToken))
            {
                //call Forgot Password serivce
                callForgotPasswordService();
            }



        }

        private void callForgotPasswordService()
        {
            WebClient wbForgotPwd = new WebClient();
            string strForgotPwdUrl = string.Format(GlobalValues.serviceInstanceUrl + MLServiceURLs.ML_ForgotPasswordUrl, tbForgotpwd.Text);
            wbForgotPwd.Headers["Accept"] = "application/json";
            wbForgotPwd.Headers["Authorization"] = "OAuth " + GlobalValues.accessToken;
            wbForgotPwd.DownloadStringCompleted += wbForgotPwd_DownloadStringCompleted;
            wbForgotPwd.DownloadStringAsync(new Uri(strForgotPwdUrl));
        }

        void wbForgotPwd_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(e.Result));
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(ServiceResponse));
                ServiceResponse response = (ServiceResponse)obj.ReadObject(stream);

                tbMessage.Text = response.Message.ToString();
                recPageDisable.Visibility = Visibility.Visible;
                grdMessage.Visibility = Visibility.Visible;
            }


        }

        private void wc_Oauth_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                string response = e.Result;
                ServiceResponseParsing.OAuthResponseParsing(response);

                //call Forgot Password serivce
                callForgotPasswordService();
            }
        }

        private void btnWarningOK_Click(object sender, RoutedEventArgs e)
        {
            recPageDisable.Visibility = Visibility.Collapsed;
            grdMessage.Visibility = Visibility.Collapsed;
        }
    }
}