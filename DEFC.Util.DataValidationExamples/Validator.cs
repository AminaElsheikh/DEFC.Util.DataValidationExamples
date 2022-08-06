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

                Console.WriteLine("Your choosen option is: ");

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
            PasswordValidator _RpasswordValidator = new PasswordValidator();
            PasswordData _PasswordData = new PasswordData();
            Console.WriteLine("Enter password to validate: ");
            _PasswordData.password = Console.ReadLine();
            Console.WriteLine("Enter confirm password: ");
            _PasswordData.confirmPassword = Console.ReadLine();
            Console.WriteLine("Enter password expected minimum length: ");
            _PasswordData.passwordMinLength = Console.ReadLine();
            Console.WriteLine("Enter symbols expected to be included in the password: ");
            _PasswordData.symbols = Console.ReadLine();
            _RpasswordValidator.Validat(_PasswordData);
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

       
    }
}
