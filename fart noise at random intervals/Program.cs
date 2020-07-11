using System;
using System.Media;

namespace fart_noise_at_random_intervals
{
    class Program
    {
        static void Main(string[] args)
        {
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

                do
                {
                    int randomTime = random.Next(1, 10) * 1000;

                    System.Threading.Thread.Sleep(randomTime);

                    Console.WriteLine("Playing sound!");
                    player.Play();
                } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);

                Console.WriteLine("Stopping...");
                start();
            }

            start();
        }
    }
}
