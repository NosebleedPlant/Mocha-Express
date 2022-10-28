using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private string[] ingredientOnPlate;
    private bool isDragged;
    GameObject touchedIng;
    [SerializeField] private GameObject plate;
    [SerializeField] private LayerMask ingredientLayer;

    private BoxCollider2D col;

    private void Start()
    {
        col = plate.GetComponent<BoxCollider2D>();
        ingredientOnPlate= new string[3];
    }

    private void Update()
    {
        if (Input.touchCount>0)
        {
            DragAndDropIngredient();
        }

        //CheckIfIngredientOnPlate();

    }
    
    private void DragAndDropIngredient()
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D HitInfo = Physics2D.Raycast(touchPosition2D, Camera.main.transform.forward,ingredientLayer,1);
    
            if (HitInfo.collider != null /*&& (HitInfo!=plate)*/)
            {
                touchedIng = HitInfo.transform.gameObject;
                Debug.Log(touchedIng.name); ///works
                touchedIng.transform.position = touchPosition2D;
            }
        }
    
    bool CheckIfIngredientOnPlate()
            {
                bool isTouchingPlate = Physics2D.BoxCast(col.bounds.center,col.bounds.size,0f,Vector2.zero,Mathf.Infinity, ingredientLayer,2);
                return isTouchingPlate;
            }

            void RecordIngredientOnPlate(string Ing)
            {
                foreach (string ingredient in ingredientOnPlate)
                {
                    if (ingredient == null)
                    {
                        ingredientOnPlate[System.Array.IndexOf(ingredientOnPlate,ingredient)] = Ing;
                        break;
                    }
                }
                
                

            }
            
            /*void OnCollisionEnter2D(Collision2D other)
            {
                if (other.gameObject==plate)
                {
                    Debug.Log(gameObject.name + "on plate");
                }
            }*/
    
}
