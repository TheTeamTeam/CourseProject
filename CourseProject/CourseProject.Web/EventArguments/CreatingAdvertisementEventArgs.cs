﻿using System;
using System.Web;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class CreatingAdvertisementEventArgs : EventArgs, ICreatingAdvertisementEventArgs
    {
        public CreatingAdvertisementEventArgs(
                    string name,
                    string description,
                    int places,
                    decimal price,
                    DateTime expireDate,
                    HttpPostedFile image,
                    int cityId,
                    int categoryId,
                    string sellerId)
        {
            this.Name = name;
            this.Description = description;
            this.Places = places;
            this.Price = price;
            this.ExpireDate = expireDate;
            this.Image = image;
            this.CityId = cityId;
            this.CategoryId = categoryId;
            this.SellerId = sellerId;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Places { get; private set; }

        public decimal Price { get; private set; }

        public DateTime ExpireDate { get; private set; }

        public HttpPostedFile Image { get; private set; }

        public int CityId { get; private set; }

        public int CategoryId { get; private set; }

        public string SellerId { get; private set; }
    }
}