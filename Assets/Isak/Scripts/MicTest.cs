using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MicTest : MonoBehaviour
{
    AudioSource audioSource;
    float volume = 0;
    int sampleWindow = 64;
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
        audioSource = GetComponent<AudioSource>();
        string mic = Microphone.devices[0];
        audioSource.clip = Microphone.Start(mic, true, 1, 44100);
        audioSource.Play();
    }
    void Update(){
        volume = CheckForSound(audioSource.timeSamples, audioSource.clip);
        //Debug.Log(volume);
        if(volume > 0.0006f)
            Debug.Log("Sound Heard");
    }
    float CheckForSound(int clipPosition, AudioClip clip){
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0)
            return 0;
        

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;

        for(int i = 0; i < sampleWindow; i++){
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }
}