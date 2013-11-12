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
using System.Diagnostics;

namespace MatchLeads.View
{
    public partial class MLCountiesAndStates : PhoneApplicationPage
    {
        string strQueryValue = string.Empty;
        string strSelectCountry = string.Empty;
        public MLCountiesAndStates()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.Keys.Contains("navi"))
            {
                if (NavigationContext.QueryString.TryGetValue("navi", out strQueryValue))
                {
                }
            }

            if (NavigationContext.QueryString.Keys.Contains("selectCountry"))
            {
                if (NavigationContext.QueryString.TryGetValue("selectCountry", out strSelectCountry))
                {
                }
            }
            base.OnNavigatedTo(e);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (strQueryValue == "country")
            {
                ApplicationTitle.Text = "CHOOSE COUNTRY";
                ////Get country list
                List<BlCountry> listCountries = DbHelper.getCountryList();

                List<bind> bindCountryList = new List<bind>();
                foreach (var item in listCountries)
                {
                    bind bindCountryObj = new bind();
                    bindCountryObj.Id = item.Id;
                    bindCountryObj.Name = item.Name;
                    bindCountryObj.pageWidth = this.ActualWidth;

                    bindCountryList.Add(bindCountryObj);
                }

                BLlistboxCountry.ItemsSource = bindCountryList;
                BLlistboxCountry.Visibility = Visibility.Visible;
            }

            if (strQueryValue == "state")
            {
                ApplicationTitle.Text = "CHOOSE STATE";
                //Get state list
                List<BLStates> listStates = DbHelper.getStatesList(strSelectCountry);

                List<bind> bindStatesList = new List<bind>();
                foreach (var item in listStates)
                {
                    bind bindStatesObj = new bind();
                    bindStatesObj.Id = item.Id;
                    bindStatesObj.Name = item.Name;
                    bindStatesObj.pageWidth = this.ActualWidth;

                    bindStatesList.Add(bindStatesObj);

                }
                BLlistboxState.ItemsSource = bindStatesList;
                BLlistboxState.Visibility = Visibility.Visible;
            }
        }

        private void BLlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            bind selectedCountry = (bind)BLlistboxCountry.SelectedItem;
            GlobalValues.BlCountry = selectedCountry.Name;
            GlobalValues.BlCountryIndex = selectedCountry.Id.ToString();
            List<BLStates> listStates = DbHelper.getStatesList(selectedCountry.Name);
            foreach (var item in listStates)
            {
                BLStates firstItem = item;
                GlobalValues.BlState = firstItem.Name;
                NavigationService.Navigate(new Uri("/View/ProfileSettings.xaml", UriKind.Relative));
                return;
            }



        }

        private void BLlistboxState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            bind selectedState = (bind)BLlistboxState.SelectedItem;
            GlobalValues.BlState = selectedState.Name;
            NavigationService.Navigate(new Uri("/View/ProfileSettings.xaml", UriKind.Relative));

        }

    }


    public class bind
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double pageWidth { get; set; }
    }

}