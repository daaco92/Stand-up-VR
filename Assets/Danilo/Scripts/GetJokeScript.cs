using System;
using System.IO;
using System.Net;
using UnityEngine;
using Newtonsoft.Json;

public class GetJokeScript : MonoBehaviour
{
    // Start is called before the first frame update
    string[] GetJoke()
    {
        string[] joke = new string[2];
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/Any");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            Debug.Log(json);
            Joke result = JsonConvert.DeserializeObject<Joke>(json);
            
            
            Debug.Log(result.setup);
            Debug.Log(result.delivery);

            joke[0] = result.setup;
            joke[1] = result.delivery;
            return joke;
        }
        catch (Exception e)
        {
            Debug.Log("An Errorrr ocurred: " + e.Message);
            return joke;
        }
    }

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
    public class Joke
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
