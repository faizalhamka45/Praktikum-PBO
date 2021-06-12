using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace BeHealth_eApp
{
    public partial class MainPage : ContentPage
    {
        private object Gender;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          
        }

        private async void btnDataSet_Clicked(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            db.CreateTable<UserTable>();
            var item = new UserTable()
            {
                Name = etrName.Text,
                BodyWeight = (float)Math.Round(float.Parse(etrBodyWeight.Text), 1),
                BodyHeight = (float)Math.Round(float.Parse(etrBodyHeight.Text), 1),
                IMT = (float)Math.Round(float.Parse(etrBodyWeight.Text) / (float.Parse(etrBodyHeight.Text) * 0.0001 * float.Parse(etrBodyHeight.Text)), 2),
                Gender = (string)pkrGender.SelectedItem,
            };
            db.Insert(item);

            await Navigation.PushAsync(new TabbedPage1());
        }

    
    }
}
