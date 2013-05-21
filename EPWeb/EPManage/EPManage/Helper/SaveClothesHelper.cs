using EPManageWeb.Entities.Models;
using EPManageWeb.Models;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Version = Lucene.Net.Util.Version;

namespace EPManageWeb.Helper
{
    public class SaveClothesHelper
    {
        static Version version = Version.LUCENE_20;
        const String INDEX_PATH = "~LuceneIndex";
        static Directory directory = FSDirectory.Open(HttpContext.Current.Server.MapPath(INDEX_PATH));
        static Analyzer analyzer = new StandardAnalyzer(version);

        public static void Save(Clothes clothes)
        {
            using (IndexWriter writer = new IndexWriter(directory, analyzer, true, new IndexWriter.MaxFieldLength(1000)))
            {
                clothes.Tags = String.Format("ALL {0}", clothes.Tags);
                Document document = new Document();
                document.Add(new Field(Fields.Id.ToString(), clothes.Id.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.SampleNO.ToString(), clothes.SampleNO, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.Tags.ToString(), clothes.Tags.Replace(',',' '), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.ProductNO.ToString(), clothes.ProductNO, Field.Store.YES, Field.Index.ANALYZED));

                writer.AddDocument(document);
                writer.Optimize();
            }
        }

        public static List<Clothes> Search(SearchDocument searchCondition)
        {
            List<Clothes> clothes = new List<Clothes>();

            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(INDEX_PATH)) || System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath(INDEX_PATH)).Length == 0)
                return clothes;

            
            QueryParser parser = new QueryParser(version, Fields.Tags.ToString(), new StandardAnalyzer(version));
            parser.DefaultOperator = QueryParser.Operator.OR;
            Query query = parser.Parse(searchCondition.ToSearchDocument());
            IndexSearcher searcher = new IndexSearcher(directory);
            TopDocs hits = searcher.Search(query, 100);
            foreach (var t in hits.ScoreDocs)
            {
                clothes.Add(new Clothes()
                {
                    Id = int.Parse(searcher.Doc(t.Doc).GetField(Fields.Id.ToString()).StringValue),
                    ProductNO = searcher.Doc(t.Doc).GetField(Fields.ProductNO.ToString()).StringValue,
                    SampleNO = searcher.Doc(t.Doc).GetField(Fields.SampleNO.ToString()).StringValue
                });
            }
            return clothes;
        }

        enum Fields
        {
            Id,
            SampleNO,
            ProductNO,
            Tags
        }
    }
}