﻿using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Accessories : BaseEntity
{
    [Required,StringLength(10000)]
    public string Description { get; set; } = string.Empty;
}