using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeHealth_eApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
        public Page5()
        {
            InitializeComponent();
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            List<UserTable> usertablequery = db.Table<UserTable>().ToList();
            var item = new UserTable()
            {
                Name = etrName.Text,
                BodyWeight = (float)Math.Round(float.Parse(etrBodyWeight.Text), 1),
                BodyHeight = (float)Math.Round(float.Parse(etrBodyHeight.Text), 1),
                IMT = (float)Math.Round(float.Parse(etrBodyWeight.Text) / (float.Parse(etrBodyHeight.Text) * float.Parse(etrBodyHeight.Text)), 2),
                
            };
            db.Update(item);
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            db.DeleteAll<UserTable>();
        }

        private void etrGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}