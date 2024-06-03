using ProjektLib;
Random r = new Random();
Jatekos jatekos = new Jatekos();

Main();

void Main()
{
    const int OSZLOP = 15;
    const int SOR = 15;
    const char FAL = '#';
    const char UT = 'O';
    const char START = 'S';
    const char END = 'E';
    const char ELLENFEL = 'e';
    const char KOVACS = 'K';
    const char LADA = 'L';
    char[,] terkep = new char[SOR, OSZLOP];
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

        StreamReader f = new($"{nehezseg}.txt");


        for (int i = 0; i < SOR; i++)
        {
            string[] temp = f.ReadLine()!.Split(" ");
            for (int j = 0; j < OSZLOP; j++)
            {
                terkep[i, j] = char.Parse(temp[j]);
            }
        }

        int sor = 1;
        int oszlop = 0;
        int esor = 1;
        int eosz = 0;

    

    while (terkep[sor, oszlop] != END && jatekos.Eletero > 0)
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
            string n = jatekos.Ninja ? "van" : "nincs";
            string v = jatekos.Vadasz ? "van" : "nincs";
            Console.WriteLine($"\tÉleterő: {jatekos.Eletero}\tSebzés: {jatekos.Sebzes}\tTalizmánok: {jatekos.Talizmanok}\tSzerencse: {jatekos.Szerencse}\tNindzsa: {n}\tVadász: {v}");
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
                    int ehp = 3;
                    while ((jatekos.Eletero > 0) && (ehp > 0))
                    {
                        if (jatekos.Ninja)
                    {
                        int ved = r.Next(0, 4);
                        if (ved == 1)
                        {
                            if (jatekos.Vadasz)
                            {
                                int vad = r.Next(0, 3);
                                if (vad == 1)
                                {
                                    ehp = 0;
                                }
                            }
                            else
                            {
                                ehp -= jatekos.Sebzes;

                            }
                            }
                    }
                    else
                    {
                        if (jatekos.Vadasz)
                        {
                            int vad = r.Next(0, 3);
                            if (vad == 1)
                            {
                                ehp = 0;
                            }
                        }
                        else
                        {
                            ehp -= jatekos.Sebzes;
                        }
                            jatekos.Eletero--;
                    }
            }
                    
                    if (jatekos.Eletero > 0)
                {
                    int oltal = r.Next(3, 10);
                    jatekos.Talizmanok += oltal;
                    Console.WriteLine($"A {ellenfel} le lett győzve, és volt nála {oltal} talizmán!");
                    terkep[sor, oszlop] = UT;
                }
                else
                {
                    Console.WriteLine($"A {ellenfel} legyőzőtt téged");
                }
                break;
            case KOVACS:
                Console.Write("Elérted a kovácst! Megnézed miket árul?(i/n) ");
                    if (Console.ReadLine()! == "i")
                    {
                        Console.Clear();
                        Console.Write("A kovács jobb páncélt (5 talizmán), erősebb fegyverzetet (5 talizmán), és különféle passzív hatásokat (20 talizmán) árul. Mit szeretnél vásárolni?(páncél/fegyver/passzív/vissza) ");
                        switch (Console.ReadLine())
                        {
                            case "páncél":
                                if (jatekos.Talizmanok >= 5)
                                {
                                    jatekos.Eletero++;
                                    Console.WriteLine($"Sikeresen fejlesztetted a páncélodat, ezzel növelve életerődet! Jelenlegi életerő: {jatekos.Eletero}");
                                }
                                else
                                {
                                    Console.WriteLine("Sajnos erre nincs pénzed!");
                                }
                                break;
                            case "fegyver":
                                if (jatekos.Talizmanok >= 5)
                                {
                                    jatekos.Sebzes++;
                                    Console.WriteLine($"Sikeresen fejlesztetted a fegyveredet! Jelenlegi sebzés: {jatekos.Sebzes}");
                                }
                                else
                                {
                                    Console.WriteLine("Sajnos erre nincs pénzed!");
                                }
                                break;
                            case "passzív":
                                if (jatekos.Talizmanok >= 20)
                                {
                                    Console.Write("A kovács három passziv hatást árul:\n\tSzerencse: Kétszer több talizmán ládákból\n\tNindzsa: Van esély az ütés blokkolására\n\tVadász: Van esély egyből megölni az ellenfelet\n\tMelyiket szeretnéd megvásárolni?(S/N/V/kilépés) ");
                                    switch (Console.ReadLine())
                                    {
                                        case "S": Szerencse(); break;
                                        case "N": Ninja(); break;
                                        case "V": Vadasz(); break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sajnos erre nincs pénzed!");
                                }
                                break;
                            default:
                                break;
                        }
                        sor = esor;
                        oszlop = eosz;
                        break;
                    }
                    else
                    {
                        sor = esor;
                        oszlop = eosz;
                        break;
                    }
            case LADA:
                int lada = r.Next(4, 16) * jatekos.Szerencse;
                Console.WriteLine($"Találtál egy ládát, amelyben {lada} talizmán lapult.");
                jatekos.Talizmanok += lada;
                terkep[sor, oszlop] = UT;
                break;
            default:
                break;
        }
        jatekos.Mozgas(terkep, ref sor,ref oszlop,ref esor,ref eosz, FAL, START);
    }
        Console.Clear();  
        if (terkep[sor,oszlop] == 'E')
        {
            Console.WriteLine($"Gratulálunk, kijutottál a labirintusból!\n\tA Pontszámod: {jatekos.Pont}");
        }
        else if (jatekos.Eletero <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Vesztettél!");
            Console.ForegroundColor = ConsoleColor.White;
        }

}
void Szerencse()
{
    jatekos.Szerencse *= 2;
}
void Ninja()
{
    jatekos.Ninja = true;
}
void Vadasz()
{
    jatekos.Vadasz = true;
}
}
