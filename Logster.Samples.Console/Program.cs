using log4net;
using log4net.Config;

namespace Logster.Samples.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // load the log4net configuration in app.config
            XmlConfigurator.Configure();

            ILog log = LogManager.GetLogger(typeof (Program));

            log.Info("Starting up ...");

            for (var i = 0; i < 10; i++)
            {
                log.Info(i + "... ");
            }

            log.Info("Done.");

            // call shutdown to write any pending events in the async queue
            LogManager.Shutdown();
        }
    }
}