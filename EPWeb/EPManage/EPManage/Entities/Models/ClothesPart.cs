using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPManageWeb.Entities.Models
{
    public class ClothesPart : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public String Name { get; set; }

        public ClothesPart Parent { get; set; }
        public virtual List<ClothesPart> Children { get; set; }

        public virtual ClothesType ClothType { get; set; }

        public virtual List<ClothesPartType> PartTypes { get; set; }
    }
}