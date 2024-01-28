using TMPro;
using UnityEngine;

public class CanvasText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] canvases;
    private GetJokeScript jokes;
    private float timer;
    string[] text = new string[2];

    private void Start()
    {   
        //StartCoroutine("TeleprompterJokes");
        jokes = new GetJokeScript();
        //StartCoroutine(TeleprompterJokes());
    }

    private void Update ()
    {
        timer += Time.deltaTime;
        //TimeConverter();
    }

    private void TimeConverter()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string formatedTime = string.Format("{00:00} : {01:00}", minutes, seconds);
        canvases[1].text = formatedTime;
    }

    //Under Construction
    // private IEnumerator TeleprompterJokes()
    // {
    //     while(true)
    //     {
    //         text = jokes.GetJoke();
    //         Debug.Log(text[0]);
    //         yield return new WaitForSeconds(3);

    //         Debug.Log(text[1]);
    //         yield return new WaitForSeconds(20);
    //     }
    // }

    //Never to be spoken about (Learning opportunity)
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
