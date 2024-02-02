using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota
{
    public class Contribuente
    {
        public string Nome { get; set; }    
        public string Cognome { get; set; }

        //data di nascita viene settata con un metodo apposito
        public string DataNascita {get; set; }
        public char Sesso { get; set; }
        public string CodiceFiscale { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }
        private double Imposta { get; set; } = 0;

        public Contribuente(string nome, string cognome) 
        {
            Nome = nome;
            Cognome = cognome;
        }

        // metodo per settare dataNascita in modo da avere un formato corretto
        public void SetDataNascita()
        {
            bool isDateValid = false;
            while (!isDateValid)
            {
                try
                {
                    //chiedo all'utente di inserire 
                    Console.WriteLine("Inserisci la tua data di nascita (dd-mm-yyyy) ");
                    string userDate = Console.ReadLine();
                    //trasformo il dato inserito in formato data
                    DateTime parsedTime = DateTime.ParseExact(userDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    isDateValid = true;
                    DataNascita = parsedTime.ToString("dd/MM/yyyy");


                }
                catch { Console.WriteLine("Data inserita non valida, per favore inserisci una data valida"); }
            }
        }

        public void setSesso()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Inserisci il tuo genere (uomo, donna, altro) ");
                string gender = Console.ReadLine().ToLower();
                switch (gender)
                {
                    // setto il sesso ad un solo carattere in base alla stringa inserita
                    // avrei potuto anche far immettere direttamente un carattere, ma cosi mi sembrava piu semplice per l'utente
                    case "uomo":
                        Sesso = 'M';
                        isValid = true;
                        break;
                    case "donna":
                        Sesso = 'F';
                        isValid = true;
                        break;
                    case "altro":
                        Sesso = 'N';
                        isValid = true;
                        break;
                    default:

                        Console.WriteLine("inserisci uno tra i generi indicati");

                        break;
                }
            }
        }

        public void setCodFiscale()
        {
            bool isValid = false;
            while (!isValid)
            {
                //controllo che il codice fiscale sia di 16 cifre e poi lo setto altrimenti me lo richiede
                Console.WriteLine("Inserisci il tuo codice fiscale");
                string codFiscale = Console.ReadLine();
                if (codFiscale.Length == 16)
                {
                    CodiceFiscale = codFiscale.ToUpper();
                    isValid = true;
                }
                else { Console.WriteLine("Inserisci un codice fiscale valido"); }
            }
        }

        public void setReddito()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Inserisci il tuo reddito annuale: ");
                string input = Console.ReadLine();
                try
                {
                    RedditoAnnuale = Convert.ToDouble(input);
                    isValid = true;
                    setImposta(RedditoAnnuale);
                }
                catch { Console.WriteLine("Inserisci un valore numerico valido"); }
            }
        }

        private void setImposta(double reddito)
        {

            //in base al reddito calcolo l'imposta
            double parteEccedente;
            if (reddito <= 0)
            {
                Imposta = 0;
            }
            else if (reddito > 0 && reddito <= 15000)
            {
                Imposta = reddito / 100 * 23;
            }
            else if (reddito <= 28000)
            {
                parteEccedente = reddito - 15000;
                Imposta = parteEccedente / 100 * 27 + 3450;
            }
            else if (reddito <= 55000)
            {
                parteEccedente = reddito - 28000;
                Imposta = parteEccedente / 100 * 38 + 6960;
            }
            else if (reddito <= 75000)
            {
                parteEccedente = reddito - 55000;
                Imposta = parteEccedente / 100 * 41 + 17220;
            }
            else
            {
                parteEccedente = reddito - 75000;
                Imposta = parteEccedente / 100 * 43 + 25420;
            }

            
        }

        public void Output()
        {

            // metodo che restituisce in l'output desiderato
            Console.WriteLine("========================================");
            Console.WriteLine($"Contribuente: {Nome} {Cognome}");
            Console.WriteLine($"Nato il: {DataNascita} {Sesso}");
            Console.WriteLine($"Residente in {ComuneResidenza}");
            Console.WriteLine($"Codice fiscale: {CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale}");
            Console.WriteLine($"IMPOSTA DA VERSARE: {Imposta}");
            Console.WriteLine("========================================");
        }

    }

}
