using GameTranslateApp.Controller;
using GameTranslateApp.Infra.Database;
using GameTranslateApp.Repository;
using GameTranslateApp.Services;

namespace GameTranslateApp
{
    class Program
    {
        public static async Task Main()
        {
            SpeakTranslatedController speakTranslatedController = new SpeakTranslatedController(new SpeakTranslatedServices(new SpeakTranslatedRepository(new ApplicationMySqlConnection())));

            LogServices.StartSystemStatus();

            while (true)
            {
                Thread.Sleep(4000);
                await speakTranslatedController.Speak();
            }
            
        }
    }
}