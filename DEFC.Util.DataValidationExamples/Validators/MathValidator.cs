using DEFC.Util.DataValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFC.Util.DataValidationExamples
{
    class MathValidator
    {
        public void Validat(string val)
        {
            Console.WriteLine($"--------------{val}-------------------");
            if (DataType.IsDouble(val))
            {
                var _MathDataValidator = new MathDataValidator();
                IEnumerable<ValidatorBase<double>.Rule> messages = _MathDataValidator.Validate(Convert.ToDouble(val));

                foreach (var message in messages)
                    if (message.ValidFun(Convert.ToDouble(val)))
                        Console.WriteLine($"{message.DataType} ===> " + message.ValidMessage);
                    else
                        Console.WriteLine($"{message.DataType} ===> " + message.InValidMessage);

                Console.WriteLine("Want to check another value(Y/N)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("Enter value to validate: ");
                    val = Console.ReadLine();
                    Validat(val);
                    Console.ReadLine();
                }

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
                new Rule {DataType="IsZero", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsZero(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsPositive", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsPositive(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsNegative", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsNegative(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsEven", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsEven(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsOdd", ValidFun = new Func<double,bool>(fun => DataValidation.Math.IsOdd(fun)), InValidMessage = "No",ValidMessage = "Yes" },
              };
                return R;
            }
        }
    }
}
