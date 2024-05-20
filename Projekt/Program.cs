﻿const int OSZLOP = 14;
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
TerkepBeolvasás();

ConsoleKeyInfo key;
int sor = 1;
int oszlop = 0;





void TerkepBeolvasás()
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

    void Mozgas()
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
}

void Térkép()
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
}