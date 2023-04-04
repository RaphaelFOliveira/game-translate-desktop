using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTranslateApp.Services
{
    internal class LogServices
    {

        public static void StartSystemStatus()
        {
            Console.WriteLine("Iniciando Sistema...\n");
        }
        public static void ListeningStatus()
        {
            Console.WriteLine("Ouvindo...\n");
        }
        public static void ListeningTalking()
        {
            Console.WriteLine("Falando...\n");
        }
    }
}
