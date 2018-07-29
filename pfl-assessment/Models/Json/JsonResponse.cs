using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json
{
    public class JsonResponse<T>
    {
        public Meta Meta { get; set; }
        public ResultsNode<T> Results { get; set; }
    }
}