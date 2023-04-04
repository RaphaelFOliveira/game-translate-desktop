using GameTranslateApp.Model;
using GameTranslateApp.Repository;
using System.Speech.Synthesis;

namespace GameTranslateApp.Services
{
    internal class SpeakTranslatedServices
    {

        private readonly SpeakTranslatedRepository _repository;

        public SpeakTranslatedServices(SpeakTranslatedRepository repository)
        {
            _repository = repository;
        }

        public async Task CheckNewTranslation()
        {
            List<Translation> listTranslation = await _repository.GetNewTranslation(new Translation());

            if (listTranslation != null)
            {
                listTranslation.Reverse();
                await Speaker(new SpeechSynthesizer(), listTranslation);

                foreach(Translation item in listTranslation)
                {
                    await _repository.UpdateTranslationRead(item.Id);
                }
            }

            LogServices.ListeningStatus();
        }

        public async Task Speaker(SpeechSynthesizer synthesizer, List<Translation> listTranslation)
        {

            LogServices.ListeningTalking();

            foreach (Translation item in listTranslation)
            {
                Prompt text = new Prompt(item.Text);
                synthesizer.Speak(text);
            }

        }
    }
}
