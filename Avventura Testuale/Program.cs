using System;
using System.Collections.Generic;
using System.Threading;

namespace Avventura_Testuale
{
    class Program
    {
        static int path = 1;
        static bool endgame = false;
        static int i1 = 0;
        static int i2 = 0;
        static string choice;
        static void Main(string[] args)
        {
            // PATH 1

            string p1_0 = "\nBene, prima di cominciare inserisci il tuo nome: ";
            string p1_1 = "\nHai avuto una giornata difficile a lavoro e sei nella strada di ritorno per casa. " +
                "All'improvviso ti accorgi di poter ridurre la durata del tragitto passando per un bosco alla tua sinistra. " +
                "Vuoi andare a sinistra per il bosco oppure continuare dritto? (sinistra / dritto)\n";
            string p1_2 = "\nContinuando un pò più avanti intravedi un uomo sdariato a terra cosa vuoi fare (avvicinati / continua)\n";
            string p1Lose = "\nOh no era uno zombi e sei stato mangiato... HAI PERSO!";
            string p1Win = "\nOttima scelta, l'uomo era uno zombie. Correndo via sei riuscito ad arrivare a casa sano e salvo... " +
                "HAI VINTO!";

            // PATH 2
            
            string p2_0 = "\nContinuando per il bosco ti ritrovi difronte ad un orso, rimani impietrito dalla paura e cadi a terra " +
                "lasciando avvicinare l'orso. Presto... cosa scegli di fare, prendere il bastone tubo d'acciaio accanto a te ed " +
                "attaccarlo oppure fingersi morto? (attacca / fingiti morto)\n";
            string p2Lose = "\nTubo d'acciaio non ha effetto, l'orso sentendosi in pericolo ti ha attaccato uccidendoti... HAI PERSO!";
            string p2Win = "\nOttima scelta, dopo aver aspettato per un pò l'orso ha deciso di andarsene e sei riuscito a tornare " +
                "a casa sano e salvo... HAI VINTO!";

            List<string> p1 = new List<string> { p1_0 , p1_1, p1_2, p1Lose, p1Win};
            List<string> p2 = new List<string> { p2_0, p2Lose, p2Win };

            Path path1 = new Path(p1);
            Path path2 = new Path(p2);

            charByChar("Ciao giocatore, vuoi iniziare una nuova partita? (si / no)\n");
            isValidChoice("si", "no");

            if (choice == "no")
                return;

            while (!endgame)
            {
                if (path == 1)
                {
                    switch (i1)
                    {
                        case 0:
                            Console.Write(path1.narrative[0]);
                            string name = Console.ReadLine();
                            charByChar("\nCiao " + name + ", Iniziamo!");
                            i1++;
                            break;

                        case 1:
                            charByChar(path1.narrative[1]);
                            isValidChoice("sinistra", "dritto");

                            if (choice == "sinistra")
                                path = 2;
                            i1++;
                            break;

                        case 2:
                            charByChar(path1.narrative[2]);
                            isValidChoice("avvicinati", "continua");

                            if (choice == "avvicinati")
                            {
                                charByChar(path1.narrative[3]);
                                endgame = true;
                            }
                            else
                            {
                                charByChar(path1.narrative[4]);
                                endgame = true;
                            }
                            i1++;
                            break;
                    }
                }

                if (path == 2)
                {
                    charByChar(path2.narrative[0]);
                    isValidChoice("attacca", "fingiti morto");

                    if (choice == "attacca")
                    {
                        charByChar(path2.narrative[1]);
                        endgame = true;
                    }
                    else
                    {
                        charByChar(path2.narrative[2]);
                        endgame = true;
                    }
                }
            }
        }

        public static void isValidChoice(string choice1, string choice2)
        {
            do
            {
                Console.Write("=> ");
                choice = Console.ReadLine();

                if (choice != choice1 && choice != choice2)
                    charByChar("Risposta non valida, Inserisci una rispota valida!");
            } while (choice != choice1 && choice != choice2);
        }

        public static void charByChar(string sentence)
        {
            char[] charArr = sentence.ToCharArray();
            foreach (char ch in charArr)
            {
                Console.Write(ch);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }
    }
}
