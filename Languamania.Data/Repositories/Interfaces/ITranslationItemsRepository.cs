using Languamania.Data.Models;

namespace Languamania.Data.Repositories.Interfaces
{
    public interface ITranslationItemsRepository
    {
        Task<IList<TranslationItem>> GetListAsync(string? language);
        Task PostAsync(TranslationItem translationItem);
        Task UpdateAsync(TranslationItem translationItem);
    }
}