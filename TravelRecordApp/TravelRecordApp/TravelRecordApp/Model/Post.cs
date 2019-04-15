﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string Address { get; set; }

        public double latitude { get; set; }

        public double longitud { get; set; }

        public int Distance { get; set; }

        public string userId { get; set; }

    }
}
