using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLabExceptions
{
    class Simulation
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;

        public Simulation()
        {
            do
            {
                RunScenerios();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    

        public void RunScenerios()
        {
            //currentDomain.UnhandledException -= new UnhandledExceptionEventHandler(MyHandler);

            Console.Clear();
            Console.WriteLine("1. Wyjątek nie przechwycony.");
            Console.WriteLine("2. Wyjątek -> AppDomain.");
            Console.WriteLine("3. Wyjątek przechwycony.");
            int option = Int32.Parse(Console.ReadLine());


            switch (option)
            {
                case 1:
                    NotHandleExcetpion();
                    break;

                case 2:
                    HandleExceptionByAppDomain();
                    break;

                case 3:
                    HandleException();
                    break;

                default:
                    Console.WriteLine("Nie ma takiej opcji.");
                    break;
            }

        }

        private void NotHandleExcetpion()
        {
            Thread thread = new Thread(() =>
            {
                throw new Exception("Nie przechwycony wjątęk");
            }
           );

            thread.Start();
        }

        private void HandleExceptionByAppDomain()
        {
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Thread thread = new Thread(() =>
            {
                throw new Exception("Ten wyjatek powinno przechwycić prze AppDomain.");
            }
            );
            thread.Start();
        }

        private void HandleException()
        {
            Thread thread = new Thread(() =>
                {
                    try
                    {
                        throw new Exception("Wyjątek obsłużony.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wyjątek przechwycony.");
                        Console.WriteLine(e.Message);
                    }
                }
            );

            thread.Start();
        }

        private void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception) args.ExceptionObject;
            Console.WriteLine("MyHandler złapał: " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}
