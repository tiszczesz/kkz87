using cw3_galeria.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cw3_galeria
{
    /// <summary>
    /// Interaction logic for WindoeGallery.xaml
    /// </summary>
    public partial class WindowGallery : Window
    {
        private ImagesRepo _repo;
        public WindowGallery(ImagesRepo repo=null)
        {
            InitializeComponent();
            _repo = repo??new ImagesRepo("images.json");
            GalerryLoad();
        }
       private void GalerryLoad()
        {
            List<Models.MyImage> images = _repo.GetImages();
            foreach (var image in images)
            {
                string pathRel = System.IO.Path.Combine("Images", image.filename);
                Image imgControl = new Image();
                imgControl.Source = new BitmapImage(new Uri(pathRel, UriKind.Relative));
                imgControl.Width = 300;
                imgControl.Visibility = image.category==1 ? Visibility.Visible : Visibility.Collapsed;
                imgControl.Height = 200;
                imgControl.Margin = new Thickness(5);
                WrapFlex.Children.Add(imgControl);
            }
        }
            
    }
}
