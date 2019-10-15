using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using Waterskibaan;
using System.Windows.Threading;

namespace VisualisatieWaterskibaan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            game = new Game();
            DispatcherTimer timer = new DispatcherTimer();

            game.Intilize(timer);
            timer.Tick += time_ticker;

            InitializeComponent();
        }

        void time_ticker(object sender, EventArgs args)
        {
            LabelsTonen();
            SportersOpLijnenTekenen();
            SportersWachtenOpInstructieTekenen();
            SportersInstructieGroepTekenen();
            SportersInstructionStartingTekenen();
            LaatLichsteKleurenVanSportersZien();
            UniekeMovesLatenZien();
        }

        public void LabelsTonen()
        {
            LabelAlleWachtrijen.Content = $"{game.ToString()}";

            LabelAantalSecondenVoorbij.Content = $"Aantal seconden voorbij: {game.totalSecondsPassed}";
            LabelTotaalAantalBezoekers.Content = $"Totaal aantal bezoekers: {game.logger.ReturnAlleBezoekers()}";

            LabelTotaalAantalBezoekersMetRodeKleding.Content = $"Totaal aantal bezoekers met rode kleding: {game.logger.bezoekerMetRood}";
            LabelHoogsteScore.Content = $"Hoogste score: {game.logger.HoogsteScoreVanSporter()}";

            LabelTotaalAantalRondjes.Content = $"Totaal aantal rondjes die worden gedaan: {game.logger.TotaalAantalRondjes()}";
            LabeLijnvoorraad.Content = $"{game.waterskibaan.lv.ToString()}";
        }

        public void UniekeMovesLatenZien()
        {
            CanvasUniekeMoves.Children.Clear();

            double labelAxisX = 0.0;
            double labelAxisY = 0.0;

            if (game.logger.UniekeMoves().Count > 0)
            {
                int positie = 0;
                foreach (string move in game.logger.UniekeMoves())
                {
                    Label labelUniekeMove = new Label();

                    labelUniekeMove.Width = 200;
                    labelUniekeMove.Height = 30;

                    if (move != "")
                    {
                        labelUniekeMove.Content = $"{move}";

                        labelUniekeMove.SetValue(Canvas.LeftProperty, labelAxisX);
                        labelUniekeMove.SetValue(Canvas.TopProperty, labelAxisY);

                        CanvasUniekeMoves.Children.Add(labelUniekeMove);

                        labelAxisY += 30;
                    }
                    positie++;
                }
            }
        }

        public void LaatLichsteKleurenVanSportersZien()
        {
            Top10LichsteKleuren.Children.Clear();

            double RectangleAxisX = 0.0;
            double RectangleAxisY = 0.0;

            foreach (Sporter sporter in game.logger.TienSportersMetLichsteKleur())
            {
                Rectangle lichsteKleur = new Rectangle();

                lichsteKleur.Fill = GetKleurSporter(sporter);
                lichsteKleur.Width = 50;
                lichsteKleur.Height = 50;

                lichsteKleur.SetValue(Canvas.LeftProperty, RectangleAxisX);
                lichsteKleur.SetValue(Canvas.TopProperty, RectangleAxisY);

                Top10LichsteKleuren.Children.Add(lichsteKleur);

                if (RectangleAxisX >= 200)
                {
                    RectangleAxisX = 0;
                    RectangleAxisY += 50;
                }
                else
                {
                    RectangleAxisX += 50;
                }
            }
        }

        public void SportersWachtenOpInstructieTekenen()
        {
            double CirkelAxisX = 0.0;
            double CirkelAxisY = 0.0;

            CanvasWaitingInstructions.Children.Clear();

            if (game.wi.GetAlleSporters().Count > 0)
            {
                foreach (Sporter sporter in game.wi.GetAlleSporters())
                {
                    Ellipse cirkel = new Ellipse();
                    cirkel.Fill = GetKleurSporter(sporter);

                    cirkel.Width = 20;
                    cirkel.Height = 20;

                    cirkel.SetValue(Canvas.LeftProperty, CirkelAxisX);
                    cirkel.SetValue(Canvas.TopProperty, CirkelAxisY);

                    CanvasWaitingInstructions.Children.Add(cirkel);

                    if (CirkelAxisY >= 180)
                    {
                        CirkelAxisX += 20;
                        CirkelAxisY = 0;
                    }
                    else
                    {
                        CirkelAxisY += 20;
                    }
                }
            }
        }

        public void SportersInstructieGroepTekenen()
        {
            double CirkelAxisX = 0.0;
            double CirkelAxisY = 0.0;

            CanvasInstructionGroep.Children.Clear();

            if (game.ig.GetAlleSporters().Count > 0)
            {
                foreach (Sporter sporter in game.ig.GetAlleSporters())
                {
                    Ellipse cirkel = new Ellipse();
                    cirkel.Fill = GetKleurSporter(sporter);

                    cirkel.Width = 50;
                    cirkel.Height = 50;

                    cirkel.SetValue(Canvas.LeftProperty, CirkelAxisX);
                    cirkel.SetValue(Canvas.TopProperty, CirkelAxisY);

                    CanvasInstructionGroep.Children.Add(cirkel);

                    CirkelAxisX += 50;
                }
            }
        }

        public void SportersInstructionStartingTekenen()
        {
            double CirkelAxisX = 0.0;
            double CirkelAxisY = 0.0;

            CanvasInstructieStarting.Children.Clear();

            if (game.ws.GetAlleSporters().Count > 0)
            {
                foreach (Sporter sporter in game.ws.GetAlleSporters())
                {
                    Ellipse cirkel = new Ellipse();
                    cirkel.Fill = GetKleurSporter(sporter);

                    cirkel.Width = 40;
                    cirkel.Height = 40;

                    cirkel.SetValue(Canvas.LeftProperty, CirkelAxisX);
                    cirkel.SetValue(Canvas.TopProperty, CirkelAxisY);

                    CanvasInstructieStarting.Children.Add(cirkel);

                    if (CirkelAxisY >= 160)
                    {
                        CirkelAxisX += 40;
                        CirkelAxisY = 0;
                    }
                    else
                    {
                        CirkelAxisY += 40;
                    }
                }
            }
        }

        public void SportersOpLijnenTekenen()
        {
            watercirkel.Children.Clear();

            double axisx = 0.0;
            double axisy = 0.0;

            double labelSporterMoveAxisy = 0.0;
            double labelSporterMoveAxisx = 60.0;

            foreach (Lijn lijn in game.waterskibaan.kabel._lijnen)
            {
                Rectangle rectangle = new Rectangle();
                Label labelSporterPositie = new Label();
                Label labelSporterMove = new Label();

                rectangle.Fill = GetKleurSporter(lijn.sporter);
                rectangle.Width = 60;
                rectangle.Height = 60;
                //rectangle.StrokeThickness = 2;
                //rectangle.Stroke = Brushes.Black;

                labelSporterPositie.Width = 60;
                labelSporterPositie.Height = 60;

                labelSporterMove.Width = 120;
                labelSporterMove.Height = 60;

                labelSporterPositie.Content = $"Positie: {lijn.PositieOpDeKabel}\nRondes\nTeGaan: {lijn.sporter.AantalRondenNogTeGaan}";
                labelSporterMove.Content = "";

                if (lijn.sporter.huidigeMove != null)
                {
                    labelSporterMove.Content = $"{lijn.sporter.huidigeMove.naamMove}";
                }

                watercirkel.Children.Add(rectangle);
                watercirkel.Children.Add(labelSporterPositie);
                watercirkel.Children.Add(labelSporterMove);

                rectangle.SetValue(Canvas.LeftProperty, axisx);
                rectangle.SetValue(Canvas.TopProperty, axisy);

                labelSporterPositie.SetValue(Canvas.LeftProperty, axisx);
                labelSporterPositie.SetValue(Canvas.TopProperty, axisy);

                labelSporterMove.SetValue(Canvas.LeftProperty, labelSporterMoveAxisx);
                labelSporterMove.SetValue(Canvas.TopProperty, labelSporterMoveAxisy);

                if (axisy > 239)
                {
                    axisx += 180;
                    axisy = 0;
                    labelSporterMoveAxisx += 180;
                    labelSporterMoveAxisy = 0;
                }
                else
                {
                    axisy += 60;
                    labelSporterMoveAxisy += 60;
                }
            }
        }

        public SolidColorBrush GetKleurSporter(Sporter sporter)
        {
            SolidColorBrush color = new SolidColorBrush(Color.FromArgb(sporter.KledingKleur.A, sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
            return color;
        }
    }
}
