using System;
using Bogus;
using ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Faker
{
    public class DocumentFaker : Faker<Document>
    {
        public DocumentFaker()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            this.RuleFor(d => d.Id, f => f.Random.Guid());
            this.RuleFor(d => d.Title, f => f.Lorem.Sentence());
            this.RuleFor(d => d.CreateTime, f => f.Date.Past());
            this.RuleFor(d => d.Path, f => f.System.FilePath());
            this.RuleFor(d => d.Keywords, f => f.Lorem.Words());
            this.RuleFor(d => d.IsLocked, f => f.Random.Bool());
            this.RuleFor(d => d.ContentRaw, f => f.Lorem.Paragraphs());
        }

        private static string GetSummary(Document document, int count = 300)
        {
            return document.ContentRaw.Length > count
                ? document.ContentRaw.Substring(0, count)
                : document.ContentRaw;
        }

        public override Document Generate(string? ruleSets = null)
        {
            var document = base.Generate(ruleSets);
            document.Summary = GetSummary(document);
            return document;
        }
    }
}