using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Edtr_Cats : MonoBehaviour
{
    private void OnEnable() => Mgr_Cats.CatsInLevel.Add(gameObject.GetComponent<Bhvr_Cats>());
    private void OnDisable() => Mgr_Cats.CatsInLevel.Remove(gameObject.GetComponent<Bhvr_Cats>());
}
