using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MatchLeads.UserControls
{
    public partial class MLFooter : UserControl
    {
        public MLFooter()
        {
            InitializeComponent();
        }



        //public static readonly DependencyProperty CustomEnableProperty = DependencyProperty.Register("CustomEnableValue", typeof(Visibility), typeof(MLFooter), new PropertyMetadata(""));

        //public Visibility CustomEnableValue
        //{
        //    get
        //    {
        //        return (Visibility) GetValue(CustomEnableProperty);
        //    }
        //    set
        //    {
        //        SetValue(CustomEnableProperty, value);
        //    }
        //}


        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    CustomEnableValue = Visibility.Collapsed;
        //}


        private void SPAppointments_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                (App.Current.RootVisual as PhoneApplicationFrame).Navigate(
                                         new Uri("/MBE/Appointments.xaml", UriKind.Relative));
                DisableRemaingTabsExAppointment();
            }); 
           
        }

        private void DisableRemaingTabsExAppointment()
        {

            SPAppointmentsClick.Visibility = Visibility.Visible;
            SPAppointments.Visibility = Visibility.Collapsed;
            SPSearchClick.Visibility = Visibility.Collapsed;
            SPSearch.Visibility = Visibility.Visible;
            SPSettingsClick.Visibility = Visibility.Collapsed;
            SPSettings.Visibility = Visibility.Visible;
            SPEventsClick.Visibility = Visibility.Collapsed;
            SPEvents.Visibility = Visibility.Visible;
        }


        private void SPSearch_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                (App.Current.RootVisual as PhoneApplicationFrame).Navigate(
                                         new Uri("/MBE/CorporateSearch.xaml", UriKind.Relative));
                DisableRemaingTabsExSearch();
            }); 
        }

        public void DisableRemaingTabsExSearch()
        {

            SPAppointmentsClick.Visibility = Visibility.Collapsed;
            SPAppointments.Visibility = Visibility.Visible;
            SPSearchClick.Visibility = Visibility.Visible;
            SPSearch.Visibility = Visibility.Collapsed;
            SPSettingsClick.Visibility = Visibility.Collapsed;
            SPSettings.Visibility = Visibility.Visible;
            SPEventsClick.Visibility = Visibility.Collapsed;
            SPEvents.Visibility = Visibility.Visible;
        }



        private void SPSettings_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                (App.Current.RootVisual as PhoneApplicationFrame).Navigate(
                                         new Uri("/View/ProfileSettings.xaml", UriKind.Relative));
                DisableRemaingTabsExSettings();
            }); 
            
        }

        private void DisableRemaingTabsExSettings()
        {
            SPAppointmentsClick.Visibility = Visibility.Collapsed;
            SPAppointments.Visibility = Visibility.Visible;
            SPSearchClick.Visibility = Visibility.Collapsed;
            SPSearch.Visibility = Visibility.Visible;
            SPSettingsClick.Visibility = Visibility.Visible;
            SPSettings.Visibility = Visibility.Collapsed;
            SPEventsClick.Visibility = Visibility.Collapsed;
            SPEvents.Visibility = Visibility.Visible;
        }


        private void SPEvents_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                (App.Current.RootVisual as PhoneApplicationFrame).Navigate(
                                         new Uri("/View/Events.xaml", UriKind.Relative));
                DisableRemaingTabsExEvents();
            }); 
            
        }

        private void DisableRemaingTabsExEvents()
        {
            SPAppointmentsClick.Visibility = Visibility.Collapsed;
            SPAppointments.Visibility = Visibility.Visible;
            SPSearchClick.Visibility = Visibility.Collapsed;
            SPSearch.Visibility = Visibility.Visible;
            SPSettingsClick.Visibility = Visibility.Collapsed;
            SPSettings.Visibility = Visibility.Visible;
            SPEventsClick.Visibility = Visibility.Visible;
            SPEvents.Visibility = Visibility.Collapsed;

        }

       

    }
}
