using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhvr_Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [field: SerializeField, Tooltip("Time between each shot")]
    private float _timeBetweenShots = 1.5f;
    [field: SerializeField, Tooltip("Damage dealt by each shot")]
    private int _damage = 1;

    public float timeBetweenShots 
    {
        get => _timeBetweenShots;
        set
        {_timeBetweenShots = value;}
    }

    public int damage 
    {
        get => _damage;
        set
        {_damage = value;}
    }

    protected class Bounds
    {
        public Vector2 min = new Vector2(-7f,-7f);
        public Vector2 max = new Vector2(7f,7f);
    }
    Bounds _bounds = new Bounds();    
    
    public virtual void Update()
    {
        transform.position = transform.position+(transform.up*Time.deltaTime*speed);
        if(
            transform.position.x<_bounds.min.x ||
            transform.position.y<_bounds.min.y ||
            transform.position.x>_bounds.max.x ||
            transform.position.y>_bounds.max.y 
        )
        {
            GameObject.Destroy(transform.gameObject);
        }
    }
}
