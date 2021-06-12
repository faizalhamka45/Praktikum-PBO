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
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Makanan()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            List<UserTable> usertablequery = db.Table<UserTable>().ToList();
            foreach (UserTable item in usertablequery)
            {
                if (item.IMT > 27)
                {
                    imgChocolate.Opacity = 0.2;
                    txtChocolate.Text = "Makanan ini tidak direkomendasikan untuk Anda";
                }
              
            };
        }
    }
}