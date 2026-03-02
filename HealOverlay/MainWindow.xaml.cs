using System;
using System.Windows.Threading;
using System.Windows;

namespace HealOverlay
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private UnitFrame hero;

        public MainWindow()
        {
            InitializeComponent();

            IntPtr gameHandle = NativeMethods.FindWindow(null, "Warcraft III");

            if (gameHandle != IntPtr.Zero)
            {
                hero = new UnitFrame(gameHandle, 1161, 1199, 914);

                if (NativeMethods.GetWindowRect(gameHandle, out RECT gameRect))
                {
                    double gameHeight = gameRect.Bottom - gameRect.Top;

                    this.Left = gameRect.Right - this.Width - 10;
                    this.Top = gameRect.Top + (gameHeight / 2) - (this.Height / 2);
                }

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(100);
                timer.Tick += UpdateOverlay;
                timer.Start();
            }
            else
            {
                HealthText.Text = "Game not found";
                HealthText.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private void UpdateOverlay(object sender, EventArgs e)
        {
            double hp = hero.GetHealthPercentage();
            HealthText.Text = $"{hp * 100:F0}%";

            double maxBarWidth = 200.0;
            HealthBarBg.Width = maxBarWidth * hp;

            System.Windows.Media.Color fullHealthColor = System.Windows.Media.Colors.LimeGreen;
            System.Windows.Media.Color deadColor = System.Windows.Media.Colors.Red;

            System.Windows.Media.Color currentColor = LerpColor(fullHealthColor, deadColor, hp);

            HealthBarBg.Fill = new System.Windows.Media.SolidColorBrush(currentColor);
        }

        private System.Windows.Media.Color LerpColor(System.Windows.Media.Color start, System.Windows.Media.Color end, double percent)
        {
            float factor = (float)(1.0 - percent);

            byte r = (byte)(start.R + (end.R - start.R) * factor);
            byte g = (byte)(start.G + (end.G - start.G) * factor);
            byte b = (byte)(start.B + (end.B - start.B) * factor);

            return System.Windows.Media.Color.FromRgb(r, g, b);

        }
    }
}
