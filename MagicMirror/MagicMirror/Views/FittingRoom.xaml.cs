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
using System.Windows.Media.Animation;

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

        private SelectedProductsControl selectingContol;
        private ProductTryingOnControl productControl;
        public FittingRoom()
        {
            InitializeComponent();

            this.DataContext = viewModel;

            selectableClothings = dataservie.GetClothings();
            cbAllProducts.ItemsSource = selectableClothings;
            //顾客选择的作为试穿的服装列表
            lbSelProducts.ItemsSource = viewModel.Clothings;
            selectingContol = new SelectedProductsControl();
            selectingContol.productedSelectedHandler += new SelectedProductsControl.ProductSelected(selectingContol_productedSelectedHandler);
            //默认加载选择的服装列表
            mainGrid.Children.Add(selectingContol);

            spSeledProducts.Visibility = Visibility.Hidden;
        }

        private void selectingContol_productedSelectedHandler(string pruductRefId)
        {
            //进入试衣环节
            processState = ProcessState.Trying;
            this.mainGrid.Children.Clear();
            spSeledProducts.Visibility = Visibility.Visible;
            
            for (int i = 0; i < viewModel.Clothings.Count; i++)
            {
                if (viewModel.Clothings[i].RefId == pruductRefId) {
                    productControl = new ProductTryingOnControl(viewModel.Clothings[i]);
                    this.mainGrid.Children.Add(productControl);
                    lbSelProducts.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// 切换服装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clothing selectedCloth = lbSelProducts.SelectedItem as Clothing;
            productControl.ClothTringOn = selectedCloth;
        }

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
                selectingContol.AddClothing(selectableClothings.ElementAt(selIndex));
            }
            viewModel.Clothings.Add(selectableClothings.ElementAt(selIndex));
            if (processState == ProcessState.Trying)
                (this.Resources["notifyProducedAddedStoryboard"] as Storyboard).Begin(this);
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

        private void btnHideOrShow_Click(object sender, RoutedEventArgs e)
        {
            if (processState == ProcessState.Trying)
            {
                spSeledProducts.Visibility = btnHideOrShow.IsChecked == true ? Visibility.Hidden : Visibility.Visible;
            }
        }

    }
}
