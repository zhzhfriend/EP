﻿using EPManageWeb.Entities.Models;
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
        const String INDEX_PATH = "~/LuceneIndex";
        static Directory directory = FSDirectory.Open(HttpContext.Current.Server.MapPath(INDEX_PATH));
        static Analyzer analyzer = new WhitespaceAnalyzer();

        public static void RemovePreviousIndex()
        {
            var luceneIndexFile = HttpContext.Current.Server.MapPath(String.Format("{0}/{1}", INDEX_PATH, "segments.gen"));
            if (System.IO.File.Exists(luceneIndexFile))
                System.IO.File.Delete(luceneIndexFile);
        }

        public static void Save(Clothes clothes)
        {
            using (IndexWriter writer = new IndexWriter(directory, analyzer, !directory.FileExists("segments.gen"), new IndexWriter.MaxFieldLength(1000)))
            {
                Document document = new Document();
                document.Add(new Field(Fields.Id.ToString(), clothes.Id.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.SampleNO.ToString(), clothes.SampleNO, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.Tags.ToString(), clothes.Tags.Replace(',', ' '), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.ProductNO.ToString(), clothes.ProductNO, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.Year.ToString(), ExtractYearFromTags(clothes), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.ClothesTypeId.ToString(), clothes.ClothesType.Id.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.SaledCount.ToString(), clothes.SaledCount.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.ClothesPics.ToString(), clothes.ClothesPics ?? string.Empty, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.ModelVersionPics.ToString(), clothes.ModelVersionPics ?? string.Empty, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.StylePics.ToString(), clothes.StylePics ?? string.Empty, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field(Fields.UsedCount.ToString(), clothes.ViewCount.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(document);
                writer.Optimize();
            }
        }

        public static List<Clothes> Search(SearchDocument searchCondition)
        {
            List<Clothes> clothes = new List<Clothes>();

            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(INDEX_PATH)) || System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath(INDEX_PATH)).Length == 0)
                return clothes;


            QueryParser parser = new QueryParser(version, Fields.Tags.ToString(), new WhitespaceAnalyzer());
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
                    SampleNO = searcher.Doc(t.Doc).GetField(Fields.SampleNO.ToString()).StringValue,
                    ClothesPics = searcher.Doc(t.Doc).GetField(Fields.ClothesPics.ToString()).StringValue,
                    StylePics = searcher.Doc(t.Doc).GetField(Fields.StylePics.ToString()).StringValue,
                    ModelVersionPics = searcher.Doc(t.Doc).GetField(Fields.ModelVersionPics.ToString()).StringValue
                });
            }
            return clothes;
        }

        public static void RemoveDocument(int id)
        {
            QueryParser parser = new QueryParser(version, Fields.Tags.ToString(), new WhitespaceAnalyzer());
            parser.DefaultOperator = QueryParser.Operator.OR;
            Query query = parser.Parse(string.Format("{0}:{1}", Fields.Id.ToString(), id));
            IndexSearcher searcher = new IndexSearcher(directory);
            using (IndexReader reader = IndexReader.Open(directory, false))
            {
                TopDocs hits = searcher.Search(query, 100);
                var term = new Term(Fields.Id.ToString(), id.ToString());
                reader.DeleteDocuments(term);
            }

        }

        private static string ExtractYearFromTags(Clothes clothes)
        {
            if (!String.IsNullOrEmpty(clothes.Tags))
            {
                return System.Text.RegularExpressions.Regex.Match(clothes.Tags, @"\d{4}").Value;
            }
            return string.Empty;
        }

        enum Fields
        {
            Id,
            SampleNO,
            ProductNO,
            Tags,
            Year,
            SaledCount,
            UsedCount,
            ClothesTypeId,
            ClothesPics,
            StylePics,
            ModelVersionPics
        }
    }
}