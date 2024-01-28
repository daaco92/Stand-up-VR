using System;
using System.IO;
using System.Net;
using Assets.Danilo.Scripts;
using Newtonsoft.Json;
using UnityEngine;

public class GetJokeScript : MonoBehaviour
{
    public Joke GetJoke()
    {
        Joke joke = new Joke();

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/Any");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            //Debug.Log(json);
            JokeData result = JsonConvert.DeserializeObject<JokeData>(json);

            if (result.error == true || result == null)
            {
                return new Joke { setup = "ERROR: ", delivery = "MUST WAIT A MOMENT" };
            }

            return new Joke { setup = result.setup, delivery = result.delivery };
        }
        catch (Exception e)
        {
            //Debug.Log("An Errorrr ocurred: " + e.Message);
            return new Joke { setup = "ERROR: ", delivery = e.Message };
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
