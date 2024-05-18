using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtils
{
    public static List<GameObject> GetGameObjectByLayerName(string layerName)
    {
        List<GameObject> allActiveObjInScene = GetActiveGameObjectInScene();
        List<GameObject> filterdObjWithLayerName = new List<GameObject>();
        foreach (GameObject obj in allActiveObjInScene)
        {
            if(LayerMask.LayerToName(obj.layer) == layerName)
            {
                filterdObjWithLayerName.Add(obj);
            }
        }

        return filterdObjWithLayerName;
    }

    public static List<GameObject> GetActiveGameObjectInScene()
    {
        GameObject[] allObjects = Object.FindObjectsOfType<GameObject>();
        List<GameObject> activeObj = new List<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.activeInHierarchy)
            {
                activeObj.Add(obj);
            }
        }
        return activeObj;
    }
}
