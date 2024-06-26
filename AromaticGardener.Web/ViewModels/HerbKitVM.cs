﻿using AromaticGardener.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AromaticGardener.Web.ViewModels
{
    public class HerbKitVM
    {
        public HerbKit HerbKit { get; set; } = null!;
        [ValidateNever]
        public IEnumerable<SelectListItem>? HerbList { get; set; }
    }
}
