using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;

public class ScoreReaderWriter {
    private float[] high_scores;
    private string[] names;
    private FileStream filestream;
    private int numScores;
    private Encoding u32;

    public ScoreReaderWriter()
    {
        high_scores = new float[] { 0,0,0,0,0,0,0,0,0,0 };
        names = new string[] { "", "", "", "", "", "", "", "", "", "" };
        filestream = new FileStream("scores.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        numScores = 0;
        u32 = Encoding.UTF32;
        ReadFrom();
    }

    ~ScoreReaderWriter()
    {
        filestream.Close();
    }

    private void ReadFrom()
    {
        byte[] data = new byte[1024];
        ArrayList content = new ArrayList();
        int len;
        string input = "";
        while ((len = filestream.Read(data,0,1024)) != 0)
        {
            input = u32.GetString(data);
            for (int i = 0; i < len; i++)
            {
                char[] intermediate = input.ToCharArray();
                string temp= "";
                if (intermediate[i] != '\n' && intermediate[i] != '\r')
                {
                    temp += intermediate[i];
                }
                else
                {
                    if (temp.CompareTo("") != 0)
                    {
                        content.Add(temp);
                        temp = "";
                    }
                }
            }
        }
        if (content.Count == 0)
        {
            numScores = -1;
        }
        else
        {
            int index = 0;
            foreach (string s in content)
            {
                float score;
                    if (float.TryParse(s, out score))
                    {
                        high_scores[index++] = score;
                    }
                    else
                    {
                        names[index] = s;
                    }
            }
            numScores = index;
        }
    }

    private bool WriteTo()
    {
        try
        {
            for (int i = 0; i < numScores; i++)
            {
                string data = "";
                data += high_scores[i] + "\n" + names[i] + "\n";
                char[] intermediate = data.ToCharArray();
                byte[] output = u32.GetBytes(intermediate);
                filestream.Write(output, 0, output.Length);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool highScore(float score)
    {
        return (CompareScore(score) >= 0);
    }

    private int CompareScore(float score)
    {
        if (numScores == -1)
        {
            return 0;
        }
        else if (score < high_scores[numScores] && numScores == 9)
        {
            return -1;
        }
        else
        {
            int index = 0;
            while (score <= high_scores[index])
            {
                index++;
            }
            if (numScores < 9)
                numScores++;
            return index;
        }
    }

    public float[] getScores()
    {
        return high_scores;
    }

    public string[] getNames()
    {
        return names;
    }

    public bool addScore(string name, float score)
    {
        int index = 0;
        if ((index = CompareScore(score)) < 0)
        {
            return false;
        }
        else
        {
            float tempScore;
            string tempName;
            for (int i = index; i < 10; i++)
            {
                tempScore = high_scores[i];
                tempName = names[i];
                high_scores[i] = score;
                names[i] = name;
                score = tempScore;
                name = tempName;
            }
            if (!WriteTo())
            {
                Debug.Log("Error: Failed to write to save file");
            }
            return true;
        }
    }
}
