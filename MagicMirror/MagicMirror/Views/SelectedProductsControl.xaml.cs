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
        public delegate void ProductSelected(string pruductRefId);
        public event ProductSelected productedSelectedHandler;

        private ObservableCollection<Clothing> Clothings;

        public void AddClothing(Clothing product)
        {
            Clothings.Add(product);

            ListBoxItem item = new ListBoxItem();
            item.Name = "product" + Clothings.Count;
            item.Margin = new Thickness(20, 10, 20, 10);
            Image image = new Image();
           
            image.Source = new BitmapImage(new Uri(product.MainPhoto, UriKind.Relative));
            item.Content = image;
            lbSelectedProduces.Items.Add(item);
            this.RegisterName(item.Name, item);

            Storyboard storybord = new Storyboard();
            //偏移动画
            TranslateTransform translate = new TranslateTransform();
            image.RenderTransform = translate;
            this.RegisterName("translate" + Clothings.Count, translate);
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

            Storyboard.SetTargetName(animationX, "translate" + Clothings.Count);
            Storyboard.SetTargetName(animationY, "translate" + Clothings.Count);
            Storyboard.SetTargetProperty(animationX, new PropertyPath(TranslateTransform.XProperty));
            Storyboard.SetTargetProperty(animationY, new PropertyPath(TranslateTransform.YProperty));
            storybord.AccelerationRatio = 0.5;
            //透明度动画
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 0;
            opacityAnimation.To = 1;
            opacityAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard.SetTargetName(opacityAnimation, item.Name);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(ListBoxItem.OpacityProperty));
            //大小动画
            DoubleAnimation sizeAnimation = new DoubleAnimation();
            sizeAnimation.From = 0;
            sizeAnimation.To = 120;
            sizeAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard.SetTargetName(sizeAnimation, item.Name);
            Storyboard.SetTargetProperty(sizeAnimation, new PropertyPath(ListBoxItem.WidthProperty));

            storybord.Children.Add(opacityAnimation);
            storybord.Children.Add(sizeAnimation);
            storybord.Completed += (s, e) =>
            {
                SoundPlayerHelper.PlaySound("Resources/Sound/notify.wav");
            };
            storybord.Begin(this);
            
        }

        private void lbSelectedProduces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //设置选中项的动画
            ListBoxItem selectedItem = lbSelectedProduces.SelectedItem as ListBoxItem;
            spDescription.Height = 0;

            Storyboard storybord = new Storyboard();
            Path path = new Path();
            for (int i = 0; i < lbSelectedProduces.Items.Count; i++)
            {
                ListBoxItem lbItem = lbSelectedProduces.Items[i] as ListBoxItem;
                PathGeometry pathGeometry = new PathGeometry();

                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(0, 0);
                PathSegmentCollection segmentCollection = new PathSegmentCollection();

                TranslateTransform translate = new TranslateTransform();
                lbItem.RenderTransform = translate;
                this.RegisterName("slidOutTranslate" + i, translate);
                DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath();
                DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath();
                if (i == lbSelectedProduces.SelectedIndex)
                {
                    //向上偏移然后居中放大动画
                    Vector refParentPos = VisualTreeHelper.GetOffset(lbItem);//相对父级的位置
                    double upDistance = refParentPos.Y - 10;
                    double horDistance = lbSelectedProduces.ActualWidth / 2 - lbItem.ActualWidth/2 - refParentPos.X;

                    segmentCollection.Add(new LineSegment() { Point = new Point(0, -upDistance) });
                    segmentCollection.Add(new LineSegment() { Point = new Point(horDistance, -upDistance) });
                    segmentCollection.Add(new LineSegment() { Point = new Point(horDistance+2, -upDistance+10) });
                    segmentCollection.Add(new LineSegment() { Point = new Point(horDistance, -upDistance) });
                }
                else
                {
                    //向下偏移并消失动画
                    segmentCollection.Add(new LineSegment() { Point = new Point(0, 100) });

                    DoubleAnimation opacityAnimation = new DoubleAnimation();
                    opacityAnimation.From = 1;
                    opacityAnimation.To = 0;
                    opacityAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(400));
                    Storyboard.SetTargetName(opacityAnimation, lbItem.Name);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(Image.OpacityProperty));

                    storybord.Children.Add(opacityAnimation);
                }
                pathFigure.Segments = segmentCollection;
                pathGeometry.Figures = new PathFigureCollection() { pathFigure };
                path.Data = pathGeometry;

                animationX.PathGeometry = path.Data.GetFlattenedPathGeometry();
                animationY.PathGeometry = path.Data.GetFlattenedPathGeometry();

                animationX.Source = PathAnimationSource.X;
                animationX.Duration = new Duration(TimeSpan.FromSeconds(1));
                animationY.Source = PathAnimationSource.Y;
                animationY.Duration = animationX.Duration;

                storybord.Children.Add(animationX);
                storybord.Children.Add(animationY);
                storybord.AccelerationRatio = 0.5;
                Storyboard.SetTargetName(animationX, "slidOutTranslate" + i);
                Storyboard.SetTargetName(animationY, "slidOutTranslate" + i);
                Storyboard.SetTargetProperty(animationX, new PropertyPath(TranslateTransform.XProperty));
                Storyboard.SetTargetProperty(animationY, new PropertyPath(TranslateTransform.YProperty));
            }
            storybord.Completed += (s, arg) =>
            {
                if (productedSelectedHandler != null)
                {
                    productedSelectedHandler(Clothings[lbSelectedProduces.SelectedIndex].RefId);
                }
            };
            storybord.Begin(this);
        }

    }
}
