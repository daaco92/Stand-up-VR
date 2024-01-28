using System.Collections;
using TMPro;
using UnityEngine;


public class CanvasText : MonoBehaviour
{
    [SerializeField] private string[] jokes;
    [SerializeField] private TextMeshProUGUI[] canvases;
    bool makingSound;
    int score = 0;

    private void Start()
    {
        StartCoroutine("TimeCounter");
    }
    void Update(){
        if(makingSound)
            score++;
        Debug.Log(score);
    }
    public void OnOff(bool keeper){
        makingSound = keeper;
    }

    private IEnumerator TimeCounter()
    {
        string displayedText;
        int seconds = 0;
        int minutes = 0; 
        string elapsedSeconds, elapsedMinutes;  
        
        while(true)
        {
            yield return new WaitForSeconds(1);
            seconds++;

            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }

            if (seconds < 10) { elapsedSeconds = "0" + seconds.ToString(); }

            else { elapsedSeconds = seconds.ToString();}

            if (minutes < 10) { elapsedMinutes = "0" + minutes.ToString(); }

            else { elapsedMinutes = minutes.ToString();}


            displayedText = elapsedMinutes + ":" + elapsedSeconds;

            Debug.Log(displayedText);
            canvases[1].text = displayedText;
        }
    }
}
