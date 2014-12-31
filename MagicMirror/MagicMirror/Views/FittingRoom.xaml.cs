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
using System.Threading;
using System.Media;

namespace MagicMirror.Views
{
    /// <summary>
    /// FittingRoom.xaml 的交互逻辑
    /// </summary>
    public partial class FittingRoom : UserControl
    {
        //数据模型层
        private ClothingViewModel viewModel = new ClothingViewModel();
        //数据服务
        private DataService dataservie = new DataService();
        //初始化为服装选择阶段
        private ProcessState processState = ProcessState.Selecting;
        //商店可供选择的服装
        private ObservableCollection<Clothing> selectableClothings;

        public FittingRoom()
        {
            InitializeComponent();

            this.DataContext = viewModel;

            selectableClothings = dataservie.GetClothings();
            cbAllProducts.ItemsSource = selectableClothings;
            //顾客选择的作为试穿的服装列表
            lbSelProducts.ItemsSource = viewModel.Clothings;

            //默认加载选择的服装列表
            mainGrid.Children.Add(new SelectedProductsControl());
        }

        /// <summary>
        /// 切换服装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clothing selectedCloth = lbSelProducts.SelectedItem as Clothing;
            ProductTryingOnControl productControl;
            if (!(this.mainGrid.Children[0] is ProductTryingOnControl))
            {
                this.mainGrid.Children.Clear();
                productControl = new ProductTryingOnControl(selectedCloth);
                this.mainGrid.Children.Add(productControl);
            }
            else
            {
                productControl = this.mainGrid.Children[0] as ProductTryingOnControl;
                productControl.ClothTringOn = selectedCloth;
            }
        }

        #region ===显示|隐藏控制===

        private void btnHideOrShow_Checked(object sender, RoutedEventArgs e)
        {
            PlaySound(Config.SwitchSound);

            tbFittingRooomTitle.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Hidden;
            lbSelProducts.Visibility = Visibility.Hidden;
        }

        private void btnHideOrShow_Unchecked(object sender, RoutedEventArgs e)
        {
            PlaySound(Config.SwitchSound);

            tbFittingRooomTitle.Visibility = Visibility.Visible;
            mainGrid.Visibility = Visibility.Visible;
            lbSelProducts.Visibility = Visibility.Visible;
        }

        private void PlaySound(string soundFile)
        {
            if (string.IsNullOrEmpty(soundFile)) return;
            Thread playThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(soundFile);
                    player.Play();
                    player.Dispose();
                }
                catch { }
            }));
            playThread.Start();
        }

        #endregion

        #region ===系统感应区模拟测试===
        /// <summary>
        /// 将产品添加到试穿列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selIndex = cbAllProducts.SelectedIndex;
            if (selIndex == -1)
                return;
            viewModel.Clothings.Add(selectableClothings.ElementAt(selIndex));
            
            selectableClothings.RemoveAt(selIndex);
        }

        #endregion

        /// <summary>
        /// 窗口关闭释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
