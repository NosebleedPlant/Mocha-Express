using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mgr_Game : MonoBehaviour
{
    public int MaxHealth = 100;
    public int HealthCounter;
    public void takeHit(int damage) { HealthCounter -= damage; }

    void Awake()

    {
        HealthCounter = MaxHealth;
        //checks if lowHealth sound is playing to stop and play again
        AkSoundEngine.PostEvent("mapLoaded", gameObject);
        //plays Gameplay track event
        if (HealthCounter > 0)
        {
            AkSoundEngine.PostEvent("gameplayMusic", gameObject);
        }
        //tells Wwise to stop gameplayMusic
        else
        {
            AkSoundEngine.PostEvent("gameplayMusicStop", gameObject);
        }

    }

    void Update()
    {
        //Links HealthCounter to Wwise PlayerHealth RTPC to switch between tracks
        var vr = Mathf.Floor(((float)HealthCounter/MaxHealth)*100);
        Debug.Log(MaxHealth);
        Debug.Log(HealthCounter);
        Debug.Log(vr);
        AkSoundEngine.SetRTPCValue("PlayerHealth", vr);


        //tells Wwise if player is Alive or Dead
        if (HealthCounter > 0)
        {
            AkSoundEngine.SetState("PlayerLife", "Alive");
        }
        else
        {
            AkSoundEngine.SetState("PlayerLife", "Unalive");
        }
    }
}