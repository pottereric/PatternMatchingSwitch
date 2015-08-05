using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternMatchingSwitch;

namespace PatternMatchingSwitch_UnitTests
{
    [TestClass]
    public class WhenSwitchingOnATupleOfBool
    {
        private Tuple<bool, bool> IsMultipleOfThreeMultipleOfFive(int i)
        {
            return new Tuple<bool, bool>(i % 3 == 0, i % 5 == 0);
        }

        [TestMethod]
        public void TestMethod1()
        {
            foreach (var i in Enumerable.Range(1, 20))
            {
                
                var value = IsMultipleOfThreeMultipleOfFive(i);

                new Switch<Tuple<bool, bool>, bool, bool>(value)
                    .Case(true, true, 
                        () => Debug.WriteLine("FizzBuzz"))
                    .Case(true, false, 
                        () => Debug.WriteLine("Fizz"))
                    .Case(false, true,  
                        () => Debug.WriteLine("Buzz"))
                    .Default(
                        () => Debug.WriteLine(i))
                    ;
            }
        }
    }
}
