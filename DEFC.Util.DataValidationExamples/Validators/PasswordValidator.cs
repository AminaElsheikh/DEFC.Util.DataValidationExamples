using DEFC.Util.DataValidation;
using System;
using System.Collections.Generic; 

namespace DEFC.Util.DataValidationExamples
{
    class PasswordData
    {
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string passwordMinLength { get; set; }
        public string symbols { get; set; } 
    }
    class PasswordValidator
    {
        public void Validat(PasswordData _PasswordData)
        {
            Console.WriteLine($"---------------Value to chack: {_PasswordData.password}-------------------");
            if (DataType.IsInt(_PasswordData.passwordMinLength))
            {
                var _PasswordDataValidator = new PasswordDataValidator();

                IEnumerable<ValidatorBase<PasswordData>.Rule> messages = _PasswordDataValidator.Validate(_PasswordData);

                foreach (var message in messages)
                    if (message.ValidFun(_PasswordData))
                        Console.WriteLine($"{message.CheckType} ===> " + message.ValidMessage);
                    else
                        Console.WriteLine($"{message.CheckType} ===> " + message.InValidMessage);
            }
            else
                Console.WriteLine($"Password minimum length must be a number");           

        }
    }
    class PasswordDataValidator : ValidatorBase<PasswordData>
    {
        protected override IEnumerable<ValidatorBase<PasswordData>.Rule> Rules
        {
            get
            {
                Rule[] R = new Rule[] {
                new Rule {CheckType="Is Match the confirm password", ValidFun = new Func<PasswordData,bool>(fun => Password.IsMatch(fun.password,fun.confirmPassword)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is strong password with upper, lower case letters and digit with length", ValidFun = new Func<PasswordData,bool>(fun => Password.IsStrongUpperLowerDigitWithLength(fun.password,Convert.ToInt16(fun.passwordMinLength))), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is strong password with upper, lower case letters and digit with length and symbols", ValidFun = new Func<PasswordData,bool>(fun => Password.IsStrongUpperLowerDigitWithLengthAndSymbols(fun.password,fun.symbols,Convert.ToInt16(fun.passwordMinLength))), InValidMessage = "No",ValidMessage = "Yes" },
               };
                return R;
            }
        }
    }
}
