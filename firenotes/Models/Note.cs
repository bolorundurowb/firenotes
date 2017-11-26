/**
 * Created by winner-timothybolorunduro on 16/11/2017.
 */

using System;
using System.Collections.Generic;

namespace firenotes.Models
{
    public class Note
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
        
        public string Details { get; set; }

        public List<string> Tags { get; set; }

        public DateTime Created { get; private set; }
        
        public DateTime Updated { get; set; }

        public bool IsFavorite { get; set; }

        public Note()
        {
            Created = DateTime.Now;
        }
    }
}