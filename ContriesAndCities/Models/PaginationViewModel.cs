﻿namespace ContriesAndCities.Models
{
    using System;

    public class PaginationViewModel
    {
        public int FirstPage = 1;

        public int PageNumber { get; set; }

        public int ItemsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage);

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public string ActionName { get; set; }
    }
}
