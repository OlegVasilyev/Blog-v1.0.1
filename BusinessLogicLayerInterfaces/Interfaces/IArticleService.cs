using BusinessLogicLayerInterfaces.DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    public interface IArticleService
    {
        ArticleDTO GetArticle(int? Id);
        IEnumerable<ArticleDTO> GetArticles();
        IEnumerable<ArticleDTO> GetArticles(string tag);
        void CreateArticle(ArticleDTO articleDto);
        void DeleteArticle(int? Id);
    }
}
