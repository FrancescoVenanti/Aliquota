using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string loop = "a";

            while (loop != "x")
            {
                Console.WriteLine("========================================");
                Console.WriteLine("    Piccola agenzia delle entrate");
                Console.WriteLine("========================================");
                Console.WriteLine("\n");
                Console.WriteLine("Inserisci il tuo nome: ");

                // chiedo in input nome e cognome per poi chiamare il costruttore 
                string name = Console.ReadLine();
                Console.WriteLine("Inserisci il tuo cognome: ");
                string surname = Console.ReadLine();
                Contribuente c1 = new Contribuente(name, surname);
                c1.SetDataNascita();
                c1.setCodFiscale();
                c1.setSesso();


                Console.WriteLine("Inserisci il tuo comune di residenza: ");
                c1.ComuneResidenza = Console.ReadLine();

                c1.setReddito();

                Console.WriteLine("\n\n");
                c1.Output();
                Console.WriteLine("\n\n");

                // do la possibilita' di calcolare imposte di altri utenti, premento x si chiude il programma.
                Console.WriteLine("Premere un tasto per calcolare una nuova imposta o x per uscire");
                loop = Console.ReadLine().ToLower();
            }
        }
    }
}
