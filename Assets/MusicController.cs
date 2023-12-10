using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    public SoundManager soundManager;
    Sound currMusic;
    void Awake(){
        //init dictionary
    }
    public void startMusic(string newMusicStr){
        //no ending currMusic, for starting the first music
        /*Debug.Log("starting music");
        foreach(Sound sound in soundManager.sounds){
            if(sound.name == newMusicStr){
                Debug.Log("found music");
                currMusic = sound;
                break;
            }
        }
        Debug.Log(currMusic.name);
        currMusic.audioSource.Play();*/
        soundManager.playSound(newMusicStr);
    }
    //add lowpass filter stuff later
    /*IEnumerator endMusic(string newMusicStr){
        yield return new 
    }*/

    public void changeMusic(string newMusicStr){
        //start lowpass filter on currMusic, start new music
        currMusic.audioSource.Stop();
        Sound newMusic = new Sound();
        foreach(Sound sound in soundManager.sounds){
            if(sound.name == newMusicStr){
                newMusic = sound;
                break;
            }
        }
        currMusic = newMusic;
        currMusic.audioSource.Play();
    }

    void Update()
    {
        
    }
}
