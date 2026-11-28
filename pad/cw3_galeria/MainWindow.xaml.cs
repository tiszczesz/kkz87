using cw3_galeria.Models;
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


namespace cw3_galeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImagesRepo _repo;
        private int _currentIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            _repo = new ImagesRepo("images.json");
            List<Models.MyImage> images = _repo.GetImages();
            LoadSource(images[0]);
        }
        private void LoadSource(Models.MyImage image)
        {
            string pathRel = System.IO.Path.Combine("Images", image.filename);
            //string path = System.IO.Path.Combine(
            //        AppContext.BaseDirectory, "Images", 
            //        image.filename);

            //if (!System.IO.File.Exists(path))
            //{
            //    MessageBox.Show($"Nie znaleziono pliku: {path}");
            //    return;
            //}

            ImageControl.Source = new BitmapImage(
                new Uri(pathRel, UriKind.Relative)
                );
        }

        private void GetRandomImage(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            List<Models.MyImage> images = _repo.GetImages();
            _currentIndex = rand.Next(images.Count);
            var randomImage = images[_currentIndex];
            LoadSource(randomImage);
        }

        private void Btn_Prev(object sender, RoutedEventArgs e)
        {
            List<Models.MyImage> images = _repo.GetImages();
            if (images.Count == 0) { 
                _currentIndex = images.Count - 1; 
            } else { 
                _currentIndex = (_currentIndex - 1 + images.Count) % images.Count; 
            }
            LoadSource(images[_currentIndex]);
        }

        private void BtnNext(object sender, RoutedEventArgs e)
        {
            List<Models.MyImage> images = _repo.GetImages();
            _currentIndex = (_currentIndex + 1) % images.Count;
            LoadSource(images[_currentIndex]);
        }

        private void BtnNewWindow(object sender, RoutedEventArgs e)
        {
            new WindowGallery(_repo).ShowDialog();  
        }
    }
}