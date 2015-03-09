using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace App_Settings
{
    public partial class MainPage : PhoneApplicationPage
    {
        public IsolatedStorageSettings appSettings;
        public MainPage()
        {
            InitializeComponent();
            appSettings = IsolatedStorageSettings.ApplicationSettings;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(appSettings["name"].ToString())) txtName.Text = "Not assigned";
                else txtName.Text = appSettings["name"].ToString();
                if (String.IsNullOrWhiteSpace(appSettings["age"].ToString())) txtAge.Text = "Not assigned";
                else txtAge.Text = appSettings["age"].ToString();
                if ((bool)appSettings["male"]) txtGender.Text = "Male";
                else if ((bool)appSettings["female"]) txtGender.Text = "Female";
                else txtGender.Text = "Not assigned";
            }
            catch (Exception)
            {
                appSettings.Add("name", "");
                appSettings.Add("age", "");
                appSettings.Add("male", false);
                appSettings.Add("female", false);
                appSettings.Save();
            }
        }

        private void btnEdit_Tap(object sender, GestureEventArgs e)
        {
            //Go to the Edit Page
            NavigationService.Navigate(new Uri("/EditPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}