namespace HUDextension
{
    public class UnitFrame
    {
        private int startHpBar, heightHpBar;
        private double hpBarLeng;
        private IntPtr window;


        public UnitFrame(IntPtr window, int startHpBar, int endHpBar, int heightHpBar )
        {
            this.window = window;
            this.startHpBar = startHpBar;
            this.heightHpBar = heightHpBar;
            this.hpBarLeng = endHpBar - startHpBar;
        }



        public double GetHealthPercentage()
        {
            double currentHealthPixels = this.hpBarLeng;
            IntPtr dc = NativeMethods.GetDC(this.window);

            if (dc == IntPtr.Zero) return 0.0;

            try {
                for (int i = 0; i < this.hpBarLeng; i++)
                {
                    int col = NativeMethods.GetPixel(dc, this.startHpBar + i, this.heightHpBar);
                    var (r, g, b) = this.GetPixelColor(col);
                    if (r == 0 && g == 0) currentHealthPixels--;
                }


                return currentHealthPixels / this.hpBarLeng;
            }
            finally
            {
                NativeMethods.ReleaseDC(this.window, dc);
            }
        }



        private (int, int, int) GetPixelColor(int col)
        {
            if (col == -1)
            {
                Console.WriteLine("Nie udalo sie zgarnac koloru pixela");
                return (-1, -1, -1);
            }
            else
            {
                int r = col & 0xFF;
                int g = (col >> 8) & 0xFF;
                int b = (col >> 16) & 0xFF;

                return (r, g, b);
            }
        }


    }
}
