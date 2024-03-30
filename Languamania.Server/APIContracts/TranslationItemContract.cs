namespace Languamania.Server.APIContracts
{
    public class TranslationItemContract
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public required string Language { get; set; }
    }
}
