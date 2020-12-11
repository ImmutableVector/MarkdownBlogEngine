using MarkdownBlog.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLexicon.Core.Services
{
    public interface IArticleService
    {
        Task<ArticleDto> GetContent(int id);
        Task<PagedList<ArticlePreviewDto>> GetArticlePreviews(int skip, int take);
    }
}
