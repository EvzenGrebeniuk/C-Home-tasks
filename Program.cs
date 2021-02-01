using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayHelper;
using System.IO;

namespace _4_Lesson_HT_Arrays


{
    #region Task 3 
    /// <summary>
    /// Структура для проверки пароля и логина
    /// </summary>
    struct Account
    {
        public string login;
        public string password;

        /// <summary>
        /// Метод для проверки авторизации
        /// </summary>
        /// <param name="login"> логин </param>
        /// <param name="password"> пароль </param>
        /// <returns></returns>
        static bool Autorization(string login, string password)
        {
            Account accountVeryfy = LoadAccount(); // Создание переменной в которую загружаем пароль и логин  
            bool isAutorized = false;
            if (login == accountVeryfy.login && password == accountVeryfy.password)
                isAutorized = true;
            return isAutorized;
        }
        /// <summary>
        ///  попытка авторизации 
        /// </summary>
        static void Veryfication()
        {
            int count = 3;
            string login, password;

            do
            {
                Console.WriteLine($"Введите логин и пароль. У вас есть {count} попыток.");
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();

                if (Autorization(login, password))
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели верный логин и пароль.");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели неверный логин и/или пароль.");
                    count--;
                }

            } while (count > 0);

            Console.ReadKey();
        }
        static Account LoadAccount()
        {
            Account accountVeryfy;
            var fileName = AppDomain.CurrentDomain.BaseDirectory + "Account.txt";
            if (File.Exists(fileName))
            {
                StreamReader str = new StreamReader(fileName);
                accountVeryfy.login = str.ReadLine();
                accountVeryfy.password = str.ReadLine();
                return accountVeryfy;
            }
            else
            {
                throw new FileNotFoundException("Данный файл не существует ");
            }
        }



    }
    #endregion


    #region task 4

    class TwoDimArray
    {
        int arrSizeHor;
        int arrSizeVert;
        int arrFirstValue;
        int arrStepValue;

        private int[,] array; // Говорим, что класс работает с дввмерным массивом

        public TwoDimArray() // конструктор
        {

        }

        


        /// <summary>
        /// Конструктор, заполняющий массив числами в заданном диапазоне
        /// </summary>
        /// <param name="arrSize"></param>
        /// <param name="arrFirstValue"></param>
        /// <param name="arrStepValue"></param>
        public TwoDimArray(ref int arrSizeHor, ref  int arrSizeVert, ref  int arrFirstValue, ref   int arrStepValue)
        {
            array = new int[arrSizeHor, arrSizeVert];
            array[0, 0] = arrFirstValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = arrFirstValue + arrStepValue;
               
            }
            



        }

        public int[,] Array
        {
            get { return array; }
            set { array = value; }
        }

       
        public int this[int i, int j]
        {
            get { return array[i,j]; }
            set { array[i,j] = value; }
        }
        #endregion


        /// <summary>
        /// Ввод массива
        /// </summary>
        /// <returns></returns>
        public string PrintArray()
        {
            string result = " ";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j< array.GetLength(1); j++)
                {
                    Console.WriteLine($" {array[i,j]}");
                }

            }
            return result;

        }
        /// <summary>
        /// Изменение знаков елементов массива
        /// </summary>
        public void Inverse()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                Array[i,j] = -Array[i,j];
            }
        }
        /// <summary>
        /// умножение елементов массива на число
        /// </summary>
        /// <param name="mult"></param>
        public void Multi(int mult)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                Array[i,j] *= mult;
            }
        }
        /// <summary>
        /// вывод максимального лемента массива
        /// </summary>
        /// <returns></returns>
        public int[] MaxNumberElenent()
        {
            int maxNumber = Array[0,0];
            int[] max = { 0, 0 };
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 1; j < Array.GetLength(1); j++)
                {
                    if (maxNumber < Array[i, j])
                    {
                        maxNumber = Array[i, j];
                        max[0] = i;
                        max[1] = j;
                    }
                }
            }
            return max;


        }

    }

    



    class MyArray
    {
        private int []  array; // Говорим, что класс работает с одномерным массивом

        public MyArray() // конструктор
        {

        }

        #region task 2.1 Создание конструктора, заполняющего массив числами в заданном диапазоне


        /// <summary>
        /// Конструктор, заполняющий массив числами в заданном диапазоне
        /// </summary>
        /// <param name="arrSize"></param>
        /// <param name="arrFirstValue"></param>
        /// <param name="arrStepValue"></param>
        public MyArray(int arrSize, int arrFirstValue, int arrStepValue)
        {
            array = new int[arrSize];
            array[0] = arrFirstValue;
            for (int i = 1; i < arrSize; i++)
            {
                array[i] = arrFirstValue + arrStepValue;
            }



        }

        public int[] Array
        {
            get { return array; }
            set { array = value; }

        }
        /// <summary>
        /// индексное свойство для доступа к элементу массивва с модификатором private
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }
        #endregion


        /// <summary>
        /// Ввод массива
        /// </summary>
        /// <returns></returns>
        public string PrintArray()
        {
            string result = " ";
            for ( int i = 0;  i < array.Length; i++)
            {
                result += + array[i];
                
            }
            return result;

        }
        /// <summary>
        /// Изменение знаков елементов массива
        /// </summary>
        public void Inverse()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = -Array[i];
            }
        }
        /// <summary>
        /// умножение елементов массива на число
        /// </summary>
        /// <param name="mult"></param>
        public void Multi(int mult)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] *= mult;
            }
        }
        /// <summary>
        /// вывод максимального лемента массива
        /// </summary>
        /// <returns></returns>
        public int MaxCount()
        {
            int maxNumber = Array[0];
            int counterMaxNumber = 1;
            for (int i = 1; i < Array.Length; i++)
            {
                if (maxNumber < Array[i])
                {
                    maxNumber = Array[i];
                    counterMaxNumber = 1;
                }
                else if (maxNumber == Array[i])
                {
                    counterMaxNumber++;
                }
            }
            return counterMaxNumber;
        }


        #region task 2.2 Сохранение и вызов массива из файла

       public  static int [] LoadArrayFromFile (string DataFile_Name)
        {
            if (File.Exists(DataFile_Name))
            {
                StreamReader reader = new StreamReader(DataFile_Name); 
                var str =  reader.ReadLine(); // Считывает данные из файла построчно
                var arrize = int.Parse(str); // Первая строка в нашем текстовом файле - размерность массива. считываем ее 
                var a = new int[arrize]; // инициализируем массив такой же размерности
                for ( int i = 0; i < arrize; i++) // перебором считываем каждый элемент построчно
                {
                    a[i] = int.Parse(reader.ReadLine());
                }
                reader.Close(); // закрываем метод реадер
                return a; // возврращаем массив с обработанными данными


            }
            else
            {
                throw new FileNotFoundException(); 
            }
        }

        #endregion



    }




    class Program
    {


       
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        /// <param name="from">start diapazon</param>
        /// <param name="to"> end diapazon </param>
        /// <returns></returns>
        static int DiapazonRand(int from, int to)
        {
           
            Random rand = new Random((int)DateTime.Now.Ticks);
            int randomNumber = rand.Next() * (to - from) + from;
            return randomNumber;

        }


      
        static void Main(string[] args)
        {

           
           



            #region Task1 Сумма пар массива


            int from = -10000;
            int  to = 10000;
            int sumOfArrayCouples = 0;

            int[] userArray = new int[20];
            for (int i = 0; i < userArray.Length; i++)
            {
                userArray[i] = DiapazonRand(from, to);
            }
            Array.Sort(userArray);


            for (int i = 0; i < userArray.Length; i++)
            {
                if (userArray[i] % 3 != 0)
                {
                    i++;
                    if (userArray[i] % 3 !=0)
                        sumOfArrayCouples++;

                }
                   

                
                    
                    

                
            }
            Console.WriteLine($"summ of array couples = {sumOfArrayCouples}");

            

            Console.ReadLine();
            Console.Clear();
            #endregion



            #region task 2.1

            MyArray userArray2 = new MyArray(10, 12, 5);
            Console.WriteLine($" Сгенерированный массив {userArray2.PrintArray() }");

            userArray2.Inverse();
            Console.WriteLine($" изменение элементов массива {userArray2.PrintArray()}");

            MyArray userArray3 = new MyArray(20, 11, 2);


            userArray3.Multi(2);
            Console.WriteLine($"умножение массива на число {userArray3.PrintArray()}");


            Console.WriteLine($"Максимальный элемент массива {userArray3.MaxCount()}");




            #endregion

            #region task 2.2 массив с использованием подгрузочного файла

            var DataFile_Name = AppDomain.CurrentDomain.BaseDirectory + "lesson4TextFile.txt"; /*Свойство возвращает папку, из которой запускается приложение. 
                                                                                          * Склеиваем директорию и имя файла - получаем полное имя файла и возможность с ним работать */
            var arrFromFile =  MyArray.LoadArrayFromFile(DataFile_Name);
            for (int i = 0; i < arrFromFile.Length; i++)
            {
                Console.WriteLine($"{arrFromFile[i]}");
            }

            
           
           
            
            #endregion









        }
    }
}
