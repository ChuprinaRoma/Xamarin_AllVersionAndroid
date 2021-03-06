﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VersionAndroid.DAO.Models
{
    [Table("Androids")]
    public class AndroidTable
    {
        [PrimaryKey]
        public int Id             { get; set; }

        public string FullName    { get; set; }

        public string Name        { get; set; }

        public string ReleaseDate { get; set; }

        public string Version     { get; set; }

        public string WhatsNew    { get; set; }
    }
}
