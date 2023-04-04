using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTranslateApp.Model
{
    internal class Translation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Read { get; set; }

        public Translation()
        {
        }
        public Translation(int id, string text, bool read)
        {
            Id = id;
            Text = text;
            Read = read;
        }
    }
}
