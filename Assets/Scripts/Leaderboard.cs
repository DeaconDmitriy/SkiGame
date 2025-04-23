using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();
    [SerializeField] private TextMeshProUGUI leaderboardText; 

    private void Awake()
    {
        LoadTimes();
        UpdateUI();
    }

    public void AddRaceTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveTimes();
        UpdateUI();
    }

    private void SaveTimes()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < bestTimes.Count)
                PlayerPrefs.SetFloat("time" + i, bestTimes[i]);
        }
        PlayerPrefs.Save();
    }

    private void LoadTimes()
    {
        bestTimes = new List<float>();

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("time" + i))
            {
                bestTimes.Add(PlayerPrefs.GetFloat("time" + i));
            }
        }
    }


    private void UpdateUI()
    {
        if (leaderboardText == null) return;

        leaderboardText.text = "🏁 Top 5 Times:\n";

        for (int i = 0; i < bestTimes.Count && i < 5; i++)
        {
            leaderboardText.text += $"{i + 1}. {bestTimes[i]:F2} sec\n";
        }
    }
}
