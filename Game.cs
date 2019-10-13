using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{
    class Game
    {
        private static System.Timers.Timer aTimer;
        private Waterskibaan waterskibaan;

        public void Intilize()
        {
            waterskibaan = new Waterskibaan();
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private void SetTimer()
        {
            // Hier wordt een timer gezet dat er voor zorgt dat elke second dat hij door OnTimedEVent gaat.
            aTimer = new System.Timers.Timer(1000);
            // Hier dus.
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Zwemvest zwemvest = new Zwemvest();
            Skies skies = new Skies();
            Sporter sporter = new Sporter(zwemvest, skies);

            waterskibaan.SporterStart(sporter);
            waterskibaan.VerplaatsKabel();
            Console.WriteLine(waterskibaan.ToString());
        }
    }
}
