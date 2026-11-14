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

namespace cw2_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowNewWindow(object sender, RoutedEventArgs e)
        {
            //statyczna metoda wyświetlająca okienko
            MessageBox.Show("To jest okienko jak alert w JS");
        }

        private void BtnShowSecondWindow_Click(object sender, RoutedEventArgs e)
        {
            //tworzymy instancję drugiego okna
            var secondWindow = new SecondWindow();
            //pokazujemy okno
            secondWindow.ShowDialog();
            //secondWindow.Show();
        }

        private void btnShowTime(object sender, RoutedEventArgs e)
        {
            var otherWindow = new OtherWindow();
            otherWindow.ShowDialog();
        }
    }
}