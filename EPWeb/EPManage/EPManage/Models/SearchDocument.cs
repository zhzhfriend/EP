using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace EPManageWeb.Models
{
    public class SearchDocument
    {
        public String NO { get; set; }
        public String Tags { get; set; }
        public int ClothesTypeId { get; set; }

        public Field OrderByField { get; set; }

        public enum Field
        {
            Id,
            Year,
            SaledCount,
            ViewedCount
        }

        public String ToSearchDocument()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("(ClothesTypeId:{0})", ClothesTypeId);
            if (!String.IsNullOrEmpty(NO))
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat("(SampleNO:{0} OR ProductNO:{0})", NO);
            }
            if (!String.IsNullOrEmpty(Tags))
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat("(Tags:{0})", System.Text.RegularExpressions.Regex.Replace(Tags.Replace(',', ' '), @"[\(\)|+\-\!\{\}\[\}\^\""\~\*\?\:\\]", @"\$0"));
            }
            return sb.ToString();
        }
    }
}