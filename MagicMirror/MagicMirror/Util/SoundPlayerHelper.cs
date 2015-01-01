using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;

namespace MagicMirror
{
    class SoundPlayerHelper
    {
        public static void PlaySound(string soundFile)
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

    }
}
