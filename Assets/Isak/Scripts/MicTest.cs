using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MicTest : MonoBehaviour
{
    public AudioSource audioSource;
    float volume = 0;
    int sampleWindow = 64;
    bool randomBool;
    bool makingSound;
    int score = 0;
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
        string mic = Microphone.devices[0];
        audioSource.clip = Microphone.Start(mic, true, 1, 44100);
        audioSource.Play();
    }
    void Update(){
        volume = CheckForSound(audioSource.timeSamples, audioSource.clip);
        //Debug.Log(volume);
        if(volume > 0.0006f){
            randomBool = true;
            OnOff(randomBool);
        } else {
            randomBool = false;
            OnOff(randomBool);
        }
        if(makingSound)
            score++;
        //Debug.Log(score);
    }
    public void OnOff(bool keeper){
        makingSound = keeper;
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