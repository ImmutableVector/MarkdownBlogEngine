﻿using System;

namespace MarkdownBlog.Shared
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
    }
}