using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPanelController : MonoBehaviour
{

    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite background;

    [SerializeField] private GameObject buttoneBuy;

    [SerializeField] private MusicLogic audioSource;
    [SerializeField] private AudioClip sound;
    [SerializeField] private EconomicaLogic economica;

    private bool isBuy = false;

    private int idSound;
    [SerializeField] private int priceSound = 0;

    public int IdSound { get => idSound; set => idSound = value; }

    public void buySound()
    {
        if (economica.DecrementCurrency(priceSound))
        {
            PlayerPrefs.SetInt("SoundPanel" + IdSound, 1);
            initSound();
        }
        
    }

    public void initSound()
    {
        Destroy(buttoneBuy);
        isBuy = true;
    }

    public void setSound()
    {
        if (!isBuy) 
        {
            audioSource.setFakeClip(sound);
        }
        else
        {
            audioSource.MainClip = sound;
            audioSource.setMainClip();
        }

    }




}
