using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class RemoveSceneIDMap :MonoBehaviour
{
    [MenuItem("Tools/SceneIDMap Fixer")]
    public static void KillSceneIdMap()
    {
        var sceneObj = GameObject.Find("SceneIDMap");
        if(sceneObj != null)
        {
            DestroyImmediate(sceneObj);
            Debug.Log("Cleared a SceneIDMap instance");
        }
    }
}
