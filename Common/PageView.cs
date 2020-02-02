﻿using System.Collections.Generic;

namespace Common
{
    public class PageView<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PagesCount { get; set; }
        public int ItemsCount { get; set; }
        public int CurrentPage { get; set; }
    }
}