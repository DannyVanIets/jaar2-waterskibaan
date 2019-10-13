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
        public int totalSecondsPassed = 0;

        private Waterskibaan waterskibaan;

        private WachtrijInstructie wi;
        private InstructieGroep ig;
        private WachtrijStarten ws;

        private Zwemvest zwemvest;
        private Skies skies;
        private Sporter sporter;

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstrutieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstrutieAfgelopenHandler instructieAfgelopen;

        public delegate void VerplaatsLijnenHandler();
        public event VerplaatsLijnenHandler verplaatsLijnen;

        public void Intilize()
        {
            waterskibaan = new Waterskibaan();
            wi = new WachtrijInstructie();
            ig = new InstructieGroep();
            ws = new WachtrijStarten();

            SetTimer();

            NieuweBezoeker += WachtrijBezoekerToevoegen;
            instructieAfgelopen += InstructieIsAfgelopen;
            verplaatsLijnen += LijnenWordenVerplaatst;

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
            totalSecondsPassed++;

            /*zwemvest = new Zwemvest();
            skies = new Skies();
            sporter = new Sporter(zwemvest, skies);

            waterskibaan.SporterStart(sporter);
            waterskibaan.VerplaatsKabel();

            Console.WriteLine(waterskibaan.ToString());*/

            if (totalSecondsPassed % 3 == 0)
            {
                zwemvest = new Zwemvest();
                skies = new Skies();
                sporter = new Sporter(zwemvest, skies);

                NieuweBezoeker.Invoke(new NieuweBezoekerArgs(sporter));
            }

            if (totalSecondsPassed % 4 == 0)
            {
                verplaatsLijnen.Invoke();
            }

            if (totalSecondsPassed % 20 == 0)
            {
                List<Sporter> alleWachtendeSporters = wi.SportersVerlaten(wi.GetAlleSporters().Count);
                instructieAfgelopen.Invoke(new InstructieAfgelopenArgs(alleWachtendeSporters));
            }

            Console.WriteLine(ToString());
        }

        private void WachtrijBezoekerToevoegen(NieuweBezoekerArgs args)
        {
            wi.SporterNeemPlaatsInRij(args.Sporter);
        }

        private void InstructieIsAfgelopen(InstructieAfgelopenArgs args)
        {
            if (ig.GetAlleSporters().Count > 0)
            {
                List<Sporter> instructie = ig.SportersVerlaten(ig.GetAlleSporters().Count);
                foreach (Sporter sp in instructie)
                {
                    ws.SporterNeemPlaatsInRij(sp);
                }
            }

            foreach (Sporter sp in args.sporterLijst)
            {
                ig.SporterNeemPlaatsInRij(sp);
            }
        }

        private void LijnenWordenVerplaatst()
        {
            if(waterskibaan.kabel.IsStartPositieLeeg())
            {
                List<Sporter> sporter = ws.SportersVerlaten(1);

                foreach(Sporter sp in sporter)
                {
                    waterskibaan.SporterStart(sp);
                }
            }

            waterskibaan.VerplaatsKabel();
        }

        public override string ToString()
        {
            return $"_____________________________________________________________________ \n {wi.ToString()} \n {ig.ToString()} \n {ws.ToString()}";
        }
    }
}
