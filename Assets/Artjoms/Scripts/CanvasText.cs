using Assets.Danilo.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] canvases;

    private float timer;
    private IEnumerator fetchJoke;
    private GetJokeScript jokes;
    
    //string[] text = new string[2];

    [SerializeField] private bool dead = false;

    private void Start()
    {
        GameObject jokesObject = new GameObject("JokesObject");
        jokes = jokesObject.AddComponent<GetJokeScript>();
        StartCoroutine(TeleprompterJokes());
    }

    private void Update()
    {
        if (!dead)
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

        if (dead)
        {
            FinalScore(formatedTime);
        }
    }

    //Under Construction
    //asd

    private IEnumerator TeleprompterJokes()
    {
        while (!dead)
        {
            Joke joke = jokes.GetJoke();
            canvases[0].text = joke.setup;
            print(joke.setup);
            yield return new WaitForSeconds(4);

            canvases[0].text = joke.delivery;
            print(joke.delivery);
            yield return new WaitForSeconds(4);
        }
    }
}
