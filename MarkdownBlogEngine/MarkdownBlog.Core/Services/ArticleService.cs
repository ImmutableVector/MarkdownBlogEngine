using Markdig;
using ProgrammingLexicon.Dal.Repositories;
using MarkdownBlog.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLexicon.Core.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDto> GetContent(int id)
        {
            var article = await _articleRepository.GetContent(id);
            if (article != null)
            {
                var pipeline = new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions()
                    .Build();

                article.Content = Markdown.ToHtml(article.Content, pipeline);
                return article;
            }


            return new ArticleDto();
        }

        public async Task<PagedList<ArticlePreviewDto>> GetArticlePreviews(int skip, int take)
            => await _articleRepository.GetArticlePreviews(skip, take);
    }
}
