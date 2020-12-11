using Microsoft.EntityFrameworkCore;
using ProgrammingLexicon.Dal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkdownBlog.Shared;

namespace ProgrammingLexicon.Dal.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ProgrammingLexiconContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<ArticleDto> GetContent(int id)
            => await Search(x => x.Id == id)
                .Select(x => new ArticleDto 
                { 
                    Title = x.Title,
                    Content = x.Content,
                    DatePublished = x.DateCreated, // add published date to entity

                })
                .FirstOrDefaultAsync();

        public async Task<PagedList<ArticlePreviewDto>> GetArticlePreviews(int skip, int take)
            => await Search(x => x.IsDeleted == false)
                .Select(x => new ArticlePreviewDto
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    Title = x.Title,
                    Description = x.Description,
                    DatePublished = x.DateCreated, // add published date to entity
                })
                .OrderByDescending(x => x.DatePublished)
                .ToPagedListAsync(skip, take);
    }
}
