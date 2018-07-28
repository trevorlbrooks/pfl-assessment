using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models
{
    public class JsonResponse<T>
    {
        public ResultsNode<T> Results { get; set; }
    }
}