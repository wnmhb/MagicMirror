using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MagicMirror
{
    class Config
    {

        private static int slideShowIdleSeconds;
        /// <summary>
        /// 开始显示图片轮播的系统空闲间隔
        /// </summary>
        public static int SlideShowIdleSeconds {
            get {
                if (slideShowIdleSeconds == 0) {
                    bool parseResult = int.TryParse(GetAppConfig("SlideShowIdleSeconds"), out slideShowIdleSeconds);
                    if (!parseResult || slideShowIdleSeconds<=0)
                        slideShowIdleSeconds = 10;
                }
                return slideShowIdleSeconds;
            } 
        }

        private static string switchSound;
        /// <summary>
        /// 开关声音文件
        /// </summary>
        public static string SwitchSound
        {
            get {
                if (string.IsNullOrEmpty(switchSound)) {
                    switchSound = GetAppConfig("SwitchSound");
                }
                return switchSound;
            }
        }

        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }

        public static string FittingRoomPage = "Views/FittingRoom.xaml";

        public static string SlideShowPage = "Views/ProductsSlideShow.xaml";
    }
}
