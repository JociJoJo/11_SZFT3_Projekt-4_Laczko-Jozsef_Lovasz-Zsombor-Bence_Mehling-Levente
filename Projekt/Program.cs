using ProjektLib;
Random r = new Random();



Main();

void Main()
{
    const int OSZLOP = 14;
    const int SOR = 11;
    const char FAL = '#';
    const char UT = 'O';
    const char START = 'S';
    const char END = 'E';
    const char ELLENFEL = 'e';
    const char KOVACS = 'K';
    const char LADA = 'L';
    char[,] terkep = new char[SOR, OSZLOP];
    TerkepBeolvasas();

    int sor = 1;
    int oszlop = 0;

    Jatekos jatekos = new Jatekos();

    while (terkep[sor, oszlop] != END || jatekos.Eletero > 0)
    {
        Console.Clear();
        for (int i = 0; i < SOR; i++)
        {
            for (int j = 0; j < OSZLOP; j++)
            {
                if (i == sor && j == oszlop)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{terkep[i, j]} ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write($"{terkep[i, j]} ");
                }
            }
            Console.WriteLine();
        }

        switch (terkep[sor, oszlop])
        {
            case ELLENFEL:
                string ellenfel = "";
                switch (r.Next(0, 1))
                {
                    case 0: ellenfel = "bandita"; break;
                    case 1: ellenfel = "mumia"; break;
                }
                Console.WriteLine($"Egy {ellenfel} áll előtted!");
                // Harc elindítása
                break;
            case KOVACS:
                Console.WriteLine("Elérted a kovácst!");
                break;
            case LADA:
                int lada = r.Next(4, 16) * jatekos.Szerencse;
                Console.WriteLine($"Találtál egy ládát, amelyben {lada} talizmán lapult.");
                jatekos.Talizmanok += lada;
                terkep[sor, oszlop] = UT;
                break;
            default:
                break;
        }
        jatekos.Mozgas(terkep, sor, oszlop, FAL, START);
    }
}

void TerkepBeolvasas()
{
    Console.Write("Válassza ki a nehézségi szintet (könnyű, normál, nehéz): ");

    string nehezseg = Console.ReadLine()!;
    bool kivalaszva = false;

    while (!kivalaszva)
    {
        switch (nehezseg)
        {
            case "könnyű":
            case "konnyu":
                nehezseg = "konnyu"; kivalaszva = true; break;
            case "normál":
            case "normal":
                nehezseg = "normal"; kivalaszva = true; break;
            case "nehéz":
            case "nehez":
                nehezseg = "nehez"; kivalaszva = true; break;
            default:
                Console.Write("Nincsen ilyen nehézség! Kérjük ellenőrizze a helyesírását!\n\tVálassza ki a nehézségi szintet (könnyű, normál, nehéz): ");
                break;
        }
        if (!kivalaszva)
        {
            nehezseg = Console.ReadLine()!;
        }
    }

}
