using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public double score = 0;
    private bool updateSpeed = false;
    public float factor = 0.01f;

    private bool newChicken = false;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    private Vector3 moveVectorHorizontal;
    private Vector3 moveVectorVertical;
    private Vector3 jumpVector;
    // Start is called before the first frame update
    void Start()
    {
        moveVectorHorizontal = new Vector3(1 * factor, 0, 0);
        moveVectorVertical = new Vector3(0, 1 * factor, 0);
        jumpVector = new Vector3(transform.position.x + 2, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        jumpVector = new Vector3(transform.position.x + 1, transform.position.y, 0);
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.position = jumpVector;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Feather"))
        {
            updateSpeed = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Saved"))
        {
            newChicken = true;
        }

        if (collision.gameObject.CompareTag("River"))
        {
            Debug.Log("RIVER");
            Destroy(this.gameObject);
        }

    }
    
}
