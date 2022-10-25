using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhvr_Bullet : MonoBehaviour
{
    private class Bounds
    {
        Vector2 min = new Vector2(7f,7f);
        Vector2 max = new Vector2(-7f,-7f);
    }
    Bounds _bounds;    
    
    private void Update()
    {
        transform.position = transform.position+(transform.up*Time.deltaTime*2);
    }
}
