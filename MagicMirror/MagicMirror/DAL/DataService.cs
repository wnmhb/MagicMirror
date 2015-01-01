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
                RefId = "RD84151926-1",
                Brand = "ZIMMUR",
                Price = 229,
                Unit = PriceUnit.DOLLOAR,
                Name = "杏色七分袖优雅镂空蕾丝拼接时尚连衣裙",
                Type = ClothingType.JACKET,
                Sizes = new List<Size> { Size.small, Size.large, Size.xlarge },
                MainPhoto = @"..\Resources\Images\RD84151926-1.jpg"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "2014-5631",
                Brand = "Nike",
                Price = 125,
                Unit = PriceUnit.EUR,
                Name = "Jacket",
                Type = ClothingType.JACKET,
                MainPhoto = @"..\Resources\Images\Winter1.jpg"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "2014-4538",
                Brand = "Nike",
                Price = 89,
                Unit = PriceUnit.EUR,
                Name = "Jacket",
                Type = ClothingType.JACKET,
                MainPhoto = @"..\Resources\Images\Leaf1.jpg"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "2014-4539",
                Brand = "Nike",
                Price = 89,
                Unit = PriceUnit.EUR,
                Name = "Jacket",
                Type = ClothingType.JACKET,
                MainPhoto = @"..\Resources\Images\Leaf2.jpg"
            });
            return Clothings;
        }

    }
}
