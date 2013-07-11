using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace EPManageWeb.Models
{
    public class SearchDocument
    {
        public const int PAGE_SIZE = 20;

        public SearchDocument() { PageIndex = 1; }

        public String NO { get; set; }
        public String Tags { get; set; }
        public int ClothesTypeId { get; set; }

        public Field OrderByField { get; set; }

        public int PageIndex { get; set; }

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

            Tags = System.Text.RegularExpressions.Regex.Replace(Tags.Trim().Replace(',', ' '), @"[\(\)|+\-\!\{\}\[\}\^\""\~\*\?\:\\]", @"\$0").Trim();
            if (!String.IsNullOrEmpty(Tags))
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                if (!String.IsNullOrEmpty(Tags))
                    sb.AppendFormat("(Tags:{0})", Tags);
            }
            return sb.ToString();
        }
    }
}