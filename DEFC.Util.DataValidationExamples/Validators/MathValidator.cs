using DEFC.Util.DataValidation;
using System;
using System.Collections.Generic; 

namespace DEFC.Util.DataValidationExamples
{
    class MathValidator
    {
        public void Validat(string val)
        {
            Console.WriteLine($"--------------Value to chack: {val}-------------------");
            if (DataType.IsDouble(val))
            {
                var _MathDataValidator = new MathDataValidator();
                IEnumerable<ValidatorBase<double>.Rule> messages = _MathDataValidator.Validate(Convert.ToDouble(val));

                foreach (var message in messages)
                    if (message.ValidFun(Convert.ToDouble(val)))
                        Console.WriteLine($"{message.CheckType} ===> " + message.ValidMessage);
                    else
                        Console.WriteLine($"{message.CheckType} ===> " + message.InValidMessage);
            }
            else
                 Console.WriteLine($"Value must be Number");
        }
    }
    class MathDataValidator : ValidatorBase<double>
    {
        protected override IEnumerable<ValidatorBase<double>.Rule> Rules
        {
            get
            {
                Rule[] R = new Rule[] {
                new Rule {CheckType="Is a Zero", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsZero(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is a Positive", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsPositive(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is a Negative", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsNegative(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is an Even", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsEven(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is an Odd", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsOdd(fun)), InValidMessage = "No",ValidMessage = "Yes" },
              };
                return R;
            }
        }
    }
}
