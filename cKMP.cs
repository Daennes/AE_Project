using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE_Projekt
{
    class cKMP
    {
        List<int> prefixTable;

        //List<string> times;

        int m_Zaehler;

        public cKMP()
        {
            prefixTable = new List<int>();
            //times = new List<string>();
        }

        public int Zaehler
        {
            get { return m_Zaehler; }
        }

        public void generatePrefix(string pattern)
        {
            Console.WriteLine("generate prefix table (KMP)");

            prefixTable.Clear();
            int n = pattern.Length;
            int i = 0;
            int j = -1;

            for (int p = 0; p < n+1; p++)
                prefixTable.Add(0);

            prefixTable[i] = j;

            while(i<n)
            {
                while((j>=0) && (pattern[j] != pattern[i]))
                {
                    j = prefixTable[j];
                }

                i++;
                j++;
                prefixTable[i] = j;
            }



        }

        public void doKOMP(string pattern, string completeText)
        {
            int zaehler = 0;
            int i = 0;
            int j = 0;
            int n = pattern.Length;
            int m = completeText.Length;

            while (i < m)
            {
                while ((j >= 0) && completeText[i] != pattern[j])
                {
                    j = prefixTable[j];
                }

                i++;
                j++;

                if (j == n)
                {
                    zaehler++;
                    j = prefixTable[j];
                }
            }

            m_Zaehler = zaehler;

            Console.WriteLine("Pattern vorhanden(KMP): " + zaehler);

        }

        public void doKOMP1(string pattern, string completeText)
        {
            int zaehler = 0;
            int i = 0;
            int j = 0;
            int n = pattern.Length;
            int m = completeText.Length;

            while(i<(m/2))
            {
                while((j>=0) && completeText[i] != pattern[j])
                {
                    j = prefixTable[j];
                }

                i++;
                j++;

                if(j==n)
                {
                    zaehler++;
                    j = prefixTable[j];
                }
            }

            m_Zaehler = zaehler;

            Console.WriteLine("Pattern vorhanden(KMP): " + zaehler);

        }
        public void doKOMP2(string pattern, string completeText)
        {
            int zaehler = 0;
            int i = completeText.Length/2;
            int j = 0;
            int n = pattern.Length;
            int m = completeText.Length;

            while (i < m)
            {
                while ((j >= 0) && completeText[i] != pattern[j])
                {
                    j = prefixTable[j];
                }

                i++;
                j++;

                if (j == n)
                {
                    zaehler++;
                    j = prefixTable[j];
                }
            }

            m_Zaehler = zaehler;

            Console.WriteLine("Pattern vorhanden(KMP): " + zaehler);

        }
    }
}
