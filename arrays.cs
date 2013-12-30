using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().task1();
        }

        bool correctAnswer(string answer)
        {
            Console.WriteLine("your answer was {0}, and it's correct!", answer);
            return false;
        }

        bool fail(string answer, string correct, ref int tries)
        {
            
            Console.WriteLine("no dude, not {0} is the correct answer :( ", answer);
            if (tries == 3)
            {
                Console.WriteLine("the correct answer is: {0}", correct);
                return false;
            }
            Console.WriteLine("try again! You have {0} tries left",3-tries);
            tries++;
            return true;
        }


        public void task1()
        {
            string task1 = "task 1\n" +
            "answer these questions WITHOUT COMPILING THEM\n" +
            "given the following code that displays the variable 'i'.\n" +
            "What is the LAST number?\n";
            string codeForTask1 = "int[] array0 = new int[5];\n\n" +
            "for (int i=0;i<array0.length();i++) {\n" +
                "\tConsole.writeline(i);\n" +
            "}\n";

            Console.WriteLine(task1);
            Console.WriteLine(codeForTask1);
            int answer1 = -1;
            try { answer1 = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine("for real? no input dude...");/* hehe */ }

            int cAnswer = -1 ;
            int[] array0 = new int[5];
            for (int i = 0; i < array0.Length; i++)
            {
                cAnswer = i;
            }

            int tries = 0;
            bool hasMoreTries = true;
            while (hasMoreTries)
            {
               hasMoreTries = (cAnswer == answer1 ) ? correctAnswer(Convert.ToString(answer1)) : fail(Convert.ToString(answer1), Convert.ToString(cAnswer),ref tries);
               try { answer1 = Convert.ToInt32(Console.ReadLine()); }
               catch (Exception e) { Console.WriteLine("for real? no input dude...");/* hehe */ }
            }

            answer1 = Convert.ToInt32(Console.ReadLine());
        }
    }
}
