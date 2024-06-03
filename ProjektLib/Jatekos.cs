using System.Globalization;

namespace ProjektLib
{
    public class Jatekos
    {
        public int Eletero { get; set; }
        public int Sebzes { get; set; }
        public int Talizmanok { get; set; }
        public int Szerencse { get; set; }
        public bool Ninja { get; set; }
        public bool Vadasz {  get; set; }

        public Jatekos()
        {
            Eletero = 5;
            Sebzes = 1;
            Talizmanok = 0;
            Szerencse = 1;
            Ninja = false;
            Vadasz = false;
        }

        public void Mozgas(char[,] terkep, ref int tsor, ref int toszlop, ref int esor, ref int eoszlop, char fal, char start)
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.W && terkep[tsor - 1, toszlop] != fal)
            {
                esor = tsor;
                tsor--;
            }
            else if (key.Key == ConsoleKey.S && terkep[tsor + 1, toszlop] != fal)
            {
                esor = tsor;
                tsor++;
            }
            else if (terkep[tsor, toszlop] != start && key.Key == ConsoleKey.A && terkep[tsor, toszlop - 1] != fal)
            {
                eoszlop = toszlop;
                toszlop--;
            }
            else if (key.Key == ConsoleKey.D && terkep[tsor, toszlop + 1] != fal)
            {
                eoszlop = toszlop;
                toszlop++;
            }
        }
    }
}