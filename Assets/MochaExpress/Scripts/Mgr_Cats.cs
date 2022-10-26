using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>  
/// author: Yalmaz Abdullah
/// description: This class manages all the cats in scene by assigning them a target to move towards.
/// it also visualizes that connection so designers can more easily keep track of the cats
/// </summary>
public class Mgr_Cats : MonoBehaviour
{
    #region //////Fields//////
        // description: global list of cats in the level, the list is updated each time a cat is enabled or disabled
        public static List<Bhvr_Cats> CatsInLevel = new List<Bhvr_Cats>();
        
        [SerializeField, Tooltip("target that the cats are aiming towards")]
        private Transform target;
    #endregion
    
    #region //////LifeCycle//////
        void Start()
        {
            foreach(Bhvr_Cats cat in CatsInLevel)
            {
                cat.targetTransform = target;
            }
        }
    #endregion

    #region //////EditorScript//////
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
    #endregion
}