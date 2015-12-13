using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Redactor.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}