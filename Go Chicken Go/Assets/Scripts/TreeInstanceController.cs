using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInstanceController : MonoBehaviour
{
    private Vector3 moveVectorHorizontal;
    public float speed = 0.01f;

    void Start()
    {
        if(transform.position.x > 0)
            moveVectorHorizontal = new Vector3(0, -1 * speed, 0);
        else
            moveVectorHorizontal = new Vector3(0, 1 * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVectorHorizontal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathCar"))
        {
            Destroy(this.gameObject);
        }
    }
}
