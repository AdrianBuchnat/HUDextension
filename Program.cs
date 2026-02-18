using HUDextension;

class Program
{


    static void Main()
    {
        IntPtr w3window = NativeMethods.FindWindow(null, "Warcraft III");

        if (w3window != IntPtr.Zero)
        {
            if (NativeMethods.GetWindowRect(w3window, out RECT rect))
            {
                int width = rect.Right - rect.Left;
                int height = rect.Bottom - rect.Top;
                Console.WriteLine($"{width}x{height}");


                double hp;
                UnitFrame unitFrame = new UnitFrame(w3window, 1161, 1199, 914);

                int i = 0;
                while (true)
                {
                    Thread.Sleep(500);

                    hp = unitFrame.GetHealthPercentage();
                    Console.WriteLine($"hp: {hp*100:F2}%");

                    if (i == 50) break;
                    i++;
                }


            }
        }
        else
        {
            Console.WriteLine("Nic nie znaleziono");
        }


    }






}

