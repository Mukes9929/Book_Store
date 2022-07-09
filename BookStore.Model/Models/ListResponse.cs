using BookStore.Model.Modelview;
using BookStore.Models.Models;
using System.Collections.Generic;

namespace BookStore.Models.Models
{
    public class ListResponse<T> where T : class
    {
        public IEnumerable<T> results { get; set; }

        public int totalresults { get; set; }
    }
}
