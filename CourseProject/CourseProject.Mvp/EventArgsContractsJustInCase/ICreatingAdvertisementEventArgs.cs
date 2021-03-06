﻿using System;
using System.Web;

namespace CourseProject.Mvp.EventArgsContracts
{
    public interface ICreatingAdvertisementEventArgs
    {
        int CategoryId { get; }

        int CityId { get; }

        string Description { get; }

        DateTime ExpireDate { get; }

        HttpPostedFile Image { get; }

        string Name { get; }

        int Places { get; }

        decimal Price { get; }

        string SellerId { get; }
    }
}