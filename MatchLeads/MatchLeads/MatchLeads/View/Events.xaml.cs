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
using System.Windows.Media.Imaging;

namespace MatchLeads.View
{
    public partial class Events : PhoneApplicationPage
    {
        public Events()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            loadEventsList();
            Dispatcher.BeginInvoke(() =>
                {
                    LBEventList.SelectedIndex = 0;
                });
        }

        private void loadEventsList()
        {
            if (GlobalValues.globalEventDetails.Count > 0)
            {
                List<eventsBinding> eventsBindingList = new List<eventsBinding>();

                var enumerator = GlobalValues.globalEventDetails.GetEnumerator();
                bool firstRBflag = false;
                while (enumerator.MoveNext())
                {
                    eventsBinding eventBindObj = new eventsBinding();
                    var currentElement = enumerator.Current;

                    eventBindObj.Event_ID = string.IsNullOrEmpty(currentElement.Event_ID) ? "" : currentElement.Event_ID;
                    eventBindObj.Event_Name = string.IsNullOrEmpty(currentElement.Event_Name) ? "" : currentElement.Event_Name;
                    eventBindObj.EventLogoImageURL = string.IsNullOrEmpty(currentElement.EventLogoImageURL) ? "" : currentElement.EventLogoImageURL;
                    if (firstRBflag == false)
                    {
                        eventBindObj.IsCheck = true;
                        firstRBflag = true;
                    }
                    else if (firstRBflag == true)
                    {
                        eventBindObj.IsCheck = false;
                    }

                    eventBindObj.pageWidth = this.ActualWidth;
                    eventsBindingList.Add(eventBindObj);
                }

                LBEventList.ItemsSource = eventsBindingList;
            }
        }

        bool eventsListFlag = false;
        private void spEvents_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (eventsListFlag == false)
            {
                eventsListFlag = true;
                LBEventList.Visibility = Visibility.Visible;
            }
            else if (eventsListFlag == true)
            {
                eventsListFlag = false;
                LBEventList.Visibility = Visibility.Collapsed;
            }
        }

        private void LBEventList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBEventList.SelectedIndex == -1)
            {
                return;
            }
            eventsBinding selectedItem = (sender as ListBox).SelectedItem as eventsBinding;

            filterEventBasedOnSelectedItem(selectedItem.Event_ID);
            LBEventList.SelectedIndex = -1;
        }

        private void filterEventBasedOnSelectedItem(string eventId)
        {
            foreach (var item in GlobalValues.globalEventDetails)
            {
                if (item.Event_ID == eventId)
                {
                    bindEventDetails(item);
                    break;
                }
            }
        }

        private void bindEventDetails(Model.DataContracts.MMeventDetails eventDetails)
        {
            tbEventName.Text = string.IsNullOrEmpty(eventDetails.Event_Name) ? "" : eventDetails.Event_Name;
            tbEventStatus.Text = string.IsNullOrEmpty(eventDetails.Status) ? "" : eventDetails.Status;
            tbEventStartDate.Text = string.IsNullOrEmpty(eventDetails.Event_StartDate) ? "" : "Start : " + eventDetails.Event_StartDate;
            tbEventEndDate.Text = string.IsNullOrEmpty(eventDetails.Event_Date) ? "" : "End : " + eventDetails.Event_Date;
            tbEventPhone.Text = string.IsNullOrEmpty(eventDetails.HostingPhone) ? "" : eventDetails.HostingPhone;
            tbEventAddress.Text = string.IsNullOrEmpty(eventDetails.HostingAddr1) ? (string.IsNullOrEmpty(eventDetails.HostingAddr2) ? "" : eventDetails.HostingAddr2) : eventDetails.HostingAddr1;
            tbEventDescription.Text = string.IsNullOrEmpty(eventDetails.Event_Description) ? "" : "    " + eventDetails.Event_Description;
            if (!string.IsNullOrEmpty(eventDetails.EventLogoImageURL))
            {
                imgEventLogo.Source = new BitmapImage(new Uri(eventDetails.EventLogoImageURL, UriKind.RelativeOrAbsolute));
            }
        }


    }

    public class eventsBinding
    {
        public string Event_ID { get; set; }
        public string Event_Name { get; set; }
        public string EventLogoImageURL { get; set; }
        public bool IsCheck { get; set; }
        public double pageWidth { get; set; }
    }
}