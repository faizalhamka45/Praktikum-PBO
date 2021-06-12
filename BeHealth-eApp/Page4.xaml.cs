using System;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeHealth_eApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {

        public Page4()
        {
            InitializeComponent();

        }

        private void btnMakan_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Alaram Minum", "Minumlah satu gelas Air dua jam sekali agar cairan dalam tubuhmu terpenuhi", 101, DateTime.Now.AddHours(2));
        }

    }
}