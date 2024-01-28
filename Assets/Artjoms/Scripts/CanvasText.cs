using Assets.Danilo.Scripts;
using System.Collections;
using TMPro;
using UnityEngine;

public class CanvasText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] canvases;

    private float timer;
    Joke displayedJoke;
    private GetJokeScript jokes;
    
    //string[] text = new string[2];

    [SerializeField] private bool dead = false;

    private void Start()
    {
        jokes = new GetJokeScript();
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
            try
            {
                displayedJoke = jokes.GetJoke();
            }
            catch (System.Exception )
            {
                displayedJoke.setup = "NULL";
                displayedJoke.delivery = "NULL";
            }
            
            print(displayedJoke.setup);
            print(displayedJoke.delivery);

            canvases[0].text = displayedJoke.setup;
            yield return new WaitForSeconds(4);

            canvases[0].text = displayedJoke.delivery;
            yield return new WaitForSeconds(4);
        }
    }
}
