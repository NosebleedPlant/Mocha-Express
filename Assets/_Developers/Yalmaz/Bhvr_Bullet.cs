using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhvr_Bullet : MonoBehaviour
{
    private void Update()
    {
        transform.position = transform.position+(transform.up*Time.deltaTime*2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Destroy(transform.gameObject);
    }
}
