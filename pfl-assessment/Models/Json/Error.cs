using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json
{
    public class Error
    {
        public string DataElement { get; set; }
        public List<String> DataElementErrors { get; set; }
    }
}