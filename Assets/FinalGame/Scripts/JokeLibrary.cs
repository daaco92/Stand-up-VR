using System.Collections.Generic;
using UnityEngine;

public class JokeLibrary : MonoBehaviour
{
    List<string> joke = new();
    List<string> punchLine = new();
    public List<string> completeJoke = new(), completeCompleteJoke = new();
    int index;

    public List<string> MakeList()
    {
        JokeLib();
        PunchLineLib();
        completeCompleteJoke = JokeAssembler();

        return completeCompleteJoke;
    }
    List<string> JokeAssembler()
    {
        index = Random.Range(0, 13);

        if(completeJoke.Contains(joke[index]))
        {
            index = Random.Range(0, 13);
        }

        completeJoke.Clear();

        completeJoke.Add(joke[index]);
        completeJoke.Add(punchLine[index]);

        return completeJoke;
    }

    private void JokeLib()
    {
        joke.Add("I WRITE MY JOKES IN CAPITALS.");
        joke.Add("What time did the man go to the dentist?");
        joke.Add("Why was the mushroom always invited to parties?");
        joke.Add("I just got fired from my job at the keyboard factory.");
        joke.Add("Why couldn't the skeleton go to the Christmas party?");
        joke.Add("Why does the size of the snack not matter to a giraffe?");
        joke.Add("How do construction workers party?");
        joke.Add("My wife divorced me so I stole her wheelchair.");
        joke.Add("How much did your chimney cost?");
        joke.Add("I visited my friend at his new house. He told me to make myself at home.");
        joke.Add("This morning I accidentally made my coffee with Red Bull instead of water.");
        joke.Add("Schrödinger's cat walks into a bar and doesn't.");
        joke.Add("Did you hear about the crime in the parking garage?");
        // joke.Add("");
        // joke.Add("");
    }

    private void PunchLineLib()
    {
        punchLine.Add("THIS ONE WAS WRITTEN IN PARIS.");
        punchLine.Add("Tooth hurt-y.");
        punchLine.Add("Cause he's a fungi.");
        punchLine.Add("They told me I wasn't putting in enough shifts.");
        punchLine.Add("Because he had no body to go with!");
        punchLine.Add("Because even a little bit goes a long way.");
        punchLine.Add("They raise the roof.");
        punchLine.Add("Guess who came crawling back.");
        punchLine.Add("Nothing, it was on the house.");
        punchLine.Add("So I threw him out. I hate having visitors.");
        punchLine.Add("I was already on the highway when I noticed I forgot my car at home.");
        punchLine.Add("-");
        punchLine.Add("It was wrong on so many levels.");
        // joke.Add("");
        // joke.Add("");
    }
}