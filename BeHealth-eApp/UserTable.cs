using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BeHealth_eApp
{
    public class UserTable
    {
        public string Name { get; set; }
        public float BodyWeight { get; set; }
        public float BodyHeight { get; set; }
        public float IMT { get; set; }
        public string Gender { get; set; }
        public float BeratBadanIdeal { get; set; }
        public string IndeksIMT { get; set; }
    }
}
