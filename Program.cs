namespace OefeningWekker
{
    delegate void WekkerActie();

    internal class Program
    {
        static WekkerActie alarm = new WekkerActie(Leeg);
        static Timer wekkerTimer = new Timer(AlarmGaatAf, null, Timeout.Infinite, Timeout.Infinite);
        static int alarmSeconden = 5;
        static int herhalingSec = 6;

        static void Main(string[] args)
        {
            char keuze = ' ';

            Console.WriteLine("Dit is een wekker. Kies een optie: ");
            do
            {
                Console.WriteLine("T:   Tijd instellen waarop je wekker afloopt");
                Console.WriteLine("S:   Sluimertijd instellen");
                Console.WriteLine("K:   Kies wekker type");
                Console.WriteLine("A:   Alarm stoppen");
                Console.WriteLine("P:   Programma afsluiten");

                keuze = (char)Console.Read();
                Console.ReadLine();

                switch (keuze)
                {

                    case 't':
                    case 'T':
                        Console.Write("Over hoeveel seconden alarm? ");
                        alarmSeconden = Convert.ToInt32(Console.ReadLine());
                        wekkerTimer.Change(alarmSeconden * 1000, herhalingSec * 1000);
                        break;

                    case 's':
                    case 'S':
                        Console.Write("Herhaal na hoeveel seconden? ");
                        herhalingSec = Convert.ToInt32(Console.ReadLine());
                        wekkerTimer.Change(alarmSeconden * 1000, herhalingSec * 1000);
                        break;

                    case 'k':
                        case 'K':
                        Console.WriteLine("Kies een wekker type, Hoofdletter = gebruik/Kleine letter = gebruik niet:  ");
                        Console.WriteLine("G:   Maak geluid");
                        Console.WriteLine("B:   Toon bericht");
                        Console.WriteLine("K:   Toon knipperlicht");

                        char type = (char)Console.Read();
                        Console.ReadLine();

                        switch (type)
                        {
                            case 'g':
                                alarm -= new WekkerActie(MaakGeluid);
                                break;
                            case 'G':
                                alarm += new WekkerActie(MaakGeluid);
                                break;
                            case 'b':
                                alarm -= new WekkerActie(ToonBoodschap);
                                break;
                            case 'B':
                                alarm += new WekkerActie(ToonBoodschap);
                                break;
                            case 'k':
                                alarm -= new WekkerActie(ToonKnipperlicht);
                                break;
                            case 'K':
                                alarm += new WekkerActie(ToonKnipperlicht);
                                break;
                        }
                        break;

                    case 'a':
                    case 'A':
                        wekkerTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        Console.WriteLine("Alarm gestopt");
                        break;

                    case 'p':
                    case 'P':
                        wekkerTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        Console.WriteLine("Programma wordt afgesloten...");
                        break;
                }
            } while (keuze != 'p' && keuze != 'P');

        }

        static void AlarmGaatAf(object status)
        {
            alarm();
        }

        static void MaakGeluid()
        {
            Console.Beep(800, 500);
            Console.Beep(1000, 500);
            Console.Beep(1200, 500);
        }

        static void ToonBoodschap()
        {
            Console.WriteLine("Tijd om op te staan!");
            Console.WriteLine("Tijd om op te staan!");
            Console.WriteLine("Tijd om op te staan!");
            Console.WriteLine("Tijd om op te staan!");
            Console.WriteLine("Tijd om op te staan!");
            Console.WriteLine("Tijd om op te staan!");
        }

        static void ToonKnipperlicht()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                System.Threading.Thread.Sleep(500);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                System.Threading.Thread.Sleep(500);
            }
            Console.ResetColor();
        }

        static void Leeg() { }

    }
}
