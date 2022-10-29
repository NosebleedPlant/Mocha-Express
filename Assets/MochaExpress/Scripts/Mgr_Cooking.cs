using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mgr_Cooking : MonoBehaviour
{
    [SerializeField,Tooltip("List of ingredient box Colliders to detect when Ingredient is picked up")]
    private List<Collider2D> ingredientBoxes = new List<Collider2D>();
    [SerializeField,Tooltip("List of ingredient prefabs to spawn when food picked up")]
    private List<Transform> IngredientPrefab = new List<Transform>();
    [SerializeField,Tooltip("List of meals to spawn when food is cooked")]
    private List<Collider2D> mealPrefab = new List<Collider2D>();
    [SerializeField,Tooltip("List of tower Colliders to detect when food has been assigned to tower")]
    private List<Collider2D> towers = new List<Collider2D>();
    [SerializeField,Tooltip("Cooking area collider to know when food is being used")]
    private Collider2D cookingArea;
    
    private List<Bhvr_Tower> _towerBhvrs = new List<Bhvr_Tower>();
    private List<Transform> _usedIngredients = new List<Transform>();
    private Transform _heldIngredient;
    private Collider2D _meal=null;

    private const float ZOFFSET = 0.3f;
    private List<string[]> RECIPIES = new List<string[]>()
    {
        new string[3] {"Tuna","Egg","Chilies"},
        new string[3] {"Lantern","Egg","Chilies"},
        new string[3] {"Berries","Tuna","Chilies"}
    };
    
    private void Awake()
    {
        foreach(Collider2D tower in towers){
            _towerBhvrs.Add(tower.GetComponentInParent<Bhvr_Tower>());
        }
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Handle Mouse Press Down
        if(_meal == null && Input.GetMouseButtonDown(0))
        {
            tryGrabIngredient(mousePos);
        }
        //Handle Mouse Drag
        if(Input.GetMouseButton(0))
        {
            if(_heldIngredient!=null)
            {
                Drag(mousePos,_heldIngredient);
            }
            else if(_meal !=null && _meal.OverlapPoint(mousePos))
            {
                Drag(mousePos,_meal.transform);
            }
        }
        //Handle Drag Release
        if(Input.GetMouseButtonUp(0))
        {
            if(_heldIngredient!=null)
            {
                if(cookingArea.OverlapPoint(mousePos))
                {
                    DropIngredient();
                }
                else
                {
                    GameObject.Destroy(_heldIngredient.gameObject);
                    _heldIngredient=null;
                }
            }
            else if(_meal!=null)
            {
                if(TryLoadAmmo(mousePos)==false)
                {
                    GameObject.Destroy(_meal.gameObject);
                    _meal=null;
                }
            }
        }
    }


    private void tryGrabIngredient(Vector3 mousePos)
    {
        for(int i = 0; i<ingredientBoxes.Count; i++)
        {
            if(ingredientBoxes[i].OverlapPoint(mousePos))
            {
                _heldIngredient = Instantiate(IngredientPrefab[i],transform.position, Quaternion.identity);
                AkSoundEngine.PostEvent("playItemPickup", gameObject);
                var adjustedPos = _heldIngredient.position;
                adjustedPos.z -= ZOFFSET;
                _heldIngredient.position=adjustedPos;
            }
        }
    }

    private void Drag(Vector3 mousePos, Transform dragSubject)
    {
        mousePos.z = dragSubject.position.z;
        dragSubject.position = mousePos;
    }

    private void DropIngredient()
    {
        Vector3 snapPos = cookingArea.transform.position;
        snapPos.z = _heldIngredient.position.z;
        snapPos.x = Mathf.Clamp(_heldIngredient.position.x,cookingArea.bounds.min.x,cookingArea.bounds.max.z);
        
        _heldIngredient.position = snapPos;
        AkSoundEngine.PostEvent("playItemPlace", gameObject);
        _usedIngredients.Add(_heldIngredient);
        
        if(_usedIngredients.Count==3){
            //check valid recipie
            int? recipie = ValidateRecipie();
            //if yes then spawn food
            if(recipie!=null)
            {
                _meal = SpawnMeal((int)recipie);
            }
            else{
                //JTC FOOD FAILED SOUND HERE
                _meal = SpawnMeal(mealPrefab.Count-1);
                CleanCookingArea();}
        }
        _heldIngredient=null;
    }

    private int? ValidateRecipie()
    {
        string[] current = new string[3];
        for(int i = 0; i<_usedIngredients.Count; i++)
        {
            current[i]=_usedIngredients[i].tag;
        }
        
        for(int i = 0; i<RECIPIES.Count; i++)
        {
            if(isValid(current,RECIPIES[i]))
            {
                return i;
            }
        }
        return null;
    }

    private Collider2D SpawnMeal(int recipie)
    {
        Vector3 spawnpos = cookingArea.transform.position;
        spawnpos.z = _heldIngredient.position.z;

        CleanCookingArea();
        //JTC Food Completeion sound here!
        return Instantiate<Collider2D>(mealPrefab[recipie],spawnpos,Quaternion.identity);
    }

    private void CleanCookingArea()
    {
        foreach(Transform ingredient in _usedIngredients){
            GameObject.Destroy(ingredient.gameObject);
        }
        _usedIngredients.Clear();
    }

    private bool TryLoadAmmo(Vector3 mousePos)
    {
        for(int i = 0; i<towers.Count; i++)
        {
            if(towers[i].OverlapPoint(mousePos))
            {
                Debug.Log("calling");
                //change the ammo type
                _towerBhvrs[i].UpdateAmmo(_meal.tag);
                //clean up meal
                GameObject.Destroy(_meal.gameObject);
                _meal=null;
                return true;
            }
        }
        return false;
    }

    private bool isValid(string[] current,string[] recipie)
    {
        bool result = false;
        result = Array.Exists(recipie, element => element == current[0])&&
        Array.Exists(recipie, element => element == current[1])&&
        Array.Exists(recipie, element => element == current[2]);
        return result;
    }

}
