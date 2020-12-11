using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarkdownBlog.Shared;
using ProgrammingLexicon.Core.Services;

namespace ProgrammingLexicon.Api.Controllers
{
    [ApiController]
    [Route("api/article")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IArticleService _articleService;

        public ArticleController(
            ILogger<ArticleController> logger,
            IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet("{Id}")]
        public async Task<ArticleDto> GetContent(int id)
            => await _articleService.GetContent(id);

        [HttpGet]
        [Route("/Previews")]
        public async Task<List<ArticlePreviewDto>> GetArticlePreviews(int skip, int take)
        {
            var test = await _articleService.GetArticlePreviews(skip, take);
             return test.Data;
        }
           
    }
}
