using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour{
    public Sound[] sounds;
    //import sounds
    void Awake(){
        foreach (Sound sound in sounds){
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
            sound.audioSource.loop = sound.loop;
        }
    }
    public Sound playSound(string name){
        Sound currSound = new Sound();
        foreach (Sound sound in sounds){
            Debug.Log("playing sound");
            if (sound.name == name){
                sound.audioSource.Play();
                currSound = sound;
            }
        }
        return currSound;
    }
}
