using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Calculator<T>
    {
        // Делегати для арифметичних операцій
        public delegate T Operation(T a, T b);

        public Operation Add { get; set; }
        public Operation Subtract { get; set; }
        public Operation Multiply { get; set; }
        public Operation Divide { get; set; }

        public Calculator(Operation add, Operation subtract, Operation multiply, Operation divide)
        {
            Add = add;
            Subtract = subtract;
            Multiply = multiply;
            Divide = divide;
        }

        public T PerformOperation(T a, T b, Operation operation)
        {
            return operation(a, b);
        }
    }
}
