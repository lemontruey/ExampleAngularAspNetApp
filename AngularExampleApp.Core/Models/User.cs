﻿namespace AngularExampleApp.Core.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime LastVisitDate { get; set; }
        //public UserType UserType { get; set; }
    }
}
