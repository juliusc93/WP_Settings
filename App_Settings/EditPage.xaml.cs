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
    public partial class EditPage : PhoneApplicationPage
    {
        public IsolatedStorageSettings appSettings;
        public EditPage()
        {
            InitializeComponent();
            appSettings = IsolatedStorageSettings.ApplicationSettings;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                txtName.Text = appSettings["name"].ToString();
                txtAge.Text = appSettings["age"].ToString();
                rbtnMale.IsChecked = (bool)appSettings["male"];
                rbtnFemale.IsChecked = (bool)appSettings["female"];
            }
            catch (Exception)
            {
                appSettings.Add("name", txtName.Text);
                appSettings.Add("age", txtAge.Text);
                appSettings.Add("male", rbtnMale.IsChecked);
                appSettings.Add("female", rbtnFemale.IsChecked);
                appSettings.Save();
            }
        }

        private void btnSave_Tap(object sender, GestureEventArgs e)
        {
            appSettings["name"] = txtName.Text;
            appSettings["age"] = txtAge.Text;
            appSettings["male"] = rbtnMale.IsChecked;
            appSettings["female"] = rbtnFemale.IsChecked;
            appSettings.Save();

            //Go back to the Main Page
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
        
    }
}