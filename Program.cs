using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AE_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 0;

            bool parallel = false;

            List<string> timesBM = new List<string>();
            List<long> timesBMint = new List<long>();
            List<int> zaehlerBM = new List<int>();

            List<string> timesKMP = new List<string>();
            List<long> timesKMPint = new List<long>();
            List<int> zaehlerKMP = new List<int>();

            string[] randNumber = { "A", "C", "G", "T" };
            string[] stdAlphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Random rand = new Random();
            rand.Next();

            Task t1;
            Task t2;

            string completeText = "";

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

            List<string> liste = new List<string>();

            try
            {
                //Console.WriteLine("try");
                completeText = System.IO.File.ReadAllText("C:\\Qt/warandpeace.txt");
                Console.WriteLine("Datei konnte geöffnet werden\n");
                //completeText = text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Datei konnte nicht geöffnet werden\n");
            }

            Console.WriteLine("Anzahl Zeichen: " + completeText.Length);
            cKMP kmp = new cKMP();
            cBM bm = new cBM();

            //string pattern = "ACAGT";
            //string pattern = "GTAGT";
            //string pattern = "ABABCABAB";
            //string pattern = "A";

            string pattern = "ACACGT";

            /*completeText = "";
                for (int l = 0; l < 50000; l++)
                {
                    completeText += randNumber[rand.Next() % 4];
                }*/

            for (int k = 0; k <= 100; k++)
            {
                //completeText = "";
                

                pattern += stdAlphabet[rand.Next() % 26];

                j = 0;
                timesBMint.Add(0);
                timesKMPint.Add(0);

                while (j <1/*j < k*/)
                {
                    Console.WriteLine("\nDurchlauf: " + j);
                    Console.WriteLine("Pattern: " + pattern + "\n");

                    
                    //if(j==0)
                        kmp.generatePrefix(pattern);
                    watch.Reset();
                    watch.Start();
                    if (parallel)
                    {
                        t1 = Task.Run(() => kmp.doKOMP1(pattern, completeText));
                        t2 = Task.Run(() => kmp.doKOMP2(pattern, completeText));
                        Task.WaitAll(t1, t2);
                    }
                    else
                        kmp.doKOMP(pattern, completeText);
                    watch.Stop();

                    Console.WriteLine("KMP (Search): " + watch.ElapsedMilliseconds + " ms\n");
                    //timesKMP.Add((watch.ElapsedMilliseconds).ToString());
                    //zaehlerKMP.Add(kmp.Zaehler)
                    timesKMPint[k] += watch.ElapsedMilliseconds;

                    
                    //if(j==0)
                        bm.generatePrefix(pattern);
                    watch.Reset();
                    watch.Start();
                    if (parallel)
                    {
                        t1 = Task.Run(() => bm.doBM1(pattern, completeText));
                        t2 = Task.Run(() => bm.doBM2(pattern, completeText));
                        Task.WaitAll(t1, t2);
                    }
                    else
                        bm.doBM(pattern, completeText);
                    watch.Stop();

                    Console.WriteLine("BM (Search): " + watch.ElapsedMilliseconds + " ms");
                    //timesBM.Add((watch.ElapsedMilliseconds).ToString());
                    //zaehlerBM.Add(bm.Zaehler);
                    timesBMint[k] += watch.ElapsedMilliseconds;

                    //pattern = "";
                    /*for(int k = 0; k < 5; k++)
                        pattern += randNumber[rand.Next() % 4];*/

                    //pattern += randNumber[rand.Next()%4];
                    //pattern += "AC";
                    

                    j++;
                }
                timesKMP.Add(timesKMPint[k].ToString());
                timesBM.Add(timesBMint[k].ToString());

            }


            //Console.WriteLine("pattern: " + pattern);

            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Qt/timesKMP.txt");

            for (int k = 0; k < timesKMP.Count; k++)
            {
                //file.WriteLine(timesKMP[k] + "\t" + zaehlerKMP[k]);
                file.WriteLine(timesKMP[k]);
            }

            file.Close();

            System.IO.StreamWriter fileZaehler = new System.IO.StreamWriter("C:\\Qt/timesBM.txt");

            for (int k = 0; k < timesBM.Count; k++)
            {
                //fileZaehler.WriteLine(timesBM[k] + "\t" + zaehlerBM[k]);
                fileZaehler.WriteLine(timesBM[k]);
            }

            fileZaehler.Close();

            /*System.IO.StreamWriter file1 = new System.IO.StreamWriter("C:\\Qt/dnaTest.txt");

            string testDNA = "";
            try
            {
                for (int k = 0; k < 50000; k++)
                {
                    testDNA += "AC";
                }
                file1.Write(testDNA);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            file1.Close();*/



        }
    }
}