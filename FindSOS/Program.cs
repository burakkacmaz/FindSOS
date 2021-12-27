using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS
{
    internal class Program
    {
        static void Main()
        {
            //Crates random two dimensional array.
            Random rnd = new Random();

            string[] harfler = { "s", "o", "v" };

            string[,] dizi = new string[50, 50];

            for (int i = 0; i < dizi.GetLength(0); i++)
            {
                for (int j = 0; j < dizi.GetLength(1); j++)
                {
                    int randomHarf = rnd.Next(harfler.Length);

                    dizi[i, j] = harfler[randomHarf];
                }
            }

            //Check SOS
            FindS(dizi);
            Console.ReadLine();
        }

        static void FindS(string[,] dizi)
        {
            List<int[]> SCoordinates = new List<int[]>();

            //Find S in rows
            for (int i = 0; i < dizi.GetLength(0); i++)
            {
                //Find S in columns
                for (int j = 0; j < dizi.GetLength(1); j++)
                {
                    if (dizi[i, j] == "s")
                    {
                        int[] bulunan = { i, j };
                        SCoordinates.Add(bulunan);
                    }
                }
            }
            CheckSOS(dizi, SCoordinates);
        }

        static void CheckSOS(string[,] dizi, List<int[]> SCoordinates)
        {
            string[,] yeniDizi = (string[,])dizi.Clone();
            int bulunanSOS = new int();

            for (int i = 0; i < SCoordinates.Count; i++)
            {
                //Sağı kontrol et//
                if (SCoordinates[i][1] < dizi.GetLength(1) - 2)
                {
                    int x = SCoordinates[i][0];
                    int y = SCoordinates[i][1];
                    if (dizi[x, y + 1] == "o")
                    {
                        if (dizi[x, y + 2] == "s")
                        {
                            yeniDizi[x, y] = "S";
                            yeniDizi[x, y + 1] = "O";
                            yeniDizi[x, y + 2] = "S";
                            bulunanSOS++;
                        }
                    }
                }
                //Altı kontrol et//
                if (SCoordinates[i][0] < dizi.GetLength(0) - 2)
                {
                    int x = SCoordinates[i][0];
                    int y = SCoordinates[i][1];
                    if (dizi[x + 1, y] == "o")
                    {
                        if (dizi[x + 2, y] == "s")
                        {
                            yeniDizi[x, y] = "S";
                            yeniDizi[x + 1, y] = "O";
                            yeniDizi[x + 2, y] = "S";
                            bulunanSOS++;
                        }
                    }
                }
                //Sağ üstü kontol et//
                if (SCoordinates[i][0] > 1 && SCoordinates[i][1] < dizi.GetLength(1) - 2)
                {
                    int x = SCoordinates[i][0];
                    int y = SCoordinates[i][1];
                    if (dizi[x - 1, y + 1] == "o")
                    {
                        if (dizi[x - 2, y + 2] == "s")
                        {
                            yeniDizi[x, y] = "S";
                            yeniDizi[x - 1, y + 1] = "O";
                            yeniDizi[x - 2, y + 2] = "S";
                            bulunanSOS++;
                        }
                    }
                }
                //Sağ altı kontrol et//
                if (SCoordinates[i][0] < dizi.GetLength(0) - 2 && SCoordinates[i][1] < dizi.GetLength(1) - 2)
                {
                    int x = SCoordinates[i][0];
                    int y = SCoordinates[i][1];
                    if (dizi[x + 1, y + 1] == "o")
                    {
                        if (dizi[x + 2, y + 2] == "s")
                        {
                            yeniDizi[x, y] = "S";
                            yeniDizi[x + 1, y + 1] = "O";
                            yeniDizi[x + 2, y + 2] = "S";
                            bulunanSOS++;
                        }
                    }
                }
            }

            //Finish
            for (int a = 0; a < yeniDizi.GetLength(0); a++)
            {
                for (int b = 0; b < yeniDizi.GetLength(1); b++)
                {
                    if (yeniDizi[a, b] == "S" || yeniDizi[a, b] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0, 2}", yeniDizi[a, b]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0, 2}", yeniDizi[a, b]);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("   / {0}\n", a);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Found SOSes: {0}", bulunanSOS);
        }
    }
}
