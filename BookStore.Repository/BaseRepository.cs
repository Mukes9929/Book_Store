﻿using BookStore.Model.Modelview;
using BookStore.Models.Models;

namespace BookStore.Repository
{
    public class BaseRepository
    {
        protected readonly BookStoreContext _context = new BookStoreContext();
    }
}
