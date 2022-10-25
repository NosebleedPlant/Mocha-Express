using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhvr_Tower : MonoBehaviour
{
    public GameObject bullet;
    public Transform reticle;
    List<Transform> inRange = new List<Transform>();

    private void Update()
    {
        if (inRange.Count>0)
        {
            // Debug.DrawLine(transform.position,inRange[0].position,Color.red);
            // reticle.position = new Vector3(inRange[0].position.x,1.1f,inRange[0].position.z);
        }
        else
        {
            // reticle.localPosition = new Vector3(0f,0f,0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inRange.Add(other.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange.Remove(other.transform);
        Debug.Log("removed");
    }

    private void OnEnable() => StartCoroutine(SpawnRoutine());
    private IEnumerator SpawnRoutine()
    {
        while(enabled)
        {
            Debug.Log("Count"+inRange.Count);
            if(inRange.Count>0)
            {
                //check to see if the transform is in there?
                var dir = inRange[0].position - transform.position; //a vector pointing from pointA to pointB
                var rot = Vector3.Angle(transform.up,dir); //calc a rotation that
                Debug.Log(rot);
                GameObject spawnedfile = Instantiate(bullet,transform.position,Quaternion.AngleAxis(rot,Vector3.back));
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
