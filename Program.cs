using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SecondLessonHT
{
    class Program




    {
        static int  totalA_B (int  startDiap, int endDiap)
        {
            int total = 0;
            while ( startDiap < endDiap)
            {
                 total = startDiap;
                startDiap++;

            }
            return total;
        }




        /// <summary>
        /// Vychislenie summy cifr cisla polzovatelja
        /// </summary>
        /// <param name="userNumber"> Cislo polzovatelja </param>
        /// <returns></returns>
        static int sumOfAllNumbers (int userNumber)
        {
            if (userNumber < 10 ) /* uslovie vychoda - esli resultat menshe 10 ,
                                   * znacit v cisle 1 cifra, otdelyjat' nechego */
            {
                return userNumber;
            }
            int digit = userNumber % 10;
            int nextUserNumber = userNumber / 10;
            return digit + sumOfAllNumbers(nextUserNumber);
        }




        /// <summary>
        /// Vyvod cisel v zadannom polzovatelem diapazone
        /// </summary>
        /// <param name="uNumber1"> nachalo diapazona</param>
        /// <param name="uNumber2"> konec diapazona </param>
        static void outputUserNumber(int uNumber1, int uNumber2)
        {
           

            Console.WriteLine("Type your number 1 ");

             uNumber1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Type your number 2 ");

             uNumber2 = int.Parse(Console.ReadLine());

            int countNum = uNumber1;

            while (countNum <= uNumber2)
            {
                Console.WriteLine(countNum);
                countNum++;
            }
        }



        /// <summary>
        /// prisvojenie konstanty normalneho indeksa
        /// </summary>
        const double normalInd = 18;

        

        /// <summary>
        /// vybor najibolshego cisla iz 3
        /// </summary>
        /// <param name="a">Pervoe cislo</param>
        /// <param name="b">Vtoroe cislo</param>
        /// <param name="c">tretyje cislo</param>
        /// <returns></returns>
        static double NumberComparing (double a, double b , double c)
        {
            double max;
            if (a > b)
            {
                if (a > c)
                {
                    max = a;
                }
                else

                    max = c;
                
            }
            else
            {
                if (b > c)
                {
                    max = b;
                }
                else
                {
                    max = c;
                }

            }
            return max;
            
        }




        /// <summary>
        /// Rasscet indeksa massy tela
        /// </summary>
        /// <param name="height"> vysota </param>
        /// <param name="weight"> ves </param>
        /// <returns></returns>
        static double  weightInd(double height, double weight)
        {

           
            double Indeks = weight / Math.Pow (height, 2);
            return Indeks;
            
        }

        /// <summary>
        /// Rasschet korrektirovki vesa
        /// </summary>
        /// <param name="height"> vysota </param>
        /// <param name="weight"> ves </param>
        /// <returns></returns>
        static double weightCalc(double height, double weight)
        {
            double corWeight = (weight - (normalInd * Math.Pow(height, 2)));
            return corWeight;
        }



        /// <summary>
        /// podshet cifr v cisle
        /// </summary>
        /// <param name="msg">Vvodnye dannye o cisle polzovatelja </param>
        static void NumQuan (string msg)
        {
            int i = 0;
            foreach (char element in msg)
            {
                i++;    
            }
            Console.WriteLine($"Your have {i}  quantity of numbers");

        }



        static void Main(string[] args)
        {
           
            #region Task1
            Console.WriteLine("Type 3 numbers");
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());
           
            Console.WriteLine("Biggest number is " + NumberComparing(num1, num2, num3));

            Console.ReadLine();
            Console.Clear();


            #endregion

            #region Task 2
            Console.WriteLine("Type number");
            NumQuan(Console.ReadLine());


            Console.ReadKey();
            Console.Clear();
            #endregion

            #region task 3


            double num, sum = 0;
            do
            {
                Console.WriteLine("Type any number, except 0");
                num = double.Parse(Console.ReadLine());
                
                if (num % 2 != 0 & num > 0)
                {
                    sum += num;
                }

            }
            while (num != 0);
            Console.WriteLine($"Total {sum}");

            #endregion 




            #region Task 4
            string corrLogin = "root";
            string corrPasword = "GeekBrains";
            int tryCount = 0;




            do
            {
                Console.WriteLine("Type your login");
                string uLogin = Console.ReadLine();
                Console.WriteLine("Type your password");
                string uPassword = Console.ReadLine();
                

                if (corrLogin == uLogin & corrPasword == uPassword)
                {
                    Console.WriteLine("You've been authorised ");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password or login. Try once more.  You have " + (3 - tryCount) + " Tries  left ");
                }
                tryCount++;
            }
            while (tryCount < 3);


            Console.ReadLine();
            Console.Clear();






            #endregion


            #region task 5
            
            Console.WriteLine("Type your height in meters");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Type your weight");
            double weight = double.Parse(Console.ReadLine());
            double index = weightInd(height, weight); // ispolzyjem metod , sctitajushji indeks massy tela

            Console.WriteLine($" Your weight index is  {index}"  );

           if (index < 16)
            {
                Console.WriteLine(" You need to gain weight" + weightCalc(height, weight) + "kg");
                
                
                
            }
           else if (index < 18)
            {
                Console.WriteLine("You need to gain a little " + weightCalc(height, weight) + "kg");

            }
           else if (index > 18)
            {
                Console.WriteLine("You're fat, slow down with food. You already have " + weightCalc(height, weight) + " kg for more");
            }
           else
            {
                Console.WriteLine("You are in your best condition");
            }






            #endregion


            #region task6

            DateTime start = DateTime.Now;
            System.Threading.Thread.Sleep(20); 
            int total = 0;
            for (int count = 0; count < 1000000000; count++)
            {
                Console.WriteLine("type your number");
                int userNumber = int.Parse(Console.ReadLine());
                

                if ( userNumber % sumOfAllNumbers(userNumber) == 0 )
                {
                    total += userNumber;
                }
                else
                {
                    Console.WriteLine(" number isn't good");
                }
            }
            
            DateTime finish = DateTime.Now;
            Console.WriteLine(finish - start + "  time it takes  "  + "/n total of user numbers " + total);

            #endregion

            #region Task 7

            Console.WriteLine("Type first number ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Type second number ");
            int b = int.Parse(Console.ReadLine());

            outputUserNumber(a, b);

            Console.WriteLine($"total of your numbers  is {totalA_B(a, b)}"); 





            #endregion




        }
    }
}
