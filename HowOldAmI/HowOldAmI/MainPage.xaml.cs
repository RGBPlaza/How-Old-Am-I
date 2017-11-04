using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HowOldAmI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void DatePicker_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            // If a new date has been selected
            if (args.AddedDates.Count > 0)
            {
                DateTime selectedDate = args.AddedDates.First().Date;
                if (selectedDate.CompareTo(DateTime.Now.Date) < 0)                                                          // If the selected date is earlier than today,
                    Info.DateDifference = DateTime.Now.Date.Subtract(selectedDate);                                              // Calculate the date difference
                SubmitButton.IsEnabled = args.AddedDates.First().Date.CompareTo(DateTime.Now.Date) < 0 ? true : false;      // Enable the submit button or Disable if selected date is later
            }
            else                                                                                                            // If the date has been de-selected,
                SubmitButton.IsEnabled = false;                                                                             // Disable the submit button
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResultPage));
        }
    }

    public static class Info
    {
        public static TimeSpan DateDifference;
    }
}
