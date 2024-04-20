using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicLogic : MonoBehaviour
{


    private AudioSource mainSourse;

    [SerializeField] private AudioClip mainClip;
     
    [SerializeField] List<SoundPanelController> soundPanels;

    [SerializeField] Image muteImage;
    [SerializeField] Sprite offMute;
    [SerializeField] Sprite onMute;


    public AudioClip MainClip { get => mainClip; set => mainClip = value; }

    private void Awake()
    {
        innitSoundPanels();
    }

    private void Start()
    {
        mainSourse = GetComponent<AudioSource>();
        ToggleMute();
    }

    private void ChangeAudioClip(AudioClip audio)
    {
        mainSourse.clip = audio;
        mainSourse.Play();
    }

    public void setMainClip()
    {
        ChangeAudioClip(MainClip);
    }

    public void setFakeClip(AudioClip audio)
    {
        ChangeAudioClip(audio);
    }

    private void innitSoundPanels()
    {
        for (int i = 0; i < soundPanels.Count; i++)
        {
            soundPanels[i].IdSound = i;

            if (PlayerPrefs.GetInt("SoundPanel" + i, 0) == 1)
            {
                soundPanels[i].initSound();
            }
        }
    }

    public void ToggleMute()
    {
        mainSourse.mute = !mainSourse.mute;
        
        if(!mainSourse.mute)
        {
            muteImage.sprite = offMute;
        }
        else
        {
            muteImage.sprite = onMute;
        }
        
    }




}
