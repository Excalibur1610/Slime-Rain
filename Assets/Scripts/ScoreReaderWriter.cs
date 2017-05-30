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
        if (File.Exists("scores.dat"))
        {
            filestream = new FileStream("scores.dat", FileMode.Open, FileAccess.ReadWrite);
        }
        else
        {
            File.Create("scores.dat").Dispose();
            filestream = new FileStream("scores.dat", FileMode.Open, FileAccess.ReadWrite);
        }
        numScores = 0;
        u32 = Encoding.ASCII;
        if (!ReadFrom())
        {
            filestream.Dispose();
            filestream.Close();
            File.Delete("scores.dat");
            File.Create("scores.dat").Dispose();
            filestream = new FileStream("scores.dat", FileMode.Open, FileAccess.ReadWrite);
            high_scores = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            names = new string[] { "", "", "", "", "", "", "", "", "", "" };
            numScores = 0;
            Debug.Log("Score file corrupted.  Creating new file....");
        }
    }

    ~ScoreReaderWriter()
    {
        filestream.Dispose();
        filestream.Close();
    }

    public void Dispose()
    {
        filestream.Dispose();
        filestream.Close();
    }

    private bool ReadFrom()
    {
        if (filestream.Length == 0)
        {
            numScores = 0;
        }
        else
        {
            byte[] data = new byte[8192];
            int bData;
            for (int i = 0; (bData = filestream.ReadByte()) != -1; i++)
            {
                data[i] = (byte)bData;
            }
            string[] input = u32.GetString(data).Split('\n');
            int index = 0;
            bool isName = true;
            foreach (string s in input)
            {
                if (isName)
                {
                    names[index] = s;
                }
                else
                {
                    float score;
                    if (float.TryParse(s, out score))
                    {
                        high_scores[index++] = score;
                    }
                    else
                    {
                        return false;
                    }
                }
                isName = !isName;
            }
            numScores = index-1;
        }
        return true;
    }

    private bool WriteTo()
    {
        try
        {
            string data = "";
            for (int i = 0; i <= numScores; i++)
            {
                data += names[i] + "\n" + high_scores[i] + "\n";
            }
            byte[] output = u32.GetBytes(data);
            filestream.Write(output, 0, output.Length);
            filestream.Flush();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool HighScore(float score)
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

    public float[] GetScores()
    {
        return high_scores;
    }

    public string[] GetNames()
    {
        return names;
    }

    public bool AddScore(string name, float score)
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
                return false;
            }
            return true;
        }
    }
}
