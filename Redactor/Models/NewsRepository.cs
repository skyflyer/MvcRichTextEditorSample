using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Redactor.Models
{
    public class NewsRepository : DbContext
    {
        public DbSet<NewsItem> News { get; set; }
    }
}