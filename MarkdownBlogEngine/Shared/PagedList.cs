using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownBlog.Shared
{
    public class PagedList<T>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool HasNext { get; set; }
        public List<T> Data { get; set; }
    }
}
