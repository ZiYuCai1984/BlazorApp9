using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Faker
{
    public class DocumentIndexProxy : IDocumentIndexProxy
    {
        private IList<Document>? _cache;
        private IList<Document> Cache => _cache ??= this.DocumentFaker.Generate(500);

        private DocumentFaker DocumentFaker { get; } = new DocumentFaker();

        public Task<Document[]> GetDocumentsAsync(CancellationToken token = default)
        {
            return Task.FromResult(this.Cache.OrderByDescending(d => d.CreateTime).ToArray());
        }

        public Task<Document?> GetDocumentAsync(string title, CancellationToken token = default)
        {
            return Task.FromResult<Document?>((from d in this.Cache where d.Title == title select d).FirstOrDefault());
        }

        public Task<Document?> GetDocumentAsync(Guid id, CancellationToken token = default)
        {
            return Task.FromResult<Document?>((from d in this.Cache where d.Id == id select d).FirstOrDefault());
        }
    }
}