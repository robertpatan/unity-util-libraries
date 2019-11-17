using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private static AudioManager instance;
    private string lastClipName;


    void Awake()
    {

        //Singleton pattern, prevents duplicating the audio manager across scenes changes
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
         
        //persists object when changing scenes
//        DontDestroyOnLoad(gameObject);
        
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name, bool stopAll = false)
    {

        if (stopAll)
        {
            StopAllSounds();
        }
        
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound with name: " + name + " was not found");
            return;
        }
        
        if (lastClipName != name) {
            s.source.Play();
        }
    }
    
    public void Stop(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound with name: " + name + " was not found");
            return;
        }
        
        
        s.source.Stop();
    }

    public void PlayWithoutOverlap(string clipName)
    {
        if (lastClipName != clipName) {
            Play(clipName);    
        }
        
        lastClipName = clipName;
//        StartCoroutine("SetOverlapToFalse", 1f);
    }
    
    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();    
        }
        
    }

//    IEnumerator SetOverlapToFalse(float time)
//    {
//        yield return new WaitForSeconds(time);  
//        
//        avoidOverlap = false;
//    }
}