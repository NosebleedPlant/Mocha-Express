using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mgr_Game : MonoBehaviour
{
    public int HealthCounter = 0;
    public void takeHit(int damage) { HealthCounter -= damage; }


    void Start()
    
        //plays Gameplay track event
    {
        AkSoundEngine.PostEvent("gameplayMusic", gameObject);


    }

    void Update()
    {
        //Links HealthCounter to Wwise PlayerHealth RTPC to switch between tracks
        if (HealthCounter > 2) {
            AkSoundEngine.SetRTPCValue("PlayerHealth", 21f);
            print("healthy!");
        } else if (HealthCounter < 3) {
            AkSoundEngine.SetRTPCValue("PlayerHealth", 19f);
            print("low health!");
            }
    }
}