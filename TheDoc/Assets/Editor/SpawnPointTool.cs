using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Editor
{
    [EditorTool("Spawn Point")]
    public class SpawnPointTool : EditorTool
    {
        [SerializeField] private Texture2D _spawnPointIcon;
        
        public override GUIContent toolbarIcon
        {
            get
            {
                return new GUIContent()
                {
                    image = _spawnPointIcon,
                    text = "SpawnPoint",
                    tooltip = "Instrument for creating spawn points"
                };
            }
        }

        public override void OnToolGUI(EditorWindow window)
        {
            Event e = Event.current;
            if (e.button == 0 && e.isMouse)
            {
                Debug.Log("Left Click");
            }
        }
    }
}