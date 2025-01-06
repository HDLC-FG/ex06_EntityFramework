using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        Task<Article?> Get(int id);
        Task<int> Add(Article article);
        Task<IList<Article>> GetArticlesBelowStock(int stock);
        Task<IDictionary<Article, decimal>> GetTotalSalesPerArticle();
        Task<Article> UpdateArticleStock(int itemId, int quantity);
    }
}
