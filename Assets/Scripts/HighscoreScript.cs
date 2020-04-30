using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighscoreScript : MonoBehaviour
{
    static readonly string dataPath = "Assets/Data/highscores.json";

    [Serializable]
    public class Highscores
    {
        public string name;
        public int score;
    }

    [Serializable]
    public class Highscore
    {
        public Highscores[] highscores;
    }

    public static Highscore highscore;

    public static Highscore ReturnHighscores()
    {
        string jsonText = File.ReadAllText(dataPath);
        if (jsonText != "")
        {
            highscore = JsonUtility.FromJson<Highscore>(jsonText);
            Array.Sort<Highscores>(highscore.highscores, (x, y) => y.score.CompareTo(x.score));
        }

        return highscore;
    }


    public static void WriteHSFile(string name, int score)
    {
        string jsonText = File.ReadAllText(dataPath);

        Highscores newHighscore = new Highscores();
        newHighscore.name = name;
        newHighscore.score = score;

        if (jsonText != "")
        {
            highscore = JsonUtility.FromJson<Highscore>(jsonText);
            Highscore newHighScoreObject = new Highscore();

            newHighScoreObject.highscores = new Highscores[highscore.highscores.Length + 1];
            for (int i = 0; i < highscore.highscores.Length; i++)
            {
                newHighScoreObject.highscores[i] = highscore.highscores[i];
            }

            newHighScoreObject.highscores[newHighScoreObject.highscores.Length - 1] = newHighscore;

            jsonText = JsonUtility.ToJson(newHighScoreObject);

            File.WriteAllText(dataPath, jsonText);
        }
        else
        {
            highscore = new Highscore();
            highscore.highscores = new Highscores[1];
            highscore.highscores[0] = newHighscore;

            jsonText = JsonUtility.ToJson(highscore);
            File.WriteAllText(dataPath, jsonText);
        }
    }
}
