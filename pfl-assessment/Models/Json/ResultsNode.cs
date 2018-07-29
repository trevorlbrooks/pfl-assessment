using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json
{
    public class ResultsNode<T>
    {
        public T Data { get; set; }
        public List<Error> Errors { get; set; }
    }
}