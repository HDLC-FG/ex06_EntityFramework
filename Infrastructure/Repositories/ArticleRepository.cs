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

        public async Task<Article?> Get(int id)
        {
            return await context.Articles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(Article article)
        {
            await context.Articles.AddAsync(article);
            return await context.SaveChangesAsync();
        }

        public async Task<IList<Article>> GetArticlesBelowStock(int stock)
        {
            return await context.Articles.Where(x => x.StockQuantity <= stock).ToListAsync();
        }

        public async Task<IDictionary<Article, decimal>> GetTotalSalesPerArticle()
        {
            var tmp = context.OrderDetails.GroupBy(x => x.Article, y => y, (x, y) => new 
            { 
                Article = x, 
                Sum = y.Sum(z => z.Quantity * z.UnitPrice) 
            });
            return await tmp.ToDictionaryAsync(x => x.Article, y => y.Sum);
        }

        public async Task<Article> UpdateArticleStock(int itemId, int quantity)
        {
            var article = await context.Articles.SingleOrDefaultAsync(x => x.Id == itemId);
            if (article == null) throw new Exception("Article does not exist");
            article.StockQuantity += quantity;
            await context.SaveChangesAsync();
            return article;
        }
    }
}
