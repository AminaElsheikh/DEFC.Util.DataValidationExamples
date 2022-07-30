using System;
using System.Collections.Generic;
using System.Linq;
using DEFC.Util.DataValidation;


namespace DEFC.Util.DataValidationExamples
{
     class Program
    {
        static void Main(string[] args)
        {            
            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("1 For Data type validation \t 2 For Comparison Validation \t 3 For Password Validation");
            Console.WriteLine("4 For Math validation \t 5 For RegularExpression Validation \t 6 For SQLInjection Validation");
            StartRound("Y");

        }

        private static void StartRound(string StartNew)
        {
            Console.WriteLine("-----------------------------------\n");

            if (StartNew.ToLower() == "y")
            {
                Console.WriteLine("Your choosen option is: ");

                byte ValidationType = Convert.ToByte(Console.ReadLine());

                ExecuteValidation(ValidationType);
            }
            else
                Console.WriteLine("**************Finish*************");

            Console.ReadLine();
        }

        private static void ExecuteValidation(byte ValidationType)
        {
            Console.WriteLine("Enter value to validate: ");
            string val = Console.ReadLine();

            // Use a switch statement to do the math.
            switch (ValidationType)
            {
                case 1:
                    DataTypeValidator _DTValidator = new DataTypeValidator();
                    _DTValidator.Validat(val);
                    break;
                case 2:
                    Console.WriteLine($"Wait for Comparison CODE");
                    break;
                case 3:
                    Console.WriteLine($"Wait for Password CODE");
                    break;
                case 4:
                    MathValidator _MDValidator = new MathValidator();
                    _MDValidator.Validat(val);
                    break;
                case 5:
                    Console.WriteLine($"Wait for RegularExpression CODE");
                    break;
                case 6:
                    Console.WriteLine($"Wait for SQLInjection CODE");
                    break;
                default:
                    Console.WriteLine($"Your choice is out of process");
                    break;
            }
           
                    Console.WriteLine("Want to start new round(Y/N)");
                    StartRound(Console.ReadLine());
        }
    }
}
