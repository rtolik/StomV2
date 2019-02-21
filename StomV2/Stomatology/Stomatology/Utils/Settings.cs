using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Utils
{
    public class Settings
    {
        public int Theme { get; set; }

        public int Style { get; set; }

        public int FirmId { get; set; }

        public Settings()
        {
        }

        public Settings(int theme, int style, int firmId)
        {
            Theme = theme;
            Style = style;
            FirmId = firmId;
        }
    }
}
