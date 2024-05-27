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

        public void Mozgas(char[,] terkep, int tsor, int toszlop, char fal, char start)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.W && terkep[tsor - 1, toszlop] != fal)
            {
                tsor--;
            }
            else if (key.Key == ConsoleKey.S && terkep[tsor + 1, toszlop] != fal)
            {
                tsor++;
            }
            else if (key.Key == ConsoleKey.A && terkep[tsor, toszlop - 1] != fal && terkep[tsor, toszlop] != start)
            {
                toszlop--;
            }
            else if (key.Key == ConsoleKey.D && terkep[tsor, toszlop + 1] != fal)
            {
                toszlop++;
            }
        }
    }
}