using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HowOldAmI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultPage : Page
    {
        public ResultPage()
        {
            this.InitializeComponent();

            // GUI Stuff
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += (ev, x) => { if (Frame.CanGoBack) Frame.GoBack(); };
            SizeChanged += (s, e) => ValuesStackPanel.Orientation = e.NewSize.Height >= e.NewSize.Width ? Orientation.Vertical : Orientation.Horizontal;
            Transitions = new Windows.UI.Xaml.Media.Animation.TransitionCollection() { new Windows.UI.Xaml.Media.Animation.NavigationThemeTransition() };

            // Calculate rough number of years
            int years = (int)Math.Floor(Info.DateDifference.TotalDays / 365.2425);
            // Calculate rough number of residual months
            int months = (int)Math.Floor((Info.DateDifference.TotalDays % 365.25) / 30.4375);
            // Calculate rough number of residual days
            int days = (int)Math.Floor((Info.DateDifference.TotalDays % 365.25) % 30.4375);

            // Display Information Appropriately
            YearsTextBlock.Text = years == 1 ? $"{years.ToString()} Year," : $"{years.ToString()} Years,";
            MonthsTextBlock.Text = months == 1 ? $"{months.ToString()} Month," : $"{months.ToString()} Months,";
            DaysTextBlock.Text = days == 1 ? $"{days.ToString()} Day" : $"{days.ToString()} Days";
        }
    }
}
