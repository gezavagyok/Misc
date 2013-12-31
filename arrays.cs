using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays
{
    class Program
    {
        //int score = 0;
        public int ARRAY_LENGTH = 10000;

        static void Main(string[] args)
        {
            new Program().task2();

            Console.ReadLine();
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
            catch (Exception e) { Console.WriteLine("for real? no input dude...");/* hehe */ e.ToString(); }

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
               catch (Exception e) { Console.WriteLine("for real? no input dude...");/* hehe */ e.ToString(); }
            }

        }

        public void changeValues(ref int a,ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public void displayArray(int[] arrToDisplay)
        {
            foreach (int i in arrToDisplay)
            {
                Console.Write("[{0}] ", i);
            }
            Console.WriteLine("");
        }

        // buborékrendezés
        public void magicSort(ref int[] array1, ref int changedCntr)
        {
            bool changed=true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i + 1 < array1.Length; i++)
                {
                    if (array1[i] > array1[i + 1])
                    {
                        changeValues(ref array1[i], ref array1[i + 1]);
                        changed = true;
                        changedCntr++;
                    }
                }
            }
        }

        public void DoGezaSort(ref int[] array1, ref int changedCntr)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; i + j < array1.Length; j++)
                {
                    if (array1[i] > array1[i + j])
                    {
                        changedCntr++;
                        changeValues(ref array1[i], ref array1[i + j]);
                    }
                }
            }
        }

        public void DonaldShellSort(ref int[] arr, ref int changedCntr)
        {
            int i, j, k, tmp, num;
            num = arr.Length;
            for (i = num / 2; i > 0; i = i / 2)
            {
                for (j = i; j < num; j++)
                {
                    for (k = j - i; k >= 0; k = k - i)
                    {
                        if (arr[k + i] >= arr[k])
                            break;
                        else
                        {
                            tmp = arr[k];
                            arr[k] = arr[k + i];
                            arr[k + i] = tmp;
                            changedCntr++;
                        }
                    }
                }
            }
        }

        public void task2()
        {
            ARRAY_LENGTH = 5;
            int[] array1 = new int[ARRAY_LENGTH];

            string arrElements = "The current elements of the array: ";
            

            Random r = new Random();
            int cnt = 0;
            
            foreach(int i in array1){
                array1[cnt++] = r.Next(0,ARRAY_LENGTH);
            }
            int[] array2 = (int[])array1.Clone();
            int[] array3 = (int[])array1.Clone();

            int changedCntr=0;
            int changedCntr2=0;
            int changedCntr3=0;

            //Console.WriteLine(arrElements);
            //displayArray(array1);

            string intro = "Let's see the effectiveness of sorting algorithms. Effectiveness is about time, and time depends on swap count. Therefore, the better algorithm " +
                "makes less swaps, so it finishes earlier on the same machine. Take a look at the following array: ";
            string intro2 = "how many swaps does Bubble sort need to sort it?";
            
            Console.WriteLine(intro);
            displayArray(array1);
            Console.WriteLine(intro2);


            DoGezaSort(ref array1, ref changedCntr);
            magicSort(ref array2, ref changedCntr2);
            DonaldShellSort(ref array3, ref changedCntr3);

            //Console.WriteLine("*after sort*");
            //Console.WriteLine(arrElements);
            //displayArray(array1);
            Console.WriteLine("my own sort: {0} times occured swap, \tswaps/arraysize={1}", changedCntr, changedCntr/ARRAY_LENGTH);
            Console.WriteLine("Bubble: {0} times occured swap, \tswaps/arraysize={1}", changedCntr2, changedCntr2 / ARRAY_LENGTH);
            Console.WriteLine("Shell: {0} times occured swap, \tswaps/arraysize={1}", changedCntr3, changedCntr3 / ARRAY_LENGTH);

            Console.WriteLine("\nResults: Shell algorithm could execute the sort {0} times, while Bubble finishes only one.", changedCntr2/changedCntr3 );
        }
    }
}
