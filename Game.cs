using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace Waterskibaan
{
    public class Game
    {
        private static DispatcherTimer dispatchTimer;
        public int totalSecondsPassed = 0;
        public int totaalAantalBezoekers = 0;

        public Waterskibaan waterskibaan;

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

        public void Intilize(DispatcherTimer timer)
        {
            dispatchTimer = timer;

            waterskibaan = new Waterskibaan();
            wi = new WachtrijInstructie();
            ig = new InstructieGroep();
            ws = new WachtrijStarten();

            SetTimer();

            NieuweBezoeker += WachtrijBezoekerToevoegen;
            instructieAfgelopen += InstructieIsAfgelopen;
            verplaatsLijnen += LijnenWordenVerplaatst;
        }

        private void SetTimer()
        {
            // Hier wordt een timer gezet dat er voor zorgt dat elke second dat hij door OnTimedEVent gaat.
            dispatchTimer.Interval = TimeSpan.FromSeconds(1);
            // Hier dus.
            dispatchTimer.Tick += OnTimedEvent;
            dispatchTimer.IsEnabled = true;
            dispatchTimer.Start();
        }

        private void OnTimedEvent(Object source, EventArgs e)
        {
            totalSecondsPassed++;

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
            totaalAantalBezoekers++;
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
            return $"{wi.ToString()}\n{ig.ToString()}\n{ws.ToString()}";
        }
    }
}
