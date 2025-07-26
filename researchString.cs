using System;
using System.Collections;
using System.Collections.Generic;

namespace ricecaCarattere
{
    class Program
    {
        //hashtable per divicere i caratteri delle parole e contarle
        static public Hashtable hashElaborato = new Hashtable();   // per le parole nell' arrey ricerca
        static public Hashtable hashInput = new Hashtable();       // per la parole inserta in input (in scelta)


        static public void AssegnaHashTable(string parola, int numHashtable)
        {
            Hashtable hash = new Hashtable();
            char[] sceltaDivisa = new char[parola.Length];

            for (int i = 0; i < parola.Length; i++)
            {
                sceltaDivisa[i] = parola[i];
                //System.Console.WriteLine(sceltaDivisa);
            }

            for (int x = 0; x < parola.Length; x++)
            {
                int conta = 0;
                for (int i = 0; i < parola.Length; i++)
                {
                    if (sceltaDivisa[x] == sceltaDivisa[i])
                    {
                        conta++;
                    }
                }

                //condizione per non creare chiavi doppie nell' Hashtable (se no esplode tutto)
                if (hash[sceltaDivisa[x]] == null)
                {
                    hash.Add(parola[x], conta);
                }

            }

            //1 = HashtableInput
            if (numHashtable == 1)
            {
                foreach (DictionaryEntry entry in hash)
                {
                    hashInput.Add(entry.Key, entry.Value);
                }
            }

            //!1 = HashtablElaborato
            else
            {
                foreach (DictionaryEntry entry in hash)
                {
                    hashElaborato.Add(entry.Key, entry.Value);
                }
            }



            //scrittura della hahtable
            // foreach (DictionaryEntry entry in hash)
            // {
            //     System.Console.WriteLine($"scelta: {entry.Key},  conta: {entry.Value}");
            // }

        }

        static void Main(string[] arg)
        {
            //arrey in cui inserire gli elementi da cercare
            string[] ricerca = { "alberto", "albertangelo", "ugo", "riccardo", "pino" };

            //List ricercaOttenuta = new List();

            //input da cui poi partirà la ricerca di parole simili
            string scelta;

            //ciclo doWhile per assicurarsi che scelta venga assegnata (in questo caso dovrebbe essere sempre assegnata ma in altri contesti no)
            do
            {
                System.Console.WriteLine("inserire un nome da cercare\n>>");
                scelta = Console.ReadLine();
            } while (scelta == null);

            //funzione per popolare Hastabla di Input
            AssegnaHashTable(scelta, 1);

            //ciclo per assegnare e confrontare la Hashtable Di Elaborazione (tutti gli elemnti della array Ricerca)
            foreach (string item in ricerca)
            {
                int puntegio = 0;

                AssegnaHashTable(item, 2);

                foreach (DictionaryEntry entry in hashInput)
                {
                    if (hashElaborato[entry.Key] != null)
                    {
                        puntegio++;
                        if (hashElaborato[entry.Key] == entry.Value)
                        {
                            puntegio += 3;
                            System.Console.WriteLine("hashElaborato[entry.Key] == entry.Value");
                        }
                    }
                }

                //pulisco la HashTable per la prossima parola
                hashElaborato.Clear();

                if (puntegio > 3)
                {
                    System.Console.WriteLine($"ricerca ha trovato {item} con puntegio di {puntegio}");
                }
            }
        }
    }
}
