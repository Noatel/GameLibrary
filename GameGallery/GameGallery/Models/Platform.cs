﻿using System;
using GiantBomb.Api.Model; 

namespace GameGallery.Models
{
    public class Platform 
    {
            public int Id
            {
                get;
                set;
            }

            public string Aliases
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public string ApiDetailUrl
            {
                get;
                set;
            }

            public string SiteDetailUrl
            {
                get;
                set;
            }

            public string Abbreviation
            {
                get;
                set;
            }

            public DateTime DateAdded
            {
                get;
                set;
            }

            public DateTime DateLastUpdated
            {
                get;
                set;
            }

            public string Deck
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }

            public Image Image
            {
                get;
                set;
            }

            public int? InstallBase
            {
                get;
                set;
            }

            public bool OnlineSupport
            {
                get;
                set;
            }

            public decimal? OriginalPrice
            {
                get;
                set;
            }

            public DateTime? ReleaseDate
            {
                get;
                set;
            }
        }

}
