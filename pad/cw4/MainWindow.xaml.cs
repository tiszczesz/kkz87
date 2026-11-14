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

namespace cw4
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

        private void showDateButton_Click(object sender, RoutedEventArgs e)
        {
            var currentDate = DateTime.Now;
            dateLabel.Content = $"Aktualna data: {currentDate.ToShortDateString()}";
        }

        private void Change_color(object sender, RoutedEventArgs e)
        {
             if(colorRectangle.Fill == Brushes.Red)
             {
                 colorRectangle.Fill = Brushes.Blue;
             }
             else
             {
                 colorRectangle.Fill = Brushes.Red;
             }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var result="";
            //if(textBox.Text.Length > 0)
            //{
            //    result = $"Witajcie kumie: {textBox.Text}";
            //}
            //else
            //{
            //    result = "Nie gadam z nieznajomymi";
            //}
            MessageBox.Show(textBox.Text.Length > 0 
                ? $"Witajcie kumie: {textBox.Text}" :
                "Nie gadam z nieznajomymi");
        }
    }
}