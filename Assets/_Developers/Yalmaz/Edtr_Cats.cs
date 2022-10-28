using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>  
/// author: Yalmaz Abdullah
/// description: Very simple class that adds the cats to manager even in the editor for visualizations
/// mostly meant to aid designers.
/// </summary>
[ExecuteAlways]
public class Edtr_Cats : MonoBehaviour
{
    private void OnEnable() => Mgr_Cats.addCat(gameObject.GetComponent<Bhvr_Cats>());
    private void OnDisable() => Mgr_Cats.CatsInLevel.Remove(gameObject.GetComponent<Bhvr_Cats>());
}
