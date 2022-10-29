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
        [SerializeField, Tooltip("Wait time between each attack")]
        private float timeBetweenAttacks = 0;
        [SerializeField, Tooltip("Target that Cat is moving towards")]
        private Transform _targetTransform;

        [SerializeField, Tooltip("")]
        private Collider2D _workArea;
        [SerializeField, Tooltip("")]
        private Mgr_Game _gameManager;

        private Rigidbody2D _rBdy;
        private Vector3 _direction;
        private bool _isAttacking;
        private float _attackTimer;
    #endregion

    #region //////Properties//////
        public Transform targetTransform
        {
            get => _targetTransform;
            set
            {_targetTransform = value;}
        }

        public Mgr_Game gameManager
        {
            get => _gameManager;
            set
            {_gameManager = value;}
        }

        public Collider2D workArea
        {
            get => _workArea;
            set
            {_workArea = value;}
        }
    #endregion

    #region //////LifeCycle//////
        private void Awake()
        {
            _rBdy = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Target();
            _rBdy.velocity = _direction*speed*Time.deltaTime;
        }

        private void Update()
        {
            if(health<=0)
            {
            AkSoundEngine.PostEvent("playPurr", gameObject);
                GameObject.Destroy(transform.gameObject);
            }
            else if(_isAttacking)
            {
                _attackTimer-=Time.deltaTime;
                Debug.Log(_attackTimer);
                if(_attackTimer <0)
                {
                    gameManager.takeHit(damage);
                    _attackTimer= timeBetweenAttacks;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Bullet" && health>0){
                health-= other.GetComponent<Bhvr_Bullet>().damage;
                //AkSoundEngine.PostEvent("playPurr", gameObject);
                GameObject.Destroy(other.gameObject);
                //JTC Cat gets hit

            }
            else if(other.tag == "WorkArea")
            {
            //JTC Cat attacks
            AkSoundEngine.PostEvent("playScreech", gameObject);
            speed = 0;
                _isAttacking=true;
                _attackTimer= timeBetweenAttacks;
            }
        }
    #endregion

    private void Target()
    {
        //finds the direction vector to the target position.
        Debug.DrawLine(transform.position,_targetTransform.position,Color.blue);
        _direction = (_targetTransform.position-transform.position).normalized;
    }

    //TODO: ATTACK ANIMATION
}
