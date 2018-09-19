using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Prime_Manager
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Task.Run(StartScreenCapture);

            Storage.Initilize();

            //Parse.getPrimeFromDE();

            Application.Run(new Main());
        }

        async static Task StartScreenCapture()
        {
            Storage.Settings = new Storage.settings()
            {
                StopTimer = false
            };

            // Create an AutoResetEvent to signal the timeout threshold in the
            // timer callback has been reached.
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            System.Threading.Timer stateTimer = new System.Threading.Timer(StatusChecker.CheckStatus, autoEvent, 0, 5000);

            // When autoEvent signals the second time, dispose of the timer.
            autoEvent.WaitOne();
            stateTimer.Dispose();
        }

        class StatusChecker
        {

            // This method is called by the timer delegate.
            public static void CheckStatus(Object stateInfo)
            {
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

                Debug.WriteLine(Parse.ReadImage());

                if (Storage.Settings.StopTimer)
                {
                    autoEvent.Set();
                }
            }
        }
    }
}
