using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Edtr_Game : MonoBehaviour
{
    #if UNITY_EDITOR
        private void OnEnable() {
            Mgr_Cats.gameManager = gameObject.GetComponent<Mgr_Game>();
            Mgr_Cats.workArea = gameObject.GetComponent<Collider2D>();
        }
        private void OnDisable() {
            Mgr_Cats.gameManager = null;
            Mgr_Cats.workArea = null;
        }
    #endif
}
