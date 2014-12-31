using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicMirror.Models;
using System.Collections.ObjectModel;

namespace MagicMirror
{
    public class DataService
    {
        public ObservableCollection<Clothing> GetClothings()
        {
            ObservableCollection<Clothing> Clothings = new ObservableCollection<Clothing>();
            Clothings.Add(new Clothing()
            {
                RefId = "2014-5630",
                Brand = "Nike",
                Price = 195,
                Unit = PriceUnit.EUR,
                Name = "Jacket",
                Type = ClothingType.JACKET,
                MainPhoto = @"..\Images\Flower1.jpg"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "2014-5631",
                Brand = "Nike",
                Price = 125,
                Unit = PriceUnit.EUR,
                Name = "Jacket",
                Type = ClothingType.JACKET,
                MainPhoto = @"..\Images\Winter1.jpg"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "2014-4538",
                Brand = "Nike",
                Price = 89,
                Unit = PriceUnit.EUR,
                Name = "Jacket",
                Type = ClothingType.JACKET,
                MainPhoto = @"..\Images\Leaf1.jpg"
            });
            return Clothings;
        }

    }
}
