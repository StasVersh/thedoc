using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class EditorMenuItem
    {
        [MenuItem("GameObject/TheDoc/Doc")]
        public static void InstantiateDoc()
        {
            PrefabUtility.InstantiatePrefab(UnityEngine.Resources.Load("Prefabs/Doc"));
        }
        
        [MenuItem("GameObject/TheDoc/SpawnPoint")]
        public static void InstantiateSpawnPoint()
        {
            var point = (GameObject)PrefabUtility.InstantiatePrefab(UnityEngine.Resources.Load("Prefabs/Point (0)"));
            var parent = GameObject.Find("Translations/Spawn").transform;
            var script = parent.GetComponent<DocSpawnPointController>();
            point.name = $"Point {parent.childCount}";
            point.transform.parent = parent;
            var list = new List<GameObject>();
            for (int i = 0; i < parent.childCount; i++)
            {
                list.Add(parent.GetChild(i).gameObject);
            }

            script.SpawnPoints = list;
        }
        
        [MenuItem("GameObject/TheDoc/GoTo")]
        public static void InstantiateGoTo()
        {
            var goTo = (GameObject)PrefabUtility.InstantiatePrefab(UnityEngine.Resources.Load("Prefabs/GoTo"));
            var parent = GameObject.Find("Translations/GoTo").transform;
            goTo.name = $"GoTo {parent.childCount}";
            goTo.transform.parent = parent;
        }
        
        [MenuItem("GameObject/TheDoc/Base Objects")]
        public static void InstantiateBaseObjects()
        {
            var camera = (GameObject)PrefabUtility.InstantiatePrefab(UnityEngine.Resources.Load("Prefabs/Camera & Lightning"));
            PrefabUtility.InstantiatePrefab(UnityEngine.Resources.Load("Prefabs/Translations"));
            PrefabUtility.InstantiatePrefab(UnityEngine.Resources.Load("Prefabs/SceneContext"));
            var collider = (GameObject)PrefabUtility.InstantiatePrefab(UnityEngine.Resources.Load("Prefabs/Location Range"));
            camera.transform.Find("Cameras").Find("Player Cam").GetComponent<CinemachineConfiner2D>()
                .m_BoundingShape2D = collider.GetComponent<PolygonCollider2D>();
        }
    }
}
