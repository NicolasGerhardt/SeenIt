﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seenit.Data.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
    }
}
