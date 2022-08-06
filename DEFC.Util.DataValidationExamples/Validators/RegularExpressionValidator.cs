using System;
using System.Collections.Generic; 
using System.Text.RegularExpressions; 

namespace DEFC.Util.DataValidationExamples
{
     
    class RegularExpressionData
    {
        public string value { get; set; }
        public Regex regex { get; set; }
    }
    class RegularExpressionValidator
    {
        public void Validat(RegularExpressionData val)
        {
            Console.WriteLine($"---------------Value to chack: {val.value} With Expression: {val.regex}-------------------");
            var _RegularExpressionDataValidator = new RegularExpressionDataValidator();

            IEnumerable<ValidatorBase<RegularExpressionData>.Rule> messages = _RegularExpressionDataValidator.Validate(val);

            foreach (var message in messages)
                if (message.ValidFun(val))
                    Console.WriteLine($"{message.CheckType} ===> " + message.ValidMessage);
                else
                    Console.WriteLine($"{message.CheckType} ===> " + message.InValidMessage);

        }
    }
    class RegularExpressionDataValidator : ValidatorBase<RegularExpressionData>
    {
        protected override IEnumerable<ValidatorBase<RegularExpressionData>.Rule> Rules
        {
            get
            {
                Rule[] R = new Rule[] {
                new Rule {CheckType="Is Match the regular expression", ValidFun = new Func<RegularExpressionData,bool>(fun => DataValidation.RegularExpression.IsMatch(fun.value,fun.regex)), InValidMessage = "No",ValidMessage = "Yes" },
               };
                return R;
            }
        }
    }
}
