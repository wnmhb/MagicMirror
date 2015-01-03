using System;
using System.Collections.Generic;
using System.Linq;
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
using MagicMirror.Models;
using System.Windows.Media.Animation;

namespace MagicMirror.Views
{
    /// <summary>
    /// ProductTryingOnControl.xaml 的交互逻辑
    /// <remarks>
    /// 试穿阶段
    /// </remarks>
    /// </summary>
    public partial class ProductTryingOnControl : UserControl
    {
        public ProductTryingOnControl(Clothing ClothTringOn)
        {
            InitializeComponent();
            this.ClothTringOn = ClothTringOn;
            (this.Resources["LoadStoryboard"] as Storyboard).Begin(this);
        }

        private Clothing clothTringOn;

        public Clothing ClothTringOn { 
            set {
                clothTringOn = value;
                this.DataContext = ClothTringOn;
            }
            get {
                return clothTringOn;
            }
        }
    }
}
