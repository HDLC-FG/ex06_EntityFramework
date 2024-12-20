using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext context;

        public ArticleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(Article article)
        {
            await context.Articles.AddAsync(article);
            return await context.SaveChangesAsync();
        }

        public async Task<IList<Article>> GetArticlesBelowStock(int stock)
        {
            return await context.Articles.Where(x => x.StockQuantity < stock).ToListAsync();
        }

        public async Task<IDictionary<decimal, Article>> GetTotalSalesPerArticle()
        {
            return await context.Articles.ToDictionaryAsync(x => x.Price);
        }

        public async Task<Article> UpdateArticleStock(int itemId, int quantity)
        {
            var article = await context.Articles.SingleOrDefaultAsync(x => x.Id == itemId);
            if (article == null) throw new Exception("Article does not exist");
            article.StockQuantity = quantity;
            //TODO : à tester
            await context.SaveChangesAsync();
            return article;
        }
    }
}
