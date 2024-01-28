using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] canvases;
    public GameObject healthbarCanvas, scoreBoardCanvas;
    public ProjectileScript pScript;
    JokeLibrary joke;

    private float timer;
    List<string> displayedJoke;
    int health;

    //private GetJokeScript jokes;
    //string[] text = new string[2];

    [SerializeField] private bool dead = false;

    private void Start()
    {   
        joke = GetComponent<JokeLibrary>();
        //jokes = new GetJokeScript();
        StartCoroutine(TeleprompterJokes());
        health = healthbarCanvas.transform.childCount;
    }

    private void Update ()
    {
        if(!dead)
        {
            timer += Time.deltaTime;
            TimeConverter();
        }
        else
        {
            TimeConverter();
        }
    }

    private void FinalScore(string timeSurvived)
    {
        canvases[2].text = "Player has survived for " + timeSurvived;
    }

    private void TimeConverter()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string formatedTime = string.Format("{00:00} : {01:00}", minutes, seconds);
        canvases[1].text = formatedTime;

        if(dead)
        {
            scoreBoardCanvas.SetActive(true);
            FinalScore(formatedTime);
            pScript.ThrowOnOff(false);
        }
    }

    //Under Construction

    private IEnumerator TeleprompterJokes()
    {
        while(!dead)
        {
            displayedJoke = joke.JokeAssembler();

            canvases[0].text = displayedJoke[0];
            yield return new WaitForSeconds(4);

            canvases[0].text = displayedJoke[1];
            yield return new WaitForSeconds(4);
        }
    }

    public void LoseHealth(){
        healthbarCanvas.GetComponent<HorizontalLayoutGroup>().enabled = false;
        if(health > 0){
            health--;
            healthbarCanvas.transform.GetChild(health).gameObject.SetActive(false);
        }
        if(health == 0)
            dead = true;
    }


    //Never to be spoken of (Learning opportunity)

    // private IEnumerator TimeCounter()
    // {
    //     int seconds = 0;
    //     int minutes = 0; 

    //     string displayedText;
    //     string elapsedSeconds, elapsedMinutes;  
        
    //     while(true)
    //     {
    //         yield return new WaitForSeconds(1);
    //         seconds++;

    //         if (seconds == 60)
    //         {
    //             minutes++;
    //             seconds = 0;
    //         }

    //         if (seconds < 10) { elapsedSeconds = "0" + seconds.ToString(); }

    //         else { elapsedSeconds = seconds.ToString();}

    //         if (minutes < 10) { elapsedMinutes = "0" + minutes.ToString(); }

    //         else { elapsedMinutes = minutes.ToString();}


    //         displayedText = elapsedMinutes + ":" + elapsedSeconds;

    //         //Debug.Log(displayedText);
    //         canvases[1].text = displayedText;
    //     }
    // }
}
