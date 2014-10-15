using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador_Personalizado
{
    public class GoogleSearchItem
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }

    }

    public class SourceUrl
    {
        public string type { get; set; }
        public string template { get; set; }
    }

    public class GoogleSearchResults
    {
        public string kind { get; set; }
        public SourceUrl url { get; set; }
        public GoogleSearchItem[] items { get; set; }
    }
}