using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnScore;
    public UnityEvent OnChickenCount;


    void Awake()
    {
        OnScore = new UnityEvent();
        OnChickenCount = new UnityEvent();
    }
}
