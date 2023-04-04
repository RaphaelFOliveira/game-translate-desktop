using GameTranslateApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTranslateApp.Controller
{

    internal class SpeakTranslatedController
    {
        private readonly SpeakTranslatedServices _speakTranslatedServices;
        public SpeakTranslatedController(SpeakTranslatedServices speakTranslatedServices)
        {
            _speakTranslatedServices = speakTranslatedServices;
        }

        public async Task Speak()
        {
            await _speakTranslatedServices.CheckNewTranslation();
        }
    }
}
