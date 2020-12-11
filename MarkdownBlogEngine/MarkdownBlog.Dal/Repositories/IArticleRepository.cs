using ProgrammingLexicon.Dal.Models;
using MarkdownBlog.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLexicon.Dal.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<ArticleDto> GetContent(int id);
        Task<PagedList<ArticlePreviewDto>> GetArticlePreviews(int skip, int take);
    }
}
