// C# program to illustrate the use of Delegates
using System;
using static Delegates.rectangle;

namespace Delegates
{
    class Program
    {
        // Main Method
        public static void Main(String[] args)
        {

            // creating object "obj" of class "Program"
            Program obj = new Program();

            // creating object of delegate"
            // instantiating the delegates
            addnum del_obj1 = new addnum(obj.sum);
            subnum del_obj2 = new subnum(obj.subtract);
            multiplynum del_obj3 = obj.multiplication;
            dividenum del_obj4 = obj.Division;

            // pass the values to the methods by delegate object

            del_obj1(100, 40);
            del_obj2(100, 60);
            del_obj3.Invoke(100, 50);
            del_obj4.Invoke(100, 25);

            // creating object of class "rectangle", named as "rect"
            rectangle rect = new rectangle();

            // creating delegate object, name as "rectdele"
            // and pass the method as parameter by
            // class object "rect"
            rectDelegate rectdel = new rectDelegate(rect.area);
            
            
            // call 2nd method "perimeter"
            // Multicasting
            rectdel += rect.perimeter;

            // pass the values in two method
            rectdel.Invoke(6.3, 4.2);
           
            // call methods with different values
            rectdel.Invoke(16.3, 10.3);

            //Exception Handling Using try…catch

            string[] colors = { "Red", "Blue", "Green" };

            try
            {
                // code that may raise an exception 
                Console.WriteLine(colors[5]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("An exception occurred: " + e.Message);
            }

            //Example try...catch

            int[] arr = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            try
            {

                // Try to access invalid index of array
                Console.WriteLine(arr[7]);
                // An exception is thrown upon executing
                // the above line
            }
            catch (IndexOutOfRangeException e)
            {

                Console.WriteLine("An Exception has occurred : {0}", e.Message);

            }

            //Exception Handling Using try…catch…finally

            Console.WriteLine("Enter first number:");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int secondNumber = int.Parse(Console.ReadLine());

            try
            {
                int divisionResult = firstNumber / secondNumber;
                Console.WriteLine("Division of two numbers is: " + divisionResult);
            }

            // this catch block gets executed only when an exception is raised
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred: " + e.Message);
            }

            finally
            {
                // this code is always executed whether of exception occurred or not 
                Console.WriteLine("Sum of two numbers is: " + (firstNumber + secondNumber));
            }

            //Example try…catch…finally

            int[] arr1 = { 19, 0, 75, 52 };

            try
            {

                // Try to generate an exception
                for (int i = 0; i < arr1.Length; i++)
                {
                    Console.WriteLine(arr1[i] / arr1[i + 1]);
                }
            }

            // Catch block for invalid array access
            catch (IndexOutOfRangeException e)
            {

                Console.WriteLine("An Exception has occurred : {0}", e.Message);
            }

            // Catch block for attempt to divide by zero
            catch (DivideByZeroException e)
            {

                Console.WriteLine("An Exception has occurred : {0}", e.Message);
            }

            // Catch block for value being out of range
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine("An Exception has occurred : {0}", e.Message);
            }

            // Finally block
            finally
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    Console.Write(" {0}", arr1[i]);
                }
            }

        }

        // Declaring the delegates

        public delegate void addnum(int a, int b);
        public delegate void subnum(int a, int b);
        public delegate void multiplynum(int a, int b);
        public delegate void dividenum(int a, int b);

        // method "sum"
        public void sum(int a, int b)
        {
            Console.WriteLine("Sum = {0}", a + b);
        }

        // method "subtract"
        public void subtract(int a, int b)
        {
            Console.WriteLine("Substract = {0}", a - b);
        }

        // method "multiplication"
        public void multiplication(int a, int b)
        {
            Console.WriteLine("multiplication = {0}", a * b);
        }

        // method "Division"
        public void Division(int a, int b)
        {
            Console.WriteLine("Division = {0}", a / b);
        }

    }

    // Multicasting of Delegates
    class rectangle
    {

        // declaring delegate
        public delegate void rectDelegate(double height,double width);

        // "area" method
        public void area(double height, double width)
        {
            Console.WriteLine("Area is: {0}", (width * height));
        }

        // "perimeter" method
        public void perimeter(double height, double width)
        {
            Console.WriteLine("Perimeter is: {0} ", 2 * (width + height));
        }
    }
}