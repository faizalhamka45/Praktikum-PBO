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
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void SportLogic()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            List<UserTable> usertablequery = db.Table<UserTable>().ToList();
            foreach (UserTable item in usertablequery)
            {
                
                if (item.IMT <= 18.5)
                {
                    imgSkipping.Opacity = 0.2;
                    imgJogging.Opacity = 0.2;
                    txtSkipping.Text = "Olahraga ini tidak terlalu di rekomendasikan kepada anda";
                    txtJogging.Text = "Olahraga ini tidak terlalu di rekomendasikan kepada anda";
                }
            };
        }

    
    }
}