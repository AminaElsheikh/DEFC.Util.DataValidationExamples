using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFC.Util.DataValidationExamples
{
    class Validator
    {
        public void Validat()
        {
            var foos = new[] {
            new Foo { Name = "Ben", Age = 30 },
            new Foo { Age = -1 },
            new Foo { Name = "Dorian Grey", Age = -140 }
            };

            var fooValidator = new FooValidator();

            foreach (var foo in foos)
            {
                //1
                var messages = fooValidator.Validate(foo);
                if (!messages.Any()) Console.WriteLine("Valid");
                else foreach (var message in messages) Console.WriteLine("Invalid: " + message);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    interface IFoo
    {
        int Age { get; }
        string Name { get; }
    }
    class Foo : IFoo
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    
    abstract class FooValidatorBase<T>
    {
        public class Rule
        {
            public Func<T, bool> Test { get; set; }
            public string Message { get; set; }
        }

        protected abstract IEnumerable<Rule> Rules { get; }

        public IEnumerable<string> Validate(T t)
        {
            return this.Rules.Where(r => !r.Test(t)).Select(r => r.Message);
        }
    }

    class FooValidator : FooValidatorBase<IFoo>
    {
        protected override IEnumerable<FooValidatorBase<IFoo>.Rule> Rules
        {
            get
            {
                return new Rule[] {
                new Rule { Test = new Func<IFoo,bool>(foo => foo.Age >= 0), Message = "Age must be greater than zero" },
                new Rule { Test = new Func<IFoo,bool>(foo => !string.IsNullOrEmpty(foo.Name)), Message = "Name must be provided" }
             };
            }
        }
    }
}
