using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private string SceneName = "Level_1";

    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void StartGame()
    {
        Debug.Log("play!");
        //SceneManager.LoadScene(SceneName);
    }

    public void ChangeMusicState()
    {
        if (image.sprite == musicOffSprite)
        {
            image.sprite = musicOnSprite;
        }
        else
        {
            image.sprite = musicOffSprite;
        }
    }
    
    public void ChangeSFXState()
    {
        if (image.sprite == soundOffSprite)
        {
            image.sprite = soundOnSprite;
        }
        else
        {
            image.sprite = soundOffSprite;
        }
    }
}
