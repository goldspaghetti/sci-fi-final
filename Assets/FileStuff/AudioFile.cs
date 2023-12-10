using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFile : File
{
    public string audioName;
    SoundManager soundManager;
    public string audioInfo;
    public bool containsStr = false;
    public AudioFile(string name, string audioName, SoundManager soundManager){
        this.name = name;
        this.audioName = audioName;
        this.type = "AudioFile";
        if (soundManager == null){
            Debug.Log("AAA");
        }
        this.soundManager = soundManager;
        //soundManager = GameObject.FindObjectOfType<SoundManager>();
    }
    public AudioFile(string name, string audioName, SoundManager soundManager, string audioInfo){
        this.name = name;
        this.audioName = audioName;
        this.type = "AudioFile";
        if (soundManager == null){
            Debug.Log("AAA");
        }
        this.soundManager = soundManager;

        containsStr = true;
        this.audioInfo = audioInfo;
        //soundManager = GameObject.FindObjectOfType<SoundManager>();
    }
    public void playAudio(){
        Debug.Log("playing sound");
        if (soundManager == null){
            Debug.Log("null!");
        }
        soundManager.playSound(audioName);
        
    }
    //audio file stuff
}
