//all comment and variables name are in Italian

/*
questo è un programma (in C#) che una volta scritta una parola (scritta dall' utente),
cerca parole o stringhe simili all' interno di un array (le parole all'interno di questo
array Ricerca possono essere cambiate a riga:  94).

la ricerca viene fatta con un Puntegio che (può essereregolato), quando i caratteri e 
il loro quantitativo all' interno della parola vengono confrontati il programma valuta un
puntegio di somiglianza.

Se 2 parole sono simili al 75% allera il la parola nell' array verrà scritta a schermo.
quindi l' utente puo sbagliare fino a 1 carattere su 4 per riuscie a trovare un risultato
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace ricecaCarattere
{
    class Program
    {
        //hashtable per divicere i caratteri delle parole e contarle
        static public Hashtable hashElaborato = new Hashtable();   // per le parole nell' array ricerca
        static public Hashtable hashInput = new Hashtable();       // per la parole inserta in input (in scelta)


        // funzione usata per assegnare alle Hashtable i caratteri (Key) e la quantita di volte in cui vengono ripetute nella stringa (Value)
        static public void AssegnaHashTable(string parola, int numHashtable)
        {
            //hash che poi trasferisce tutto a una delle altre 2
            Hashtable hash = new Hashtable();

            //array per dividere la stringa
            char[] sceltaDivisa = new char[parola.Length];
            //divisione della stringa nell' array
            for (int i = 0; i < parola.Length; i++)
            {
                sceltaDivisa[i] = parola[i];
                //System.Console.WriteLine(sceltaDivisa);
            }

            //ciclo per contare i caratteri e aggungerli in Hash con le loro chiavi
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

            //1 = HashtableInput (parola cercata)
            if (numHashtable == 1)
            {
                foreach (DictionaryEntry entry in hash)
                {
                    hashInput.Add(entry.Key, entry.Value);
                }
            }

            //!1 = HashtablElaborato (parola da cercare)
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
            string[] ricerca = {"alberto", "albertangelo", "ugo", "riccardo", "pino","lorenzo", "edgar", "piero", "gabriele", "mattia"}; //array modificabile

            //List ricercaOttenuta = new List();

            //input da cui poi partirà la ricerca di parole simili
            string scelta;

            //ciclo doWhile per assicurarsi che scelta venga assegnata (in questo caso dovrebbe essere sempre assegnata ma in altri contesti no)
            do
            {
                System.Console.WriteLine("inserire un nome da cercare");
                scelta = Console.ReadLine();
            } while (scelta == null);

            //funzione per popolare Hastabla di Input
            AssegnaHashTable(scelta, 1);

            //ciclo per assegnare e confrontare la Hashtable Di Elaborazione (tutti gli elemnti della array Ricerca)
            foreach (string item in ricerca)
            {
                float puntegio=0;

                //funzione richiamata perr ogni elemento nell' array Ricerca
                AssegnaHashTable(item, 2);

                //ciclo per confrontare ogni elemento di Hashinput con ogni elemento di HashElaborato
                foreach (DictionaryEntry entry in hashInput)
                {
                    //se ci sono caratteri uguali
                    if (hashElaborato[entry.Key] != null)
                    {
                        puntegio++;

                        // se il numero di caratteri è uguale
                        if (hashElaborato[entry.Key].Equals(entry.Value))
                        {
                            puntegio += 3;
                            //System.Console.WriteLine("con = true");
                        }
                    }
                }

                //pulisco la HashTable per la prossima parola
                hashElaborato.Clear();

                //divido il puntegio per la lunghezza della stringa per far diventare il puntegio un valore relativo
                puntegio /= item.Length;

                //scrivo a scermo se le parole sono simili
                if (puntegio>=3)
                {
                    System.Console.WriteLine($"ricerca ha trovato {item} con un puntegio di {puntegio}");
                }
            //     else
            //     {
            //         System.Console.WriteLine("puntegio minore di 3");
            //     }
            }
        }
    }
}
