using DEFC.Util.DataValidation;
using System;
using System.Collections.Generic; 

namespace DEFC.Util.DataValidationExamples
{
    class ComparisonData
    {
        public string valueToCheck { get; set; }
        public string minValue { get; set; }
        public string maxValue { get; set; }
        public string comparisonValue { get; set; }
    }
    class ComparisonValidator
    {
        public void Validat(ComparisonData _ComparisonData,string CountOfNumbersToCompare)
        {

            Console.WriteLine($"---------------{_ComparisonData.valueToCheck}-------------------");
            if (DataType.IsDouble(_ComparisonData.valueToCheck)
                && DataType.IsDouble(_ComparisonData.minValue)
                && DataType.IsDouble(_ComparisonData.maxValue)
                && DataType.IsDouble(_ComparisonData.comparisonValue))
            {
                if (CountOfNumbersToCompare == "2")
                {
                    var _ComparisonValidator = new Comparison2DataValidator();

                    IEnumerable<ValidatorBase<ComparisonData>.Rule> messages = _ComparisonValidator.Validate(_ComparisonData);

                    foreach (var message in messages)
                        if (message.ValidFun(_ComparisonData))
                            Console.WriteLine($"{message.CheckType} ===> " + message.ValidMessage);
                        else
                            Console.WriteLine($"{message.CheckType} ===> " + message.InValidMessage);
                }
                else if (CountOfNumbersToCompare == "3")
                {
                    var _ComparisonValidator = new Comparison3DataValidator();

                    IEnumerable<ValidatorBase<ComparisonData>.Rule> messages = _ComparisonValidator.Validate(_ComparisonData);

                    foreach (var message in messages)
                        if (message.ValidFun(_ComparisonData))
                            Console.WriteLine($"{message.CheckType} ===> " + message.ValidMessage);
                        else
                            Console.WriteLine($"{message.CheckType} ===> " + message.InValidMessage);
                }
            }
            else
                Console.WriteLine($"Value must be Number");
          
             
        }
    }

    class Comparison3DataValidator : ValidatorBase<ComparisonData>
    {
        protected override IEnumerable<ValidatorBase<ComparisonData>.Rule> Rules
        {
            get
            {
                Rule[] R = new Rule[] {
                new Rule {CheckType="Is Between 2 Values" , ValidFun = new Func<ComparisonData,bool>(fun => Comparison.IsBetween(Convert.ToDouble(fun.valueToCheck),Convert.ToDouble(fun.minValue),Convert.ToDouble(fun.maxValue))), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Between or Equal 2 Values", ValidFun = new Func<ComparisonData,bool>(fun => Comparison.IsBetweenOrEqual(Convert.ToDouble(fun.valueToCheck),Convert.ToDouble(fun.minValue),Convert.ToDouble(fun.maxValue))), InValidMessage = "No",ValidMessage = "Yes" },
             };
                return R;
            }
        }
    }
    class Comparison2DataValidator : ValidatorBase<ComparisonData>
    {
        protected override IEnumerable<ValidatorBase<ComparisonData>.Rule> Rules
        {
            get
            {
                Rule[] R = new Rule[] {
                new Rule {CheckType="Is Equal to ", ValidFun = new Func<ComparisonData,bool>(fun => Comparison.IsEqual(fun.valueToCheck,fun.comparisonValue)), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Less than or Equal to", ValidFun = new Func<ComparisonData,bool>(fun => Comparison.IsLessThanOrEqual(Convert.ToDouble(fun.valueToCheck),Convert.ToDouble(fun.comparisonValue))), InValidMessage = "No",ValidMessage = "Yes" },
                new Rule {CheckType="Is Greater than or Equal to", ValidFun = new Func<ComparisonData,bool>(fun => Comparison.IsGreaterThanOrEqual(Convert.ToDouble(fun.valueToCheck),Convert.ToDouble(fun.comparisonValue))), InValidMessage = "No",ValidMessage = "Yes" },


             };
                return R;
            }
        }
    }
}
