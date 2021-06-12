using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Java.Util.Jar.Attributes;

namespace BeHealth_eApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public SQLiteConnection database;
        public Page1()
        {
            InitializeComponent();
            Data_page1();
            
        }

        private void Data_page1()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            List<UserTable> usertablequery = db.Table<UserTable>().ToList();
            foreach(UserTable item in usertablequery)
            {
                lblUsername.Text = "Halo " + item.Name;
                lblBerat_Badan.Text = item.BodyWeight.ToString();
                lblTinggi_Badan.Text = (item.BodyHeight).ToString();
                lblIMT.Text = item.IMT.ToString();
                lblJenis_IMT.Text = CheckJenisIMT(item.IMT);
                CheckGender(item.Gender);
                BeratBadanIdealCalculation(item.BodyHeight, item.Gender);
                lblJenis_Diet.Text = JenisDietOption(lblJenis_IMT.Text);
                frameIMT.BackgroundColor = ChangeColorIMT(lblJenis_IMT.Text);
            }
            
        }

        private Color ChangeColorIMT(string text)
        {
            if (text == "Obesitas" || text == "Underweight")
            {
                return Color.Red;
            }
            else if(text == "Overweight")
            {
                return Color.Yellow;
            }
            else
            {
                return Color.Green;
            }
        }

        private string JenisDietOption(string text)
        {
            if(text == "Obesitas" || text == "Overweight")
            {
                return "Menurunkan";
            }
            else if(text == "Underweight")
            {
                return "Menaikkan";
            }
            else
            {
                return "Menjaga";
            }
        }

        private void BeratBadanIdealCalculation(float bodyHeight, string gender)
        {
            if(gender == "laki-laki")
            {
                lblBeratBadanIdeal.Text = (bodyHeight - 100 - ((bodyHeight - 100) * 0.1)).ToString();
            }
            else
            {
                lblBeratBadanIdeal.Text = Math.Round((bodyHeight - 100 - ((bodyHeight - 100) * 0.15)), 2).ToString();
            }
        }

        private void CheckGender(string gender)
        {
            if(gender == "laki-laki")
            {
                imgMale.Opacity = 1;
            }
            else
            {
                imgFemale.Opacity = 1;
            }
        }

        private string CheckJenisIMT(float iMT)
        {
            if (iMT > 27)
            {
                return "Obesitas";
            }
            else if (iMT > 25.1)
            {
                return "Overweight";
            }
            else if (iMT > 18.5)
            {
                return "Normal";

            }
            else if (iMT <= 18.5)
            {
                return "Underweight";
            }

            return "-";
        }
    }
}