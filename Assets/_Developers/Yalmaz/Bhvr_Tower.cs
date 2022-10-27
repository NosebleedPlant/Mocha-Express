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
        [SerializeField, Tooltip("list of bullet prefab")]
        private List<GameObject> ammoPrefabs = new List<GameObject>();
        [SerializeField, Tooltip("Reticle asset to show where tower is currently aiming")]
        private Transform reticle;
        
        [field: SerializeField, Tooltip("enum of ammo types")]
        private Ammo _ammoType = new Ammo();
        [field: SerializeField, Tooltip("number of shots left")]
        private int _ammoCount = 0;
        
        private List<Transform> _inRange = new List<Transform>();
        private List<float> timeBetweenShots = new List<float>();
    #endregion

    #region //////Properties//////
        public Ammo ammoType 
        {
            get => _ammoType;
            set
            {_ammoType = value;}
        }
        public int ammoCount 
        {
            get => _ammoCount;
            set
            {_ammoCount = value;}
        }
    #endregion

    #region //////LifeCycle//////
        private void Awake()
        {
            for(int i=0;i<ammoPrefabs.Count;i++)
            {
                timeBetweenShots.Add(ammoPrefabs[i].GetComponent<Bhvr_Bullet>().timeBetweenShots);
            }
        }

        private void OnEnable() => StartCoroutine(SpawnRoutine());
        private void OnDisable() => StopCoroutine(SpawnRoutine());

        private void Update()
        {
            if (_inRange.Count>0)
            {
                Debug.DrawLine(transform.position,_inRange[0].position,Color.red);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) =>_inRange.Add(other.transform);
        private void OnTriggerExit2D(Collider2D other) =>_inRange.Remove(other.transform);
    #endregion

    private IEnumerator SpawnRoutine()
    {
        while(enabled)
        {
            if(_inRange.Count>0 && ammoCount>0)
            {
                Vector3 dir = _inRange[0].position - transform.position;
                float angle = Vector3.SignedAngle(transform.up,dir,Vector3.back);
                GameObject spawnedBullet = Instantiate(
                    ammoPrefabs[(int)ammoType],transform.position,
                    Quaternion.AngleAxis(angle,Vector3.back));
                ammoCount--;
            }
            yield return new WaitForSeconds(timeBetweenShots[(int)ammoType]);
        }
    }

    #region //////EditorScript//////
        private void OnDrawGizmos()
        {
            //Debuging command to visualzie area 
            Gizmos.DrawWireSphere(transform.position,gameObject.GetComponent<CircleCollider2D>().radius);
        }
    #endregion
}
