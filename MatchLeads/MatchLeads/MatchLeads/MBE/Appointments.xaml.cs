using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MatchLeads.MBE
{
    public partial class Appointments : PhoneApplicationPage
    {
        public Appointments()
        {
            InitializeComponent();
        }

       

        private void SPConfirmAppointmentTAB_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (LBConfirmedAppoints.Visibility == Visibility.Visible)
            {
                LBConfirmedAppoints.Visibility = Visibility.Collapsed;
            }
            else if (LBConfirmedAppoints.Visibility == Visibility.Collapsed)
            {
                LBConfirmedAppoints.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Missed Appointment");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Canceled Appointment");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rescheduled Appointment");
        }


    }
}