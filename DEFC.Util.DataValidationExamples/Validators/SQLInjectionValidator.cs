using System;
using System.Collections.Generic; 

namespace DEFC.Util.DataValidationExamples
{
    class SQLInjectionValidator
    {
        public void Validat(string val)
        {
            Console.WriteLine($"--------------Value to chack: {val}-------------------");
            var _SQLInjectionDataValidator = new SQLInjectionDataValidator();
            
            IEnumerable<ValidatorBase<string>.Rule> messages = _SQLInjectionDataValidator.Validate(val);

            foreach (var message in messages)
                if (message.ValidFun(val))
                    Console.WriteLine($"{message.CheckType} ===> " + message.ValidMessage);
                else
                    Console.WriteLine($"{message.CheckType} ===> " + message.InValidMessage);
        }
    }
    class SQLInjectionDataValidator : ValidatorBase<string>
    {
        protected override IEnumerable<ValidatorBase<string>.Rule> Rules
        {
            get
            {
                Rule[] R = new Rule[] {
                new Rule {CheckType="Has SQL Injection", ValidFun = new Func<string,bool>(fun => DataValidation.SQLInjection.IsExists(fun)), InValidMessage = "No",ValidMessage = "Yes" },
               };
                return R;
            }
        }
    }
}
