using System;
using System.Linq;

namespace Distribution
{
    public class Program
    {
        public static string Distribute(string Method, double sum, string arraySum)
        {
            
            string[] ArrayOfSums = arraySum.Split(';'); //разделяем строку по разделителю ";"

            double[] ArrayOfSumsInitial = new double[ArrayOfSums.Length];//Создаем исходный массив сумм
                for(int i = 0; i <ArrayOfSums.Length; i++)
                {
                    ArrayOfSumsInitial[i] = double.Parse(ArrayOfSums[i]);//Заполняем исходный массив
                }

            double[] ArrayOfSumsDist = new double[ArrayOfSumsInitial.Length]; //Инициализируем новый массив для выполнения распределений

            switch(Method)
            {
                case"ПРОП": //Пропорциональное распределение
                    double SumAllElements = ArrayOfSumsInitial.Sum();//Определяем сумму всех элементов массива сумм.
                    //Присваивание массиву пропорционально распределенных значений
                    ArrayOfSumsDist = ArrayOfSumsInitial.Select(a => (SumAllElements == 0) ? Math.Round(sum / ArrayOfSumsInitial.Length, 2) : Math.Round(value: (double)(sum * a / SumAllElements), 2)).ToArray();
                    //Присвоение остата последнему элементу массива.
                    ArrayOfSumsDist[ArrayOfSumsInitial.Length - 1] = Math.Round(ArrayOfSumsDist[ArrayOfSumsInitial.Length - 1] + sum - ArrayOfSumsDist.Sum(), 2);
                    break;

                case "ПЕРВ": //Реализация распределения в счёт первых элементов массива.
                    for (int i = 0; i < ArrayOfSumsInitial.Length; i++)
                    {
                        if (sum > ArrayOfSumsInitial[i])
                        {
                            ArrayOfSumsDist[i] = Math.Round(ArrayOfSumsInitial[i], 2);
                            sum -= ArrayOfSumsInitial[i];
                        }
                        else
                        {
                            ArrayOfSumsDist[i] = Math.Round(sum, 2);
                            sum -= sum;
                        }
                    }
                    break;

                case "ПОСЛ": //Реализация распределения в счёт последних элементов массива.
                    for (int i = ArrayOfSumsInitial.Length - 1; i >= 0; i--)
                    {
                        if (sum > ArrayOfSumsInitial[i])
                        {
                            ArrayOfSumsDist[i] = Math.Round(ArrayOfSumsInitial[i], 2);
                            sum -= ArrayOfSumsInitial[i];
                        }
                        else
                        {
                            ArrayOfSumsDist[i] = Math.Round(sum, 2);
                            sum -= sum;
                        }
                    }
                    break;
        

            }

            return string.Join(";", ArrayOfSumsDist); //Преобразуем массив в строку.
           


        }
    }
}
