using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json.Products
{
    public class Field
    {
        public char Required { get; set; }
        public char Visible { get; set; }
        public string Type { get; set; }
        public string Linelimit { get; set; }
        public string Fieldname { get; set; }
        public List<FieldPrompt> Prompt { get; set; }
        public string Default { get; set; }
        public string Orgvalue { get; set; }
        public string Htmlfieldname { get; set; }
    }
}