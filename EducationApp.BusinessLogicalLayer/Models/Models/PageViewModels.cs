using System;

namespace EducationApp.BusinessLogicalLayer.Models
{
    public class PageViewModel //need to embed or remove
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
        public bool HasNextPages
        {
            get
            {
                return (PageNumber < TotalPages-3);
            }
        }
        public bool HasPreviousPages
        {
            get
            {
                return (PageNumber > 4);
            }
        }
    }
}
