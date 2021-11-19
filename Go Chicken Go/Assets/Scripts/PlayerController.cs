using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float factor = 0.01f;

    public SpriteRenderer spriteRenderer;

    private Vector3 moveVectorHorizontal;
    private Vector3 moveVectorVertical;
    // Start is called before the first frame update
    void Start()
    {
        moveVectorHorizontal = new Vector3(1 * factor, 0, 0);
        moveVectorVertical = new Vector3(0, 1 * factor, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveVectorHorizontal;

            spriteRenderer.flipX = true;

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveVectorHorizontal;

            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += moveVectorVertical;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= moveVectorVertical;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIIII");
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(this.gameObject);
        }
    }
}
