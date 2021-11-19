using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlacer : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject plumage;

    public float timerMaxTime;
    private float currentTimerValue;
    // Start is called before the first frame update
    void Start()
    {
        currentTimerValue = timerMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            GameObject go;

            if (UnityEngine.Random.Range(0, 2000) % 5 != 0)
            {
                go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
                if (transform.position.x  < 0)
                    go.transform.position = new Vector3(GetRandomPrefabInitialXLeft(), transform.position.y, transform.position.z);
                else
                    go.transform.position = new Vector3(GetRandomPrefabInitialXRight(), transform.position.y, transform.position.z);
            }

            // reset timer
            currentTimerValue = timerMaxTime;
        }
    }

    int GetRandomPrefabType(int max)
    {
        return UnityEngine.Random.Range(0, max);
    }

    float GetRandomPrefabInitialXLeft()
    {
        int random = UnityEngine.Random.Range(0, 2);
        if (random == 0)
            return -3.4f;
        return -1.8f;
    }

    float GetRandomPrefabInitialXRight()
    {
        int random = UnityEngine.Random.Range(0, 2);
        if (random == 0)
            return 1.7f;
        return 3.5f;
    }

    float GetRandomDimond(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}
