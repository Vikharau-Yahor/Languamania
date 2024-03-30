using Dapper;
using Languamania.Data.Models;
using Languamania.Data.Providers;
using Languamania.Data.Repositories.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languamania.Data.Repositories
{
    // may be let's try cqrs?
    public class TranslationItemsRepository : /* BaseRepository with dbProvider dependancy and connection prop + common DI registration*/
        ITranslationItemsRepository
    {
        private IDbAccessProvider _dbProvider;
        public TranslationItemsRepository(IDbAccessProvider dbProvider) {
            _dbProvider = dbProvider;
        }
        
        public async Task<IList<TranslationItem>> GetListAsync()
        {
            var sql = "SELECT * FROM languamania.dbo.TTranslationItem";

            var translationItems = await _dbProvider.QueryListAsync<TranslationItem>(sql);
            return translationItems.ToList();
        }

        public async Task PostAsync(TranslationItem translationItem)
        {
            var sql = "INSERT INTO languamania..TTranslationItem([Text],[Language]) " +
                "VALUES (@Text, @Language)";

            await _dbProvider.InsertAsync(sql, new { Text = translationItem.Text, Language = translationItem.Language });
        }

        public async Task UpdateAsync(TranslationItem translationItem)
        {
            var sql = "UPDATE languamania..TTranslationItem " +
                "SET [Text] = @Text, [Language] = @Language " +
                "WHERE Id = @Id";

            await _dbProvider.InsertAsync(sql, new { Id = translationItem.Id, Text = translationItem.Text, Language = translationItem.Language });
        }
        // Create + Update
    }
}
