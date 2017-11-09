using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE_Projekt
{
    class cBM
    {

        Dictionary<string, int> prefixTable;

        int m_Zaehler;

        public cBM()
        {
            prefixTable = new Dictionary<string, int>();
            //times = new List<string>();
            m_Zaehler = 0;
        }

        public int Zaehler
        {
            get { return m_Zaehler; }
        }

        public void generatePrefix(string pattern)
        {
            Console.WriteLine("generate bad-match-table (BM)");

            prefixTable.Clear();
            int m = pattern.Length;


            for (int i =0; i < m;i++)
            {
                
                if (i == 0)
                {
                    prefixTable.Add(pattern[i].ToString(), m - i - 1);
                }
                else
                {
                    try
                    {

                        foreach (KeyValuePair<string, int> entry in prefixTable)
                        {
                            if (entry.Key == pattern[i].ToString())
                            {
                                if (i == (m - 1))
                                    break;
                                else
                                    prefixTable[entry.Key] = m - i - 1;
                                break;
                            }
                            else if(entry.Key == prefixTable.Keys.Last())
                            {
                                if(i == (m - 1))
                                    prefixTable.Add(pattern[i].ToString(), m);
                                else
                                    prefixTable.Add(pattern[i].ToString(), m - i - 1);
                                break;
                            }
                        }

                        if (i == (m - 1))
                        {
                            prefixTable.Add("*", m);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
        }

        public void doBM(string pattern, string completeText)
        {
            int m = pattern.Length;
            int n = completeText.Length;
            int i = m - 1;
            int j = m - 1;
            int k = i;      //feste anfangsindex variable
            int zaehler = 0;

            while (i <= n - 1)
            {
                try
                {
                    if (pattern[j] == completeText[i])
                    {
                        if (j == 0)
                        {
                            j = m - 1;
                            i = k + 1;
                            k = i;
                            zaehler++;
                        }
                        else
                        {
                            j--;
                            i--;
                        }
                    }

                    else
                    {
                        if (prefixTable.ContainsKey(completeText[i].ToString()))
                        {
                            //i = i + m - prefixTable[completeText[i].ToString()];
                            i = k + prefixTable[completeText[i].ToString()];
                            k = i;
                        }
                        else
                        {
                            if (prefixTable.ContainsKey(completeText[k].ToString()))
                                i = k + prefixTable[completeText[k].ToString()];

                            else
                                i = k + m;
                            k = i;
                        }

                        j = m - 1;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


            }

            Console.WriteLine("Pattern vorhanden(BM): " + zaehler);
            m_Zaehler = zaehler;

        }


        public void doBM1(string pattern ,string completeText)
        {
            int m = pattern.Length;
            int n = completeText.Length;
            int i = m - 1;
            int j = m - 1;
            int k = i;      //feste anfangsindex variable
            int zaehler = 0;

            while(i <= n/2-1)
            {
                try
                {
                    if (pattern[j] == completeText[i])
                    {
                        if (j == 0)
                        {
                            j = m - 1;
                            i = k + 1;
                            k = i;
                            zaehler++;
                        }
                        else
                        {
                            j--;
                            i--;
                        }
                    }

                    else
                    {
                        if (prefixTable.ContainsKey(completeText[i].ToString()))
                        {
                            //i = i + m - prefixTable[completeText[i].ToString()];
                            i = k + prefixTable[completeText[i].ToString()];
                            k = i;
                        }
                        else
                        {
                            if (prefixTable.ContainsKey(completeText[k].ToString()))
                                i = k + prefixTable[completeText[k].ToString()];

                            else
                                i = k + m;
                            k = i;
                        }

                        j = m - 1;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


            }

            Console.WriteLine("Pattern vorhanden(BM): " + zaehler);
            m_Zaehler = zaehler;

        }


        public void doBM2(string pattern, string completeText)
        {
            int m = pattern.Length;
            int n = completeText.Length;
            int i = m - 1 + n/2;
            int j = m - 1;
            int k = i;      //feste anfangsindex variable
            int zaehler = 0;

            while (i <= n - 1)
            {
                try
                {
                    if (pattern[j] == completeText[i])
                    {
                        if (j == 0)
                        {
                            j = m - 1;
                            i = k + 1;
                            k = i;
                            zaehler++;
                        }
                        else
                        {
                            j--;
                            i--;
                        }
                    }

                    else
                    {
                        if (prefixTable.ContainsKey(completeText[i].ToString()))
                        {
                            //i = i + m - prefixTable[completeText[i].ToString()];
                            i = k + prefixTable[completeText[i].ToString()];
                            k = i;
                        }
                        else
                        {
                            if (prefixTable.ContainsKey(completeText[k].ToString()))
                                i = k + prefixTable[completeText[k].ToString()];

                            else
                                i = k + m;
                            k = i;
                        }

                        j = m - 1;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


            }

            Console.WriteLine("Pattern vorhanden(BM): " + zaehler);
            m_Zaehler = zaehler;

        }

    }

    
}


