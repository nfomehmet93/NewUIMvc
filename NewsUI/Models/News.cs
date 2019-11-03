﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsUI.Models
{
    public class News
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
