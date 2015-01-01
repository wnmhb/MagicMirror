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
            tbFittingRooomTitle.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Hidden;
        }

        private void btnHideOrShow_Unchecked(object sender, RoutedEventArgs e)
        {
            tbFittingRooomTitle.Visibility = Visibility.Visible;
            mainGrid.Visibility = Visibility.Visible;
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
            if (selIndex == -1) return;
            if (processState == ProcessState.Selecting)
            {
                //说明系统处于初始化状态，此时显示的是服装选择界面
                SelectedProductsControl selectingContol = this.mainGrid.Children[0] as SelectedProductsControl;
                selectingContol.AddClothing(selectableClothings.ElementAt(selIndex));
                lbSelProducts.Visibility = Visibility.Hidden;
            }
            else {
                lbSelProducts.Visibility = Visibility.Visible;
            }
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
