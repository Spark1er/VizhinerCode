using System;
using System.Text;

namespace ViZhinerCode
{
    class Program
    {
        static void Main()
        {
            {
                var result = "";
                var result2 = "";
                var key = "";
                int x = 0, y = 0;

                // Крейтим таблицу
                Console.WriteLine("Vizhiner Table:");
                var tabulaRecta = new char[32, 32];
                const string alfabet = "абвгдежзийклмнопрстуфхцчшщьыъэюя";
                for (var i = 0; i < 32; i++)
                {
                    for (var j = 0; j < 32; j++)
                    {
                        var shift = (j + i) % 32;
                        tabulaRecta[i, j] = alfabet[shift];
                        Console.Write(tabulaRecta[i, j]);
                    }
                    Console.WriteLine("");
                }

                //Считывание ключа и кодировка ключа по Цезарю
                Console.WriteLine("Enter key:");
                var flag = false;
                while (!flag)
                {
                    flag = true;
                    key = Console.ReadLine();
                    var crKey = key.ToCharArray();
                    for (var i = 0; i < crKey.Length; i++)
                    {
                        var code = crKey[i] + 4;
                        var a = (char)code;
                        crKey[i] = a;
                    }
                    key = new string(crKey);
                    Console.WriteLine(key);
                    if (key != null)
                        foreach (var t in key)
                        {
                            //Если элемент ключа не принадлежит алфавиту кирилицы, изменить флаг
                            if (Convert.ToInt16(t) < 1072 || Convert.ToInt16(t) > 1103)
                                flag = false;
                        }

                    if (flag == false)
                        Console.WriteLine("Error simbols");
                }

                // ШИФРОВАНИЕ
                {
                    Console.WriteLine("Enter message: ");
                    var s = Console.ReadLine();
                    Console.WriteLine("Current string: " + s, Encoding.Default);

                    //Формирование строки, длиной шифруемой, состоящей из повторений ключа
                    if (s != null)
                        for (var i = 0; i < s.Length; i++)
                        {
                            key += key?[i % key.Length];
                        }

                    //Шифрование при помощи таблицы
                    if (s != null)
                        for (var i = 0; i < s.Length; i++)
                        {
                            //Если не кириллица
                            if (s[i] < 1040 || s[i] > 1103)
                                result += s[i];
                            else
                            {
                                //Поиск в первом столбце строки, начинающейся с символа ключа
                                var l = 0;
                                flag = false;
                                //Пока не найден символ
                                while (l < 32 && flag == false)
                                {
                                    //Если символ найден
                                    if (key != null && key[i] == tabulaRecta[l, 0])
                                    {
                                        //Запоминаем в х номер строки
                                        x = l;
                                        flag = true;
                                    }

                                    l++;
                                }

                                s = s.Replace(" ", "");
                                s = s.ToLower();
                                l = 0;
                                flag = false;
                                //Пока не найден столбец в первой строке с символом строки
                                while (l < 32 && flag == false)
                                {
                                    //Проверка совпадения
                                    if (s[i] == tabulaRecta[0, l])
                                    {
                                        //Запоминаем номер столбца
                                        y = l;
                                        flag = true;
                                    }

                                    l++;
                                }

                                result += tabulaRecta[x, y];
                            }
                        }

                    Console.WriteLine("Encoded string: " + result);
                }

                ////ДЕШИФРОВАНИЕ
                //{
                //    var s2 = result;
                //    Console.WriteLine("Строка дешифрования: " + s2, Encoding.Default);
                //    //Формирование строки, длиной шифруемой, состоящей из повторений ключа
                //    for (var i = 0; i < s2.Length; i++)
                //    {
                //        key += key?[i % key.Length];
                //    }
                //    //Дешифрование при помощи таблицы
                //    for (var i = 0; i < s2.Length; i++)
                //    {
                //        //Если не кириллица
                //        if (s2[i] < 1040 || s2[i] > 1103)
                //            result2 += s2[i];
                //        else
                //        {
                //            //Поиск в первом столбце строки, начинающейся с символа ключа
                //            var l = 0;
                //            flag = false;
                //            //Пока не найден символ
                //            while (l < 32 && flag == false)
                //            {
                //                //Если символ найден
                //                if (key != null && key[i] == tabulaRecta[l, 0])
                //                {
                //                    //Запоминаем в х номер строки
                //                    x = l;
                //                    flag = true;
                //                }
                //                l++;
                //            }
                //            l = 0;
                //            flag = false;
                //            //Пока не найден столбец в первой строке с символом строки
                //            while (l < 32 && flag == false)
                //            {
                //                //Проверка совпадения
                //                if (s2[i] == tabulaRecta[x, l])
                //                {
                //                    //Запоминаем номер столбца
                //                    y = l;
                //                    flag = true;
                //                }
                //                l++;
                //            }
                //            result2 += tabulaRecta[0, y];
                //        }
                //    }
                //    Console.WriteLine("Строка дешифрована: " + result2);
                //}
                Console.ReadLine();
            }
        }
    }
}

