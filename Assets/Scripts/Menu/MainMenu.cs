using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public TMP_Text m_CoinText;
    public TMP_Text m_DistanceText;
    public TMP_Text m_hint;
    void Start()
    {
        m_CoinText.text = ""+PlayerPrefs.GetInt("coinCount");
        m_DistanceText.text = ""+PlayerPrefs.GetInt("distanceCount");
    }

    void Update()
    {}

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowAchievements()
    {
        
    }

    public void ShowStore()
    {
        m_hint.text = "You have a total of " + PlayerPrefs.GetInt("totalCoins") + " Coins!";
    }

    public void WipeStats()
    {
        PlayerPrefs.DeleteAll();
    }
}
