using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFC.Util.DataValidationExamples
{
    class DataTypeValidator
    {
        public void Validat(string val)
        {
           
            var _DataValidator = new DataValidator();
            Console.WriteLine($"--------------{val}-------------------");

            IEnumerable<ValidatorBase<string>.Rule> messages = _DataValidator.Validate(val); 
            
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

    class DataValidator : ValidatorBase<string>
    {
        protected override IEnumerable<ValidatorBase<string>.Rule> Rules
        {
            get
            {
                Rule[] R=  new Rule[] {
                new Rule {DataType="IsAlpha", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsAlpha(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsAlphanumeric", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsAlphanumeric(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsBase64", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsBase64(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsByte", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsByte(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsDateTime", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsDateTime(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsDecimal", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsDecimal(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsDouble", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsDouble(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsEmail", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsEmail(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsFloat", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsFloat(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsGUID", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsGUID(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsIP", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsIP(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="Int", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsInt(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsIPv4", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsIPv4(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsIPv6", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsIPv6(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsLatitudeLongitude", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsLatitudeLongitude(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsLong", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsLong(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsMACAddress", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsMACAddress(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsNumber", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsNumber(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsShort", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsShort(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsURL", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsURL(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {DataType="IsNull", ValidFun = new Func<string,bool>(fun => DataValidation.DataType.IsNullOrEmptyOrWhiteSpace(fun)), InValidMessage = "No" ,ValidMessage = "Yes" }
             };
                return R;
            }
        }
    }
}
