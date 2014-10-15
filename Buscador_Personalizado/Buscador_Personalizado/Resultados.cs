﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador_Personalizado;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace Buscador_Personalizado
{
    public class Resultados
    {
        public class Url
        {
            public string type { get; set; }
            public string template { get; set; }
        }

        public class NextPage
        {
            public string title { get; set; }
            public string totalResults { get; set; }
            public string searchTerms { get; set; }
            public int count { get; set; }
            public int startIndex { get; set; }
            public string inputEncoding { get; set; }
            public string outputEncoding { get; set; }
            public string safe { get; set; }
            public string cx { get; set; }
        }

        public class Request
        {
            public string title { get; set; }
            public string totalResults { get; set; }
            public string searchTerms { get; set; }
            public int count { get; set; }
            public int startIndex { get; set; }
            public string inputEncoding { get; set; }
            public string outputEncoding { get; set; }
            public string safe { get; set; }
            public string cx { get; set; }
        }

        public class Queries
        {
            public List<NextPage> nextPage { get; set; }
            public List<Request> request { get; set; }
        }

        public class Context
        {
            public string title { get; set; }
        }

        public class SearchInformation
        {
            public double searchTime { get; set; }
            public string formattedSearchTime { get; set; }
            public string totalResults { get; set; }
            public string formattedTotalResults { get; set; }
        }

        public class DataObject
        {
            [DataMember(Name = "og:title")]
            public int ogtitle { get; set; }
        
            [DataMember(Name = "detail_level")]
            public string DetailLevel { get; set; }
        }

        public class Metatag
        {
            public string viewport { get; set; }
            public string referrer { get; set; }
            [DataMember(Name = "og:image")]
            public int ogImage { get; set; }
            [DataMember(Name = "og:ttl")]
            public int ogttl { get; set; }
            [DataMember(Name = "og:site_name")]
            public int ogsitename { get; set; }
            [DataMember(Name = "og:description")]
            public int ogdescription { get; set; }
            [DataMember(Name = "og:title")]
            public int ogtitle { get; set; }
            [DataMember(Name = "twitter:site")]
            public int twittersite { get; set; }
            [DataMember(Name = "twitter:card")]
            public int twittercard { get; set; }
            [DataMember(Name = "twitter:title")]
            public int twittertitle { get; set; }
        }

        public class CseImage
        {
            public string src { get; set; }
        }

        public class CseThumbnail
        {
            public string width { get; set; }
            public string height { get; set; }
            public string src { get; set; }
        }

        public class Pagemap
        {
            public List<Metatag> metatags { get; set; }
            public List<CseImage> cse_image { get; set; }
            public List<CseThumbnail> cse_thumbnail { get; set; }
        }

        public class Item
        {
            public string kind { get; set; }
            public string title { get; set; }
            public string htmlTitle { get; set; }
            public string link { get; set; }
            public string displayLink { get; set; }
            public string snippet { get; set; }
            public string htmlSnippet { get; set; }
            public string cacheId { get; set; }
            public string formattedUrl { get; set; }
            public string htmlFormattedUrl { get; set; }
            public Pagemap pagemap { get; set; }
        }

        public class RootObject
        {
            public string kind { get; set; }
            public Url url { get; set; }
            public Queries queries { get; set; }
            public Context context { get; set; }
            public SearchInformation searchInformation { get; set; }
            public List<Item> items { get; set; }
        }
    }
}
