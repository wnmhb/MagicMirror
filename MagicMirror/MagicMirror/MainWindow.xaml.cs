using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MagicMirror
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += (s,e)=>{
                base.OnMouseLeftButtonDown(e);
                this.DragMove();
            };

            RunSlideShowThread();
        }

        private Uri currentUri;

        /// <summary>
        /// 图片轮播线程
        /// </summary>
        private void RunSlideShowThread()
        {
            DispatcherTimer Timer_SlideShow = new DispatcherTimer();
            Timer_SlideShow.Tick += new EventHandler((s, e) =>
            {
                try
                {
                    if (SystemIdleHelper.GetIdleTime() >= Config.SlideShowIdleSeconds)
                    {
                        if (!currentUri.OriginalString.Equals(Config.SlideShowPage))
                        {
                            NavigationFrame.Navigate(new Uri("/" + Config.SlideShowPage, UriKind.Relative));
                        }
                    }
                    else {
                        if (!currentUri.OriginalString.Equals(Config.FittingRoomPage))
                        {
                            NavigationFrame.Navigate(new Uri("/" + Config.FittingRoomPage, UriKind.Relative));
                        }
                    }
                }
                catch { }
            });
            Timer_SlideShow.Interval = new TimeSpan(0, 0, 1);
            Timer_SlideShow.Start();
        }

        private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            currentUri = e.Uri;
        }

    }
}
