using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeHealth_eApp
{
    public partial class App : Application
    {
        public static string FilePath { get; internal set; }
        public SQLiteConnection database;

        public App()
        {
            InitializeComponent();

            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            if (IsDataExists("UserTable") == true)
            {
                MainPage = new TabbedPage1();
            }
            else
            {
                MainPage = new MainPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private bool IsDataExists(string v)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user1.db");
            var db = new SQLiteConnection(dbpath);

            List<UserTable> usertablequery = db.Table<UserTable>().ToList();
            try
            {
                foreach(UserTable item in usertablequery)
                {
                    if(item.Name != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
