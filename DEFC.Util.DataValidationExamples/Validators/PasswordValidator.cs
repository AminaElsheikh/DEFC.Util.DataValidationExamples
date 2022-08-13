using DEFC.Util.DataValidation;
using System;
using System.Collections.Generic; 

namespace DEFC.Util.DataValidationExamples
{
    class PasswordValidator
    {
        public void ValidatConfirmPassword(string password,string confirmPassword)
        {
            Console.WriteLine($"---------------Value to chack: {password}-------------------");
           bool Ismatch= Password.IsMatch(password, confirmPassword);
                if (Ismatch)
                Console.WriteLine($"Password and confirm password matches");
                else
                Console.WriteLine($"Password and confirm password not matches");
        }
        public void ValidatPassword(PasswordRules rules)
        {
            Console.WriteLine($"---------------Value to chack: {rules.Password}-------------------");
            bool Isvalid = Password.ValidatRules(rules);
            if (Isvalid)
                Console.WriteLine($"Password is valid");
            else
                Console.WriteLine($"Password is not valid");
        }
    }
 }
