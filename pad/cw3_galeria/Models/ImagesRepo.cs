using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace cw3_galeria.Models
{
    public class ImagesRepo
    {
        private List<Image>? images;
        public ImagesRepo(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            images = JsonSerializer.Deserialize<List<Image>>(jsonString);
        }
        public List<Image> GetImages()
        {
            return images?? new List<Image>();
        }
    }
}
