using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingSwitch
{
    public class Switch<T, T1, T2> where T : Tuple<T1, T2>
    {
        private T _switchable;
        private bool found = false;

        public Switch(T item)
        {
            _switchable = item;
        }

        public Switch<T, T1, T2> Case(T compareable, Action method )
        {
            if(compareable.Item1.Equals(_switchable.Item1) && compareable.Item2.Equals(_switchable.Item2) && !found)
            {
                method();
                found = true;
            }

            return this;
        }

        public Switch<T, T1, T2> Case(T1 compareableA, T2 comparableB, Action method)
        {
            if (compareableA.Equals(_switchable.Item1) && comparableB.Equals(_switchable.Item2) && !found)
            {
                method();
                found = true;
            }

            return this;
        }

        public void Default(Action method)
        {
            if (!found)
            {
                method();
            }
        }

    }
}
