﻿using BookStore.Model.Modelview;
using BookStore.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository
{
    public class PublisherRepository  : BaseRepository
    {
        public ListResponse<Publisher> GetPublishers(int pageIndex, int pageSize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Publishers.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalReocrds = query.Count();
            List<Publisher> categories = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Publisher>()
            {
                results = categories,
                totalresults = totalReocrds,
            };
        }

        public Publisher GetPublisher(int id)
        {
            return _context.Publishers.FirstOrDefault(c => c.Id == id);
        }

        public Publisher AddPublisher(Publisher category)
        {
            var entry = _context.Publishers.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Publisher UpdatePublisher(Publisher category)
        {
            var entry = _context.Publishers.Update(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeletePublisher(int id)
        {
            var category = _context.Publishers.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return false;

            _context.Publishers.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
