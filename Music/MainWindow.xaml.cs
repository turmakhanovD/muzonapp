using System;
using System.Windows;
using System.Windows.Media;
using System.Threading;
using System.IO;

namespace Music
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread thread = new Thread(PlayMusic);
        private static string textToSave;
        public MainWindow()
        {
            InitializeComponent();
            thread.IsBackground = true;
            thread.Start();
            textToSave = ideaTextBox.Text;
        }

        private static void PlayMusic()
        {
            var player = new MediaPlayer();
            player.Open(new Uri(@"C:\Users\Адиль\Downloads\music-master\music-master\Music\bin\Debug\muzon4ek.mp3", UriKind.RelativeOrAbsolute));
            player.Play();
        }

        private static void SaveIdea()
        {
            File.WriteAllText("idea.txt", textToSave);                     
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Thread newThread = new Thread(SaveIdea);
            newThread.Start();
        }
    }
}
