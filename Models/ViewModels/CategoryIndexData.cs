﻿using System.Security.Policy;

namespace Proiect.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Tatuaj> Tatuaje { get; set; }
    }
}
