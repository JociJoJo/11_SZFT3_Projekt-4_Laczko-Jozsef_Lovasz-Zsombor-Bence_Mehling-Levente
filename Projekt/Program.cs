const int OSZLOP = 14;
const int SOR = 11;
const char FAL = '#';
const char UT = 'O';
const char START = 'S';
const char END = 'E';
const char BANDITA = 'b';
const char MUMIA = 'm';
const char KOVACS = 'K';
const char LADA = 'L';
char[,] terkep = new char[SOR, OSZLOP];

ConsoleKeyInfo key;
int sor = 1;
int oszlop = 0;







void Mozgás()
{
    key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.W && terkep[sor - 1, oszlop] != FAL)
    {
        sor--;
    }
    else if (key.Key == ConsoleKey.S && terkep[sor + 1, oszlop] != FAL)
    {
        sor++;
    }
    else if (key.Key == ConsoleKey.A && terkep[sor, oszlop - 1] != FAL && terkep[sor, oszlop] != START)
    {
        oszlop--;
    }
    else if (key.Key == ConsoleKey.D && terkep[sor, oszlop + 1] != FAL)
    {
        oszlop++;
    }
}