using System;
using System.Threading;
using System.Threading.Tasks;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions
{
    public interface IDocumentIndexProxy
    {
        Task<Document[]> GetDocumentsAsync(CancellationToken token = default);
        Task<Document?> GetDocumentAsync(string title, CancellationToken token = default);
        Task<Document?> GetDocumentAsync(Guid id, CancellationToken token = default);
    }
}