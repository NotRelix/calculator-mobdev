using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Calculate
    {
        public static string DoCalculation(double val1, double val2, string operandMath)
        {

            double result = 0;
            string retval;

            switch (operandMath)
            {
                case "/":
                    result = val1 / val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "x":
                    result = val1 * val2;
                    break;
                case "+":
                    result = val1 + val2;
                    break;
                default:
                    break;
            }
            if (operandMath == "/" && val2 == 0)
            {
                retval = "Math Error";
            }
            else
            {
                retval = result.ToString();
            }
            return retval;
        }
    }
}