using EPManageWeb.Entities.Models;
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
        static Directory directory = FSDirectory.Open(HttpContext.Current.Server.MapPath("~/LuceneIndex"));
        static Analyzer analyzer = new StandardAnalyzer(version);

        public static void Save(Clothes clothes)
        {
            using (IndexWriter writer = new IndexWriter(directory, analyzer, true, new IndexWriter.MaxFieldLength(1000)))
            {
                Document document = new Document();
                document.Add(new Field(Fields.Id.ToString(), clothes.Id.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.SampleNO.ToString(), clothes.SampleNO, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.Tags.ToString(), clothes.Tags, Field.Store.YES, Field.Index.ANALYZED));

                writer.AddDocument(document);
                writer.Optimize();
            }
        }

        public static List<Clothes> Search(string content)
        {
            List<Clothes> clothes = new List<Clothes>();

            QueryParser parser = new QueryParser(version, Fields.Tags.ToString(), new StandardAnalyzer(version));
            Query query = parser.Parse(content);
            IndexSearcher searcher = new IndexSearcher(directory);
            TopDocs hits = searcher.Search(query, 100);
            foreach (var t in hits.ScoreDocs)
            {
                clothes.Add(new Clothes()
                {
                    Id = int.Parse(searcher.Doc(t.Doc).GetField(Fields.Tags.ToString()).StringValue),
                    StyleNO = searcher.Doc(t.Doc).GetField(Fields.StyleNO.ToString()).StringValue,
                    SampleNO = searcher.Doc(t.Doc).GetField(Fields.SampleNO.ToString()).StringValue
                });
            }
            return clothes;
        }

        enum Fields
        {
            Id,
            SampleNO,
            StyleNO,
            Tags
        }
    }
}