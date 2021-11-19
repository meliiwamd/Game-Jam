using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlacer : MonoBehaviour
{
    public GameObject tree;

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

            go = Instantiate(tree);
            if (transform.position.x < 0)
                go.transform.position = new Vector3(-0.4f, transform.position.y, transform.position.z);
            else
                go.transform.position = new Vector3(0.4f, transform.position.y, transform.position.z);

            // reset timer
            currentTimerValue = timerMaxTime;
        }
    }
   
}
