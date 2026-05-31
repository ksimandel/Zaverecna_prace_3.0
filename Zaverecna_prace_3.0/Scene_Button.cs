using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Zaverecna_prace_3._0
{
    public class SceneButton
    {
        public string Content;
        public double X { get; set; }
        public double Y { get; set; }

        public double Width { get; set; } = 120;
        public double Height { get; set; } = 40;

        public Brush Background { get; set; }

        public string TargetSceneId { get; set; }

        public string HoverText { get; set; }

        public string RequiredItem { get; set; } = "";

        public string ItemToGive { get; set; } = ""; // Pokud je ItemToGive prázdný -> nejedná se o klíč

        public string ButtonImage { get; set; } = "";

        
    }
}
