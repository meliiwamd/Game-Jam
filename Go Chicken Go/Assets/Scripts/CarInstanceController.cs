using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInstanceController : MonoBehaviour
{

    public CarConfig config;

    public float speed;
    public int direction;

    private Vector3 moveVectorHorizontal;

    void Start()
    {
        speed = config.speed;
        direction = config.direction;
        moveVectorHorizontal = new Vector3(0, direction * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVectorHorizontal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathCar"))
        {
            Destroy(this.gameObject);
        }
    }
    
}
