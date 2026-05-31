using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaverecna_prace_3._0
{
    public class Game
    {
        public Dictionary<string, Scene> Scenes { get; set; }
            = new();

        public string StartingSceneId { get; set; }

        public Scene CurrentScene { get; set; }

        public void Start()
        {
            CurrentScene = Scenes[StartingSceneId];
        }

        public void ChangeScene(string sceneId)
        {
            if (Scenes.ContainsKey(sceneId))
            {
                CurrentScene = Scenes[sceneId];
            }
        }

        public List<string> Inventory { get; set; } = new();

        public bool HasItem(string itemName)
        {
            
            if (string.IsNullOrEmpty(itemName)) return true;
            return Inventory.Contains(itemName);
        }
    }
}
