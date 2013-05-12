﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPManageWeb.Entities.Models
{
    public class Clothes
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string SampleNO { get; set; }
        [MaxLength(50)]
        public string StyleNO { get; set; }
        public int ProductedCount { get; set; }
        public int SaledCount { get; set; }
        public String Comment { get; set; }
        [MaxLength(100)]
        public String AssessoriesFile { get; set; }
        [MaxLength(500)]
        public String ClothesPics { get; set; }
        [MaxLength(500)]
        public String ModelVersionPics { get; set; }
        [MaxLength(100)]
        public String SampleFile { get; set; }
        [MaxLength(500)]
        public String StylePics { get; set; }
        [MaxLength(100)]
        public String TechnologyFile { get; set; }
        [MaxLength(1000)]
        public String ClothesSize { get; set; }
    }
}