using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Mgr_Cats : MonoBehaviour
{
    public static List<Bhvr_Cats> CatsInLevel = new List<Bhvr_Cats>();

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        foreach(Bhvr_Cats cat in CatsInLevel)
        {
            Vector3 managerPos = transform.position;
            Vector3 catPos = cat.transform.position;
            float halfHeight = (managerPos.y-catPos.y)*0.5f;
            Vector3 offset = Vector3.up*halfHeight;
            
            Handles.DrawBezier(
                managerPos,
                catPos,
                managerPos-offset,
                catPos+offset,
                Color.yellow,
                EditorGUIUtility.whiteTexture,
                1f
            );
        }
    }
    #endif
}