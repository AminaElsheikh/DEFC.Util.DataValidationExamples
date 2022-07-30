using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFC.Util.DataValidationExamples
{
    class DTValidator
    {
        public void Validat(string val)
        {
           
            var fooValidator = new DataValidator();
            Console.WriteLine($"--------------{val}-------------------");

            IEnumerable<ValidatorBase<string>.Rule> messages = fooValidator.Validate(val); 
            
            foreach (var message in messages)
                if (message.ValidFun(val))
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
    } 
     
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

    class DataValidator : ValidatorBase<string>
    {
        protected override IEnumerable<ValidatorBase<string>.Rule> Rules
        {
            get
            {
                Rule[] R=  new Rule[] {
                new Rule {DataType="IsAlpha", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsAlpha(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsAlphanumeric", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsAlphanumeric(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsBase64", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsBase64(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsByte", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsByte(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsDateTime", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsDateTime(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsDecimal", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsDecimal(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsDouble", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsDouble(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsEmail", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsEmail(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsFloat", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsFloat(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsGUID", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsGUID(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsIP", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsIP(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="Int", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsInt(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsIPv4", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsIPv4(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsIPv6", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsIPv6(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsLatitudeLongitude", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsLatitudeLongitude(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsLong", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsLong(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsMACAddress", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsMACAddress(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsNumber", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsNumber(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsShort", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsShort(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsURL", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsURL(foo)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsNull", ValidFun = new Func<string,bool>(foo => DataValidation.DataType.IsNullOrEmptyOrWhiteSpace(foo)), InValidMessage = "No" ,ValidMessage = "Yes" }
             };
                return R;
            }
        }
    }
}
