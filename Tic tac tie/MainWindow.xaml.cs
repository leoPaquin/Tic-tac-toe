using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_tac_tie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> ListJoueurA = new List<Button>();
        private List<Button> ListJoueurB = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            JouerLeJeu();
        }

        private void ResetPartie()
        {
            ListJoueurA.Clear();
            ListJoueurB.Clear();
            foreach (var button in GridPrincipale.Children.OfType<Button>())
            {
                button.Content = null;
            }
        }
        private void Reccomencer_Partie_Click(object sender, RoutedEventArgs e)
        {
            ResetPartie();
        }
        private void JouerLeJeu()
        {
            foreach (var button in GridPrincipale.Children.OfType<Button>())
            {
                button.Click += (s, e) =>
                {
                    var btn = s as Button;
                    if (btn.Content == null)
                    {
                        if (ListJoueurA.Count == ListJoueurB.Count)
                        {
                            btn.Content = "X";
                            ListJoueurA.Add(btn);
                            if (ListJoueurA.Count >= 3)
                            {
                                VerifierGagnant();

                            }
                        }
                        else
                        {
                            btn.Content = "O";
                            ListJoueurB.Add(btn);
                            if (ListJoueurB.Count >= 3)
                            {
                                VerifierGagnant();
                            }
                        }
                    }
                };
            }
        }
        private void VerifierGagnant()
        {
            List<List<Button>> CombiGagnantes = new List<List<Button>>();
            CombiGagnantes.Add(new List<Button> { B1, B2, B3 });
            CombiGagnantes.Add(new List<Button> { B4, B5, B6 });
            CombiGagnantes.Add(new List<Button> { B7, B8, B9 });
            CombiGagnantes.Add(new List<Button> { B1, B4, B7 });
            CombiGagnantes.Add(new List<Button> { B2, B5, B8 });
            CombiGagnantes.Add(new List<Button> { B3, B6, B9 });
            CombiGagnantes.Add(new List<Button> { B1, B5, B9 });
            CombiGagnantes.Add(new List<Button> { B3, B5, B7 });

            foreach (List<Button> combination in CombiGagnantes)
            {
                foreach (Button button in combination) 
                { 
                    if(ListJoueurA.Contains(button))
                    {
                        MessageBox.Show("Le joueur A a gagné !");
                        ResetPartie();

                    }
                    else if (ListJoueurB.Contains(button))
                    {
                        MessageBox.Show("Le joueur B a gagné !");
                        ResetPartie();

                    }
                }

                if (ListJoueurA.Count + ListJoueurB.Count == 9)
                {
                    MessageBox.Show("Match nul !");
                    ResetPartie();
                }
            }
        }
    }
}