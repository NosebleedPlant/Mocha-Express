using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mgr_Game : MonoBehaviour
{
    public int HealthCounter = 0;
    public void takeHit(int damage){HealthCounter-=damage;}
}
