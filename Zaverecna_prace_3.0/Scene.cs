using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Zaverecna_prace_3._0
{
    public class Scene
    {
        public string Id;
        public ImageSource BackgroundImage { get; set; }
        public ObservableCollection<SceneButton> Buttons { get; set; } = new();
        public List<DialogueLine> Dialogue { get; set; }
        = new();
        public string NextSceneAfterDialogue { get; set; }

        public bool IsDialogueRead { get; set; } = false;
    }

}
