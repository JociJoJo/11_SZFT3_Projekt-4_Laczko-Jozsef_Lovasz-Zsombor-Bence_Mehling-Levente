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
    }
}