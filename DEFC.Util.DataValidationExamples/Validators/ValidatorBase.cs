using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFC.Util.DataValidationExamples
{
    abstract class ValidatorBase<T>
    {
        public class Rule
        {
            public string DataType { get; set; }
            public Func<T, bool> ValidFun { get; set; }
            public string ValidMessage { get; set; }
            public string InValidMessage { get; set; }
        }

        protected abstract IEnumerable<Rule> Rules { get; }

        public IEnumerable<Rule> Validate(T t)
        {
            return this.Rules.Select(r => r);
        }
    }
}
