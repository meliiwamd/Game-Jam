using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text score;
    public Text chickenCount;

    public EventSystemCustom eventSystem;

    public PlayerController player;

    void Awake()
    {
        chickenCount.text = player.chickenCount.ToString();
    }

    void Start()
    {
        eventSystem.OnScore.AddListener(UpdateScoreText);
        eventSystem.OnChickenCount.AddListener(UpdateChickenCount);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        score.text = player.score.ToString();
    }

    public void UpdateChickenCount()
    {
        Debug.Log("UPDATE CHICKEN COUNT");
        player.chickenCount -= 1;
        chickenCount.text = player.chickenCount.ToString();
    }
}
