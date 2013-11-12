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
using MatchLeads.Model.DataContracts;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace MatchLeads.View
{
    public partial class ProfileSettings : PhoneApplicationPage
    {

        //List<bind> bindCountryList = new List<bind>();
        //List<bind> bindStateList = new List<bind>();
        //List<BLStates> stateList = new List<BLStates>();
        //long countryID = 0;
        //BackgroundWorker countryWorker = new BackgroundWorker() { WorkerSupportsCancellation = true };
       
        public ProfileSettings()
        {
            InitializeComponent();
            //countryWorker.DoWork += new DoWorkEventHandler(countryWorker_DoWork);
            //countryWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(countryWorker_RunWorkerCompleted);

        }



        private void countryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //LBCountry.ItemsSource = bindCountryList;
        }

        //private void countryWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(() =>
        //        {
        //            List<BlCountry> countryList = DbHelper.getCountryList();
        //            stateList = DbHelper.getStatesList();
        //            foreach (var item in countryList)
        //            {
        //                bind bindobj = new bind();
        //                bindobj.Id = item.Id;
        //                bindobj.Name = item.Name;
        //                bindobj.pageWidth = this.ActualWidth;

        //                bindCountryList.Add(bindobj);
        //            }
        //        });
        //}



        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            fillUserProfile(GlobalValues.globalUserProfile);
            //countryWorker.RunWorkerAsync();
        }

        private void fillUserProfile(userProfile upValues)
        {
            if (string.IsNullOrEmpty(upValues.FirstName))
            {
                tbFirstName.Text = "First Name";
                tbFirstName.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
            else
            {
                tbFirstName.Text = upValues.FirstName;
                tbFirstName.Foreground = new SolidColorBrush(Colors.Black);
            }

            if (string.IsNullOrEmpty(upValues.LastName))
            {
                tbLastName.Text = "Last Name";
                tbLastName.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
            else
            {
                tbLastName.Text = upValues.LastName;
                tbLastName.Foreground = new SolidColorBrush(Colors.Black);
            }

            tbEmail.Text = string.IsNullOrEmpty(upValues.Email) ? "" : upValues.Email;
            tbPhone.Text = string.IsNullOrEmpty(upValues.PhoneNo) ? "" : upValues.PhoneNo;
            tbCompany.Text = string.IsNullOrEmpty(upValues.Company) ? "" : upValues.Company;


            if (!string.IsNullOrEmpty(GlobalValues.BlCountry))
            {
                tbCountry.Text = GlobalValues.BlCountry;
                //txtCountry.Tag = BoothLeadGlobalAccess.BlCountryIndex;                        
            }
            else if (string.IsNullOrEmpty(GlobalValues.BlCountry))
            {
                if (upValues.Country != null)
                {
                    tbCountry.Text = upValues.Country;
                }
            }

            if (!string.IsNullOrEmpty(GlobalValues.BlState))
            {
                tbState.Text = GlobalValues.BlState;
            }
            else if (string.IsNullOrEmpty(GlobalValues.BlState))
            {
                if (upValues.State != null)
                {
                    tbState.Text = upValues.State;
                }
            }

           // tbCountry.Text = string.IsNullOrEmpty(upValues.Country) ? "" : upValues.Country;
           // tbState.Text = string.IsNullOrWhiteSpace(upValues.State) ? "" : upValues.State;
            tbCity.Text = string.IsNullOrWhiteSpace(upValues.City) ? "" : upValues.City;


            imgUserProfilePic.Source = new BitmapImage(new Uri(upValues.ImageUrl, UriKind.RelativeOrAbsolute));
        }


        private void tbFirstName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbFirstName.Text == "First Name")
            {
                tbFirstName.Text = "";
                tbFirstName.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbLastName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tbLastName.Text == "Last Name")
            {
                tbLastName.Text = "";
                tbLastName.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbFirstName_LostFocus(object sender, RoutedEventArgs e)
        {

            if (tbFirstName.Text.Trim().Length <= 0)
            {
                tbFirstName.Text = "First Name";
                tbFirstName.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void tbLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbLastName.Text.Trim().Length <= 0)
            {
                tbLastName.Text = "Last Name";
                tbLastName.Foreground = new SolidColorBrush(Color.FromArgb(255, 166, 166, 166));
            }
        }

        private void hyperlinkReSetPwd_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to Reset Password Page
            Dispatcher.BeginInvoke(() =>
                {
                    NavigationService.Navigate(new Uri("/View/UserReSetPwd.xaml", UriKind.RelativeOrAbsolute));
                });
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Collapsed;
            btnSaveDisable.Visibility = Visibility.Visible;

            //call user profile saving service 


        }

        private void tbCountry_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //recPageDisable.Visibility = Visibility.Visible;
            //borderCountry.Visibility = Visibility.Visible;

            NavigationService.Navigate(new Uri("/View/MLCountiesAndStates.xaml?navi=country", UriKind.Relative));
        }

        //private void LBCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (LBCountry.SelectedIndex == -1)
        //    {
        //        return;
        //    }
        //    Dispatcher.BeginInvoke(() =>
        //        {
        //            bind bindCountryObj = (sender as ListBox).SelectedItem as bind;
        //            countryID = bindCountryObj.Id;
        //            tbCountry.Text = bindCountryObj.Name;
        //            hideLbCountry();

        //            LBCountry.SelectedIndex = -1;
        //        });
        //}

        //private void hideLbCountry()
        //{
        //    recPageDisable.Visibility = Visibility.Collapsed;
        //    borderCountry.Visibility = Visibility.Collapsed;            
        //}

        //private void RadioBtnCountry_Checked(object sender, RoutedEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(() =>
        //        {
        //            RadioButton radiobtnCountry = (sender as RadioButton);
                    
        //            tbCountry.Text = radiobtnCountry.CommandParameter.ToString();
        //            hideLbCountry();
        //        });
        //}


        //void stateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    LBState.ItemsSource = bindStateList;
        //}

        //void stateWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(() =>
        //        {
        //            List<BLStates> statesList = DbHelper.getStatesList(tbCountry.Text);
        //            foreach (var item in statesList)
        //            {
        //                bind bindStateObj = new bind();
        //                bindStateObj.Id = item.Id;
        //                bindStateObj.Name = item.Name;
        //                bindStateObj.pageWidth = this.ActualWidth;

        //                bindStateList.Add(bindStateObj);

        //            }
        //        });
        //}

        private void tbState_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //// stateWorker.RunWorkerAsync();
            //Dispatcher.BeginInvoke(() =>
            //    {
            //        if (bindStateList.Count > 0)
            //        {
            //            bindStateList.Clear();
            //        }
            //        stateList = DbHelper.getStatesList(countryID);
            //        foreach (var item in stateList)
            //        {
            //            bind bindStateObj = new bind();
            //            bindStateObj.Id = item.Id;
            //            bindStateObj.Name = item.Name;
            //            bindStateObj.pageWidth = this.ActualWidth;

            //            bindStateList.Add(bindStateObj);
            //        }

            //        //LBState.Items.Clear();
            //        LBState.ItemsSource = bindStateList;

            //        recPageDisable.Visibility = Visibility.Visible;
            //        borderState.Visibility = Visibility.Visible;
            //    });


            if (string.IsNullOrEmpty(tbCountry.Text) || tbCountry.Text.ToLower().Contains("none"))
            {
                MessageBox.Show("Please Select Country", "Required", MessageBoxButton.OK);
            }
            else if (!string.IsNullOrEmpty(tbCountry.Text) && !tbCountry.Text.ToLower().Contains("none"))
            {
                NavigationService.Navigate(new Uri("/View/MLCountiesAndStates.xaml?navi=state&selectCountry=" + tbCountry.Text, UriKind.Relative));
            }
        }

        //private void LBState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (LBState.SelectedIndex == -1)
        //    {
        //        return;
        //    }
        //    Dispatcher.BeginInvoke(() =>
        //        {
        //            bind stateobj = (sender as ListBox).SelectedItem as bind;
        //            tbState.Text = stateobj.Name;

        //            hideLBState();
        //            LBState.SelectedIndex = -1;
        //        });
        //}

        //private void RadioBtnState_Checked(object sender, RoutedEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(() =>
        //        {
        //            RadioButton radiobtnState = (sender as RadioButton);
        //            tbState.Text = radiobtnState.CommandParameter.ToString();

        //            hideLBState();
        //        });
        //}

        //private void hideLBState()
        //{
        //    recPageDisable.Visibility = Visibility.Collapsed;
        //    borderState.Visibility = Visibility.Collapsed;
        //}

    }


    //public class bind
    //{
    //    public long Id { get; set; }
    //    public string Name { get; set; }
    //    public double pageWidth { get; set; }
    //}
}