using System;
using System.Media;
using System.Threading.Tasks;

namespace fart_noise_at_random_intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int minTime = 1;
            int maxTime = 10;
            Console.WriteLine("Do you want to set time interval range? Press space to set it or press any other key to use default");
            if(Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine("Specify the minimum time of the intervals (seconds): ");
                minTime = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Specify the maximum time of the intervals (seconds): ");
                maxTime = Convert.ToInt32(Console.ReadLine());
            }

            Random random = new Random();

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"fart.wav";
            
            void start()
            {
                Console.WriteLine("Press space to start the random interval fart noises!");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { };
                loop();
            }

            void loop()
            {
                Console.WriteLine("Starting...");

                bool cantCont = true;

                Task.Run(() =>
                {
                    do
                    {
                        
                        int randomTime = random.Next(minTime, maxTime) * 1000;

                        System.Threading.Thread.Sleep(randomTime);

                        Console.WriteLine("Playing sound!");
                        player.Play();
                    } while (cantCont);
                });

                while(Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
                cantCont = false;

                Console.WriteLine("Stopping...");
                start();
            }

            start();
        }
    }
}
