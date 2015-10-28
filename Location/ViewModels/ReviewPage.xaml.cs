﻿using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Location.DataModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Location
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReviewPage : Page
    {
        private ObservableCollection<DataPoint> ListPoint;
        private DatapointHelper dbHelper;
        public ReviewPage()
        {
            this.InitializeComponent();
            ListPoint = new ObservableCollection<DataPoint>();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var Id = e.Parameter as String;
            System.Diagnostics.Debug.WriteLine(Id);
            dbHelper = new DatapointHelper();
            ListPoint = dbHelper.ReadPointsOfBusLine(int.Parse(Id));
            listBox.ItemsSource = ListPoint;

        }
        private void appBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
