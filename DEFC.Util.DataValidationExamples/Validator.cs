using DEFC.Util.DataValidation;
using System; 
using System.Text.RegularExpressions; 

namespace DEFC.Util.DataValidationExamples
{
    class Validator
    {
        public static void ManageRound(string StartNew)
        {

            if (StartNew.ToLower() == "y")
            {
                // Ask the user to choose an option.
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("1 For data type validation \t 2 For comparison validation \t 3 For password validation");
                Console.WriteLine("4 For math validation \t 5 For regularExpression validation \t 6 For SQLInjection validation");

                Console.WriteLine("Your option is: ");

                byte validationType = Convert.ToByte(Console.ReadLine());

                ExecuteValidation(validationType);
            }
            else
                Console.WriteLine("******************************************Finish*****************************************");

            Console.ReadLine();
        }

        public static void ExecuteValidation(byte validationType)
        {

            // Use a switch statement to do the math.
            switch (validationType)
            {
                case 1:
                    DataTypeValidatorManager();
                    break;
                case 2:
                    ComparisonValidatorManager();
                    break;
                case 3:
                    PasswordValidatorManager();
                    break;
                case 4:
                    MathValidatorManager();
                    break;
                case 5:
                    RegularExpressionValidatorManager();
                    break;
                case 6:
                    SQLInjectionValidatorManager();
                    break;
                default:
                    Console.WriteLine($"Your choice is out of process");
                    break;
            }
            Console.WriteLine("******************************************New Round*****************************************");
            Console.WriteLine("Want to start new round(Y/N)");
            Validator.ManageRound(Console.ReadLine());
        }

        private static void DataTypeValidatorManager()
        {
            Console.WriteLine("Enter value to validate: ");
            string val = Console.ReadLine();
            DataTypeValidator _DTValidator = new DataTypeValidator();
            _DTValidator.Validat(val);
        }
        private static void SQLInjectionValidatorManager()
        {            
            Console.WriteLine("Enter value to validate: ");
            string val = Console.ReadLine();
            SQLInjectionValidator _SQLInjValidator = new SQLInjectionValidator();
            _SQLInjValidator.Validat(val);
        }

        private static void RegularExpressionValidatorManager()
        {
            RegularExpressionValidator _REValidator = new RegularExpressionValidator();
            RegularExpressionData _RgulrExprValidatorData = new RegularExpressionData();
            Console.WriteLine("Enter value to validate: ");
            _RgulrExprValidatorData.value = Console.ReadLine();
            Console.WriteLine("Enter regular expression to validate by: ");
            _RgulrExprValidatorData.regex = new Regex(Console.ReadLine());
            _REValidator.Validat(_RgulrExprValidatorData);
        }

        private static void MathValidatorManager()
        {
            Console.WriteLine("Enter value to validate: ");
            string val = Console.ReadLine();
            MathValidator _MDValidator = new MathValidator();
            _MDValidator.Validat(val);
        }

        private static void PasswordValidatorManager()
        {
            PasswordValidator _passwordValidator = new PasswordValidator();
            Console.WriteLine("Enter password to validate: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter confirm password: ");
            string confirmPassword = Console.ReadLine();

            _passwordValidator.ValidatConfirmPassword(password, confirmPassword);

            PasswordRules _PasswordRules = new PasswordRules();
            _PasswordRules.Password = password;
            Console.WriteLine("Enter y for password upper case letters check(by default is false): ");
            _PasswordRules.HasUpper = IsBoolean(Console.ReadLine());
            Console.WriteLine("Enter y for password lower case letters check(by default is false): ");
            _PasswordRules.HasLower = IsBoolean(Console.ReadLine());
            Console.WriteLine("Enter y for password digits check(by default is false): ");
            _PasswordRules.HasDigit = IsBoolean(Console.ReadLine());
            Console.WriteLine("Enter y for password Length check(by default is false): ");
            _PasswordRules.HasLength = IsBoolean(Console.ReadLine());            
            if (_PasswordRules.HasLength)
            {
                Console.WriteLine("Enter password Length(by default is 0): ");
                string length = Console.ReadLine();
                if (DataType.IsInt(length))
                    _PasswordRules.passwordMinLength =Convert.ToInt16(length);
            }
            Console.WriteLine("Enter y for password symbols check(by default is false): ");
            _PasswordRules.HasSymbols = IsBoolean(Console.ReadLine());
            if (_PasswordRules.HasSymbols)
            {
                Console.WriteLine("Enter symbols with comma separator: ");
                _PasswordRules.symbols = Console.ReadLine();
            }
            _passwordValidator.ValidatPassword(_PasswordRules);
        }

        private static void ComparisonValidatorManager()
        {
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("2 To compare tow numbers \t 3 To compare three numbers");
            string CountOfNumbersToCompare = Console.ReadLine();
            ComparisonValidator _ComparisonValidator = new ComparisonValidator();
            ComparisonData _ComparisonData = new ComparisonData();
            Console.WriteLine("Enter value to check: ");
            _ComparisonData.valueToCheck = Console.ReadLine();
            if (CountOfNumbersToCompare == "2")
            {
                Console.WriteLine("Enter value to compare: ");
                _ComparisonData.comparisonValue = Console.ReadLine();
            }
            else if (CountOfNumbersToCompare == "3")
            {
                Console.WriteLine("Enter minimun comparison value: ");
                _ComparisonData.minValue = Console.ReadLine();
                Console.WriteLine("Enter maximaum comparison value: ");
                _ComparisonData.maxValue = Console.ReadLine();
            }
            _ComparisonValidator.Validat(_ComparisonData, CountOfNumbersToCompare);
        }
        private static bool IsBoolean(string r)
        {
            if (r.ToLower() == "y")
                return true;
            return false;
        }
       
    }
}
