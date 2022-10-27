using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>  
/// author: Yalmaz Abdullah
/// description: This class defines the behaviour of towers in the game.
/// </summary>
public class Bhvr_Tower : MonoBehaviour
{
    /// <summary>  
    /// class contains ammo types for the towers
    /// </summary>
    public enum Ammo
    {
        Tuna,       //Traditional Earth Tuna with Special Sauce
        Harvest,    //New Venusian Harvest Plate
        Mystery     //Planet X Mystery Meal
    }

    #region //////Fields//////
        [field: SerializeField, Tooltip("enum of ammo types")]
        private Ammo _towerAmmo = new Ammo();
        [SerializeField, Tooltip("list of bullet prefab")]
        private List<GameObject> bullet = new List<GameObject>();
        [SerializeField, Tooltip("Reticle asset to show where tower is currently aiming")]
        private Transform reticle;
        
        private List<Transform> _inRange = new List<Transform>();
    #endregion

     #region //////Properties//////
        public Ammo towerAmmo 
        {
            get => _towerAmmo;
            set
            {
                _towerAmmo = value;
            }
        }
    #endregion

    #region //////LifeCycle//////
        private void OnEnable() => StartCoroutine(SpawnRoutine());

        private void Update()
        {
            if (_inRange.Count>0)
            {
                Debug.DrawLine(transform.position,_inRange[0].position,Color.red);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _inRange.Add(other.transform);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _inRange.Remove(other.transform);
        }

        private IEnumerator SpawnRoutine()
        {
            while(enabled)
            {
                if(_inRange.Count>0)
                {
                    var dir = _inRange[0].position - transform.position; //a vector pointing from pointA to pointB
                    var angle = Vector3.Angle(transform.up,dir); //calc a rotation that
                    GameObject spawnedfile = Instantiate(bullet[(int)towerAmmo],transform.position,Quaternion.AngleAxis(angle,Vector3.back));
                }
                yield return new WaitForSeconds(0.5f);//TODO:MAKE THIS CHANGE BASED ON SELECTED AMMO
            }
        }

        private void OnDrawGizmos()
        {
            //Debuging command to visualzie area 
            Gizmos.DrawWireSphere(transform.position,gameObject.GetComponent<CircleCollider2D>().radius);
        }
    #endregion
}
