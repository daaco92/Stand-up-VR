using System;
using System.Collections;
using System.IO;
using System.Net;
using Assets.Danilo.Scripts;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class GetJokeScript : MonoBehaviour
{
    public Joke GetJoke()
    {
        Joke joke = new Joke();
        StartCoroutine(FetchJoke(joke));
        return joke;
    }

    private IEnumerator FetchJoke(Joke joke)
    {
        if (joke is null)
        {
            throw new ArgumentNullException(nameof(joke));
        }

        using (UnityWebRequest www = UnityWebRequest.Get("https://v2.jokeapi.dev/joke/Any"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Parse the JSON response
                JokeData result = JsonUtility.FromJson<JokeData>(www.downloadHandler.text);

                if (result.error == true || result == null)
                {
                    joke = new Joke { setup = "ERROR: ", delivery = "MUST WAIT A MOMENT" };
                }
                else
                {
                    joke = new Joke { setup = result.setup, delivery = result.delivery };
                }
            }
        }

        yield break;
    }


    //public IEnumerator GetJoke()
    //{


    //    using (UnityWebRequest www = UnityWebRequest.Get("https://v2.jokeapi.dev/joke/Any"))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            Debug.Log(www.downloadHandler.text);

    //        }
    //    }
    //}
    //public Joke GetJoke()
    //{
    //    Joke joke = new Joke();

    //    try
    //    {
    //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/Any");
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

    //        StreamReader reader = new StreamReader(response.GetResponseStream());
    //        string json = reader.ReadToEnd();
    //        //Debug.Log(json);
    //        JokeData result = JsonUtility.FromJson<JokeData>(json);

    //        if (result.error == true || result == null)
    //        {
    //            return new Joke { setup = "ERROR: ", delivery = "MUST WAIT A MOMENT" };
    //        }

    //        return new Joke { setup = result.setup, delivery = result.delivery };
    //    }
    //    catch (Exception e)
    //    {
    //        //Debug.Log("An Errorrr ocurred: " + e.Message);
    //        return new Joke { setup = "CATCHED ERROR: ", delivery = e.Message };
    //    }
    //}


    //public Joke GetJokew()
    //{
    //    Joke joke = new Joke();

    //    try
    //    {
    //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/Any");
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

    //        StreamReader reader = new StreamReader(response.GetResponseStream());
    //        string json = reader.ReadToEnd();
    //        Debug.Log(json);
    //        JokeData result = JsonUtility.FromJson<JokeData>(json);

    //        if (result.error == true || result == null)
    //        {
    //            return new Joke { setup = "ERROR: ", delivery = "MUST WAIT A MOMENT" };
    //        }

    //        return new Joke { setup = result.setup, delivery = result.delivery };
    //    }
    //    catch (Exception e)
    //    {
    //        Debug.Log("An Errorrr ocurred: " + e.Message);
    //        return new Joke { setup = "CATCHED ERROR: ", delivery = e.Message };
    //    }
    //}

    [Serializable]
    public class Flags
    {
        public bool nsfw;
        public bool religious;
        public bool political;
        public bool racist;
        public bool sexist;
        public bool @explicit;
    }

    [Serializable]
    public class JokeData
    {
        public bool error;
        public string category;
        public string type;
        public string setup;
        public string delivery;
        public Flags flags;
        public int id;
        public bool safe;
        public string lang;
    }
}
