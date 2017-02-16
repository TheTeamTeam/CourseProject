﻿using System;
using CourseProject.Models;
using CourseProject.Web.EventArguments.Contracts;


namespace CourseProject.Web.EventArguments 
{
    public class BookAdEventArgs : EventArgs, IBookAdEventArgs
    {
        public BookAdEventArgs(string userId, Advertisement ad) //int count
        {
            this.Id = userId;
            this.Ad = ad;
           // this.Count = count;
        }

        public string Id { get; private set; }

        public Advertisement Ad { get; private set; }

       // public int Count { get; private set; }
    }
}