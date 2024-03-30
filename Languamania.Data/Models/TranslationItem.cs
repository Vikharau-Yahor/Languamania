using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languamania.Data.Models
{
    public class TranslationItem
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public required string Language { get; set; }
    }
}
