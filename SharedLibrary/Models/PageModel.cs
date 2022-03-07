using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class PageModel
    {
        public PageModel(string text, int pageIndex, bool enabled)
        {
            Text = text;
            PageIndex = pageIndex;
            Enabled = enabled;
        }
        public string Text { get; set; }
        public int PageIndex { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
    }
}
