using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>  
/// author: Yalmaz Abdullah
/// description: This class defines the behaviour of cat enemies in the game.
/// </summary>
public class Bhvr_Cats : MonoBehaviour
{
    #region //////Fields//////
        [SerializeField, Tooltip("Health points of this Cat")]
        private int health = 1;
        [SerializeField, Tooltip("Damage that the cat deals")]
        private int damage = 0;
        [SerializeField, Tooltip("Movement speed of the Cat")]
        private float speed = 20;
        [SerializeField, Tooltip("Deviation from shortest path to target")]
        private float deviation = 0;

        private Transform _targetTransform;
        private Rigidbody2D _rBdy;
        private Vector3 _direction;
    #endregion

    #region //////Properties//////
        public Transform targetTransform 
        {
            get => _targetTransform;
            set
            {
                _targetTransform = value;
            }
        }
    #endregion

    #region //////LifeCycle//////
        private void Awake() 
        {
            _rBdy = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => Mgr_Cats.CatsInLevel.Add(this);
        private void OnDisable() => Mgr_Cats.CatsInLevel.Remove(this);

        private void FixedUpdate()
        {
            Target();
            _rBdy.velocity = _direction*speed*Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Bullet"&&health<0){
                GameObject.Destroy(other.gameObject);
                GameObject.Destroy(transform.gameObject);
            }
            health--;
        }
    #endregion

    private void Target()
    {
        //finds the direction vector to the target position.
        Debug.DrawLine(transform.position,_targetTransform.position,Color.blue);
        _direction = (_targetTransform.position-transform.position).normalized;
    }

    //TODO: INTERACTION WITH WALL!
    //TODO: ATTACK ANIMATION
}
