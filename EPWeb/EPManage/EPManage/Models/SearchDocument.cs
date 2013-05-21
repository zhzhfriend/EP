using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace EPManageWeb.Models
{
    public class SearchDocument
    {
        public String SampleNO { get; set; }
        public String ProductNO { get; set; }
        public String Tags { get; set; }

        public String ToSearchDocument()
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(SampleNO))
            {
                sb.AppendFormat("SampleNO:{0}", SampleNO);
            }
            if (!String.IsNullOrEmpty(ProductNO))
            {
                sb.AppendFormat("ProductNO:{0}", ProductNO);
            }
            if (!String.IsNullOrEmpty(Tags))
            {
                sb.AppendFormat("Tags:{0}", Tags);
            }
            if (sb.Length == 0)
                sb.Append("Tags:ALL");
            return sb.ToString();
        }
    }
}