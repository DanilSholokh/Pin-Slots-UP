using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundLogic : MonoBehaviour
{



    [SerializeField] private AudioClip mainClip;
     
    [SerializeField] List<SoundController> soundPanels;

    [SerializeField] Image muteImg;
    [SerializeField] Sprite offMute;
    [SerializeField] Sprite onMute;

    private AudioSource mainSound;

    public AudioClip MainClip { get => mainClip; set => mainClip = value; }

    private void Awake()
    {
        innitSoundPanels();
    }

    private void Start()
    {
        mainSound = GetComponent<AudioSource>();
        ToggleMute();
    }

    private void ChangeAudioClip(AudioClip audio)
    {
        mainSound.clip = audio;
        mainSound.Play();
    }

    public void setMainSound()
    {
        ChangeAudioClip(MainClip);
    }

    private void escapeSound(string txt)
    {
        txt = "Off Mute";
        AudioClip audioClip = mainSound.clip;

        setFakeClip(audioClip);


    }

    public void setFakeClip(AudioClip audio)
    {
        ChangeAudioClip(audio);
    }

    private void addSound(string txt)
    {
        txt = "On Mute";
        innitSoundPanels();


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
        mainSound.mute = !mainSound.mute;
        
        if(!mainSound.mute)
        {
            muteImg.sprite = offMute;
        }
        else
        {
            muteImg.sprite = onMute;
        }
        
    }




}
