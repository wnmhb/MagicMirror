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
                RefId = "RD84151926",
                Brand = "ZIMMUR",
                Price = 229,
                Unit = PriceUnit.DOLLOAR,
                Name = "杏色七分袖优雅镂空蕾丝拼接时尚连衣裙",
                Type = ClothingType.DRESS,
                Sizes = new List<Size> { Size.small, Size.large, Size.xlarge },
                MainPhoto = @"..\Resources\Images\p1.jpg"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "RD04125596",
                Brand = "Nike",
                Price = 125,
                Unit = PriceUnit.EUR,
                Name = "Dress",
                Type = ClothingType.DRESS,
                MainPhoto = @"..\Resources\Images\p2.png"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "RD60125482",
                Brand = "Nike",
                Price = 89,
                Unit = PriceUnit.EUR,
                Name = "Dress",
                Type = ClothingType.DRESS,
                MainPhoto = @"..\Resources\Images\p3.png"
            });

            Clothings.Add(new Clothing()
            {
                RefId = "RD60124539",
                Brand = "Ladyhaha",
                Price = 89,
                Unit = PriceUnit.EUR,
                Name = "Coat",
                Type = ClothingType.DRESS,
                MainPhoto = @"..\Resources\Images\p4.jpg"
            });
            return Clothings;
        }

    }
}
