using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace erettsegi_17
{
    class Program
    {
        static int PontCalc(int f)
        {
            if(0<f && f <=5)
            {
                return 3;
            }
            if(5<f && f <=10)
            {
                return 4;
            }
            if(10<f && f <=13)
            {
                return 5;
            }
            if(13<f)
            {
                return 6;
            }
            return 0;
        }
        public static int feladat = 0;
        public static void F()
        {
            Console.WriteLine("\n" + ++feladat + ". feladatat");
        }
        static void Main(string[] args)
        {
            #region f1
            F();
            StreamReader sr = new StreamReader("valaszok.txt");
            string helyes = sr.ReadLine();
            int valaszokNum = 0;
            while(!sr.EndOfStream)
            {
                sr.ReadLine();
                valaszokNum++;
            }
            sr.BaseStream.Position = 0;
            sr.ReadLine();

            string[,] versenyzok = new string[valaszokNum, 2];

            int iterator = 0;
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                versenyzok[iterator, 0] = sor[0];
                versenyzok[iterator++, 1] = sor[1];
            }


            #endregion
            #region f2
            F();
            Console.WriteLine("{0} versenyző vett részt a versenyen.", valaszokNum);
            #endregion
            #region f3
            F();
            Console.Write("A versenyző azonosítója = ");
            string bekertVersenyzo = Console.ReadLine();
            string bekertValaszai = "";
            for (int i = 0; i < valaszokNum; i++)
            {
                if(versenyzok[i,0] == bekertVersenyzo)
                {
                    bekertValaszai = versenyzok[i, 1];
                    Console.WriteLine(versenyzok[i,1] + "\t ( a versenyző válaszai )");
                }
            }
            #endregion
            #region f4
            F();
            Console.WriteLine(helyes + "\t( a helyes megoldás )");
            for (int i = 0; i < helyes.Length; i++)
            {
                if(bekertValaszai[i] == helyes[i])
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            #endregion
            #region f5
            F();
            Console.Write("A feladat sorszáma = ");
            int bekertFeladat = int.Parse(Console.ReadLine());
            int helyesValaszokNum = 0;

            for (int i = 0; i < valaszokNum; i++)
            {
                if(versenyzok[i,1][bekertFeladat-1] == helyes[bekertFeladat-1])
                {
                    helyesValaszokNum++;
                }
            }

            double szazalek = Convert.ToDouble(helyesValaszokNum) / Convert.ToDouble(valaszokNum) * 100;

            Console.WriteLine("A feladatra {0} fő, a versenyben résztvevők {1}%-a adott helyes választ", helyesValaszokNum, Math.Round(szazalek,2));

            #endregion
            #region f6
            F();
            int[] pontok = new int[valaszokNum];
            string[] versenyzokPont = new string[valaszokNum];
            for (int i = 0; i < valaszokNum; i++)
            {
                versenyzokPont[i] = versenyzok[i, 0];
                for (int j = 0; j < helyes.Length; j++)
                {
                    if(versenyzok[i,1][j] == helyes[j])
                    {
                        pontok[i] = pontok[i] + PontCalc(j + 1);
                    }
                }
            }

            for (int i = 0; i < pontok.GetLength(0); i++)
            {
                //Ezt StreamWriter-rel kellene
                Console.WriteLine("Versenyző: {0} \tPontok: {1}", versenyzokPont[i], pontok[i]);
            }
            #endregion

            #region f7
            //Nem tökéletes megoldás mert a konzolra iratja ki, helyette fájlba kéne, de az alapvető logika benne van
            F();
            Array.Sort(pontok, versenyzokPont);
            for (int i = 0; i < pontok.GetLength(0); i++)
            {
                Console.WriteLine("Versenyző: {0} \tPontok: {1}", versenyzokPont[i], pontok[i]);
            }
            int helyezesKesz = 0;
            int elozoPont = int.MaxValue;
            int vizsgalt = versenyzokPont.Length - 1;
            while (helyezesKesz < 3)
            {
                if (elozoPont > pontok[vizsgalt])
                {
                    Console.WriteLine(pontok[vizsgalt]);
                    elozoPont = pontok[vizsgalt];
                    helyezesKesz++;
                    vizsgalt--;
                }
                if(elozoPont == pontok[vizsgalt])
                {
                    Console.WriteLine(pontok[vizsgalt]);
                    vizsgalt--;
                }
            }
            #endregion
        }
    }
}
