using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mgr_Input : MonoBehaviour
{
    public List<Collider2D> boxes = new List<Collider2D>();
    public Collider2D workArea;
    public Transform item;
    private Transform activeIngredietn;
    private GameObject meal=null;
    private Collider2D mealCollider;
    public GameObject mealPrefab;
    private List<Transform> actve = new List<Transform>();

    void Update()
    {
        Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(meal ==null && Input.GetMouseButtonDown(0))
        {
            foreach (Collider2D box in boxes)
            {
                if(box.OverlapPoint(mousePos))
                {
                    activeIngredietn = Instantiate(item,transform.position, Quaternion.identity);
                    var adjust = activeIngredietn.position;
                    adjust.z -= 0.3f;
                    activeIngredietn.position=adjust;
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(activeIngredietn!=null)
            {
                mousePos.z = activeIngredietn.position.z;
                activeIngredietn.position = mousePos;
            }
            else if(meal !=null && mealCollider.OverlapPoint(mousePos))
            {
                mousePos.z = meal.transform.position.z;
                meal.transform.position = mousePos;
            }
        }
        if(Input.GetMouseButtonUp(0)&&activeIngredietn!=null)
        {
            if(workArea.OverlapPoint(mousePos))
            {
                Vector3 snapPos = workArea.transform.position;
                snapPos.z = activeIngredietn.position.z;
                snapPos.x = activeIngredietn.position.x;//clamp if u have time
                activeIngredietn.position = snapPos;
                actve.Add(activeIngredietn);
                //check if valid recipie
                if(actve.Count==3){
                    Vector3 spawnpos = workArea.transform.position;
                    spawnpos.z = activeIngredietn.position.z;
                    meal = Instantiate(mealPrefab,spawnpos,Quaternion.identity);
                    mealCollider = meal.GetComponent<Collider2D>();
                    foreach(Transform ing in actve){
                        GameObject.Destroy(ing.gameObject);
                    }
                }
                activeIngredietn=null;
                //JTC spawn food
            }
            else
            {
                GameObject.Destroy(activeIngredietn.gameObject);
                activeIngredietn=null;
            }
        }
    }
}
