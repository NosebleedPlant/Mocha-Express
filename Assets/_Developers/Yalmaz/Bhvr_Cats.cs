using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhvr_Cats : MonoBehaviour
{
    #region Fields

    [SerializeField, Tooltip("Health points of this cat")]
    private int health = 0;
    [SerializeField, Tooltip("Damage that the cat deals")]
    private int damage = 0;
    [SerializeField, Tooltip("Movement speed of the Cat")]
    private float speed = 20;
    [SerializeField, Tooltip("Deviation from shortest path to target")]
    private float deviation = 0;
    
    private Rigidbody2D _rBdy;
    private Transform _targetTransform;
    private Vector3 _direction;

    #endregion

    #region Properties

    public Transform targetTransform 
    {
        get => _targetTransform;
        set
        {
            _targetTransform = value;
        }
    }

    #endregion


    #region LifeCycle

    private void Awake() 
    {
        _rBdy = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Target();
        _rBdy.velocity = _direction*speed*Time.deltaTime;
    }

    #endregion

    private void Target()
    {
        Debug.DrawLine(transform.position,_targetTransform.position,Color.blue);
        _direction = (_targetTransform.position-transform.position).normalized;
    }
}
