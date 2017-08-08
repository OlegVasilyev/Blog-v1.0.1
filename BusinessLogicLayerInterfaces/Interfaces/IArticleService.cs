using BusinessLogicLayerInterfaces.DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    /// <summary>
    /// Interface for working with Article
    /// </summary>
    public interface IArticleService
    {
        ArticleDTO GetArticle(int? Id);
        IEnumerable<ArticleDTO> GetArticles();
        IEnumerable<ArticleDTO> GetArticles(string tag);
        void CreateArticle(ArticleDTO articleDto);
        void DeleteArticle(int? Id);
    }
}
