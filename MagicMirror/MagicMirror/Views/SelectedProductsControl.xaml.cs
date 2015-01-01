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
using System.Collections.ObjectModel;
using MagicMirror.Models;
using System.Windows.Media.Animation;

namespace MagicMirror.Views
{
    /// <summary>
    /// SelectProducts.xaml 的交互逻辑
    /// <remarks>
    /// 选择阶段
    /// </remarks>
    /// </summary>
    public partial class SelectedProductsControl : UserControl
    {
        public SelectedProductsControl()
        {
            InitializeComponent();
            Clothings = new ObservableCollection<Clothing>();

            //lbSelectedProduces.ItemsSource = Clothings;
        }

        private ObservableCollection<Clothing> Clothings;

        public void AddClothing(Clothing product)
        {
            Clothings.Add(product);

            ListBoxItem item = new ListBoxItem();
            item.Margin = new Thickness(20, 10, 20, 10);
            Image image = new Image();
            image.Name = "image" + Clothings.Count;
            image.Source = new BitmapImage(new Uri(product.MainPhoto, UriKind.Relative));
            item.Content = image;
            lbSelectedProduces.Items.Add(item);

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName(image.Name, image);

            Storyboard storybord = new Storyboard();
            TranslateTransform translate = new TranslateTransform();
            image.RenderTransform = translate;
            this.RegisterName("translate", translate);

            DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath();
            DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath();

            if (Clothings.Count == 1)
            {
                animationX.PathGeometry = path1.Data.GetFlattenedPathGeometry();
                animationY.PathGeometry = path1.Data.GetFlattenedPathGeometry();
            }
            else {
                animationX.PathGeometry = path2.Data.GetFlattenedPathGeometry();
                animationY.PathGeometry = path2.Data.GetFlattenedPathGeometry();
            }

            animationX.Source = PathAnimationSource.X;
            animationX.Duration = new Duration(TimeSpan.FromSeconds(1));
            animationY.Source = PathAnimationSource.Y;
            animationY.Duration = animationX.Duration;
            storybord.Children.Add(animationX);
            storybord.Children.Add(animationY);

            Storyboard.SetTargetName(animationX, "translate");
            Storyboard.SetTargetName(animationY, "translate");
            Storyboard.SetTargetProperty(animationX, new PropertyPath(TranslateTransform.XProperty));
            Storyboard.SetTargetProperty(animationY, new PropertyPath(TranslateTransform.YProperty));
            storybord.AccelerationRatio = 0.5;
            //透明度动画
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 0;
            opacityAnimation.To = 1;
            opacityAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard.SetTargetName(opacityAnimation, image.Name);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(Image.OpacityProperty));

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = 0;
            SizeAnimation.To = 120;
            SizeAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard.SetTargetName(SizeAnimation, image.Name);
            Storyboard.SetTargetProperty(SizeAnimation, new PropertyPath(Image.WidthProperty));

            storybord.Children.Add(opacityAnimation);
            storybord.Children.Add(SizeAnimation);
            storybord.Completed += (s, e) =>
            {
                SoundPlayerHelper.PlaySound("Resources/Sound/notify.wav");
            };
            storybord.Begin(this);
            
        }
    }
}
