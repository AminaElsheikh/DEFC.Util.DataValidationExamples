using DEFC.Util.DataValidation;
using System;
using System.Collections.Generic; 

namespace DEFC.Util.DataValidationExamples
{
    class DataTypeValidator
    {
        public void Validat(string val)
        {
           
            var _DataValidator = new DataValidator();
            Console.WriteLine($"--------------Value to chack: {val}-------------------");

            IEnumerable<ValidatorBase<string>.Rule> messages = _DataValidator.Validate(val); 
            
            foreach (var message in messages)
                if (message.ValidFun(val))
                    Console.WriteLine($"{message.CheckType} ===> " + message.ValidMessage);
                else
                    Console.WriteLine($"{message.CheckType} ===> " + message.InValidMessage);

        }
    }        

    class DataValidator : ValidatorBase<string>
    {
        protected override IEnumerable<ValidatorBase<string>.Rule> Rules
        {
            get
            {
                Rule[] R=  new Rule[] {
                new Rule {CheckType="Is Alpha", ValidFun = new Func<string,bool>(fun => DataType.IsAlpha(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Alphanumeric", ValidFun = new Func<string,bool>(fun => DataType.IsAlphanumeric(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Base64", ValidFun = new Func<string,bool>(fun => DataType.IsBase64(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Byte", ValidFun = new Func<string,bool>(fun => DataType.IsByte(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is DateTime", ValidFun = new Func<string,bool>(fun => DataType.IsDateTime(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Decimal", ValidFun = new Func<string,bool>(fun => DataType.IsDecimal(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Double", ValidFun = new Func<string,bool>(fun => DataType.IsDouble(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Email", ValidFun = new Func<string,bool>(fun => DataType.IsEmail(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Float", ValidFun = new Func<string,bool>(fun => DataType.IsFloat(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is GUID", ValidFun = new Func<string,bool>(fun => DataType.IsGUID(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is IP", ValidFun = new Func<string,bool>(fun => DataType.IsIP(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="In t", ValidFun = new Func<string,bool>(fun => DataType.IsInt(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is IPv4", ValidFun = new Func<string,bool>(fun => DataType.IsIPv4(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is IPv6", ValidFun = new Func<string,bool>(fun => DataType.IsIPv6(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is LatitudeLongitude", ValidFun = new Func<string,bool>(fun => DataType.IsLatitudeLongitude(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Long", ValidFun = new Func<string,bool>(fun => DataType.IsLong(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is MACAddress", ValidFun = new Func<string,bool>(fun => DataType.IsMACAddress(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Number", ValidFun = new Func<string,bool>(fun => DataType.IsNumber(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Short", ValidFun = new Func<string,bool>(fun => DataType.IsShort(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is URL", ValidFun = new Func<string,bool>(fun => DataType.IsURL(fun)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Null", ValidFun = new Func<string,bool>(fun => DataType.IsNullOrEmptyOrWhiteSpace(fun)), InValidMessage = "No" ,ValidMessage = "Yes" }
             };
                return R;
            }
        }
    }
}
