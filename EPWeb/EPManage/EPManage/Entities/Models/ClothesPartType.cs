﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPManageWeb.Entities.Models
{
    public class ClothesPartType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public String Name { get; set; }
        public int Order { get; set; }

        public ClothesPart ClothesPart { get; set; }
    }
}