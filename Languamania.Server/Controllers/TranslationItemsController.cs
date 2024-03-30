using Languamania.Data.Providers;
using Languamania.Data.Repositories;
using Languamania.Data.Repositories.Interfaces;
using Languamania.Server.APIContracts;
using Microsoft.AspNetCore.Mvc;

namespace Languamania.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationItemsController : ControllerBase
    {
        private readonly ILogger<TranslationItemsController> _logger;
        private readonly ITranslationItemsRepository _translationItemsRepository;
        public TranslationItemsController(ILogger<TranslationItemsController> logger,
            ITranslationItemsRepository translationItemsRepository)
        {
            _logger = logger;
            _translationItemsRepository = translationItemsRepository;
        }

        [HttpGet(Name = "GetTranslationItems")]
        public async Task<IEnumerable<TranslationItemContract>> Get()
        {
            var result = (await _translationItemsRepository.GetListAsync()).Select(
                x => new TranslationItemContract { Id = x.Id, Text = x.Text, Language = x.Language });

            return result;
        }

        /// <summary>
        /// Create translation item (word, or phrase which can be translated to smth or be a translation)
        /// </summary>
        /// <param name="translationItem">Translation item request</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateTranslationItem")]
        public async Task Post([FromBody] TranslationItemContract translationItem)
        {
            await _translationItemsRepository.PostAsync(new Data.Models.TranslationItem
            {
                Language = translationItem.Language,
                Text = translationItem.Text
            });
        }

        /// <summary>
        /// Update translation item (word, or phrase which can be translated to smth or be a translation)
        /// </summary>
        /// <param name="translationItem"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateTranslationItem")]
        public async Task Put([FromBody] TranslationItemContract translationItem)
        {
            await _translationItemsRepository.UpdateAsync(new Data.Models.TranslationItem
            {
                Id = translationItem.Id,
                Language = translationItem.Language,
                Text = translationItem.Text
            });
        }
    }
}
