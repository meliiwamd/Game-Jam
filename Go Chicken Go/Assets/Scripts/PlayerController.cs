using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public double score = 0;
    public EventSystemCustom eventSystem;

    private bool riverTouch = false;
    private bool trunckTouch = false;
    private bool secondTrunckTouch = false;

    private bool updateSpeed = false;
    private float updateSpeedMaxTime = 8;
    private float updateSpeeCurrentTime;
    public float factor = 0.01f;

    public int chickenCount = 3;

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
        jumpVector = new Vector3(transform.position.x + 1, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (chickenCount > 0)
        {
            jumpVector = new Vector3(transform.position.x + 1, transform.position.y, 0);

            if (updateSpeed)
            {
                if (updateSpeeCurrentTime > 0)
                {
                    updateSpeeCurrentTime -= Time.deltaTime;
                    factor = 0.04f;
                    moveVectorHorizontal = new Vector3(1 * factor, 0, 0);
                    moveVectorVertical = new Vector3(0, 1 * factor, 0);
                }
                else
                {
                    updateSpeed = false;
                    factor = 0.01f;
                    moveVectorHorizontal = new Vector3(1 * factor, 0, 0);
                    moveVectorVertical = new Vector3(0, 1 * factor, 0);
                }
            }

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

            if (trunckTouch)
            {
                if (transform.position.x < 0)
                    transform.position += new Vector3(0, 0.01f, 0);
                else
                    transform.position -= new Vector3(0, 0.01f, 0);
            }

            else if (secondTrunckTouch)
            {
                if (transform.position.x < 0)
                    transform.position += new Vector3(0, 0.01f, 0);
                else
                    transform.position -= new Vector3(0, 0.01f, 0);
            }

            if (riverTouch && !trunckTouch && !secondTrunckTouch && chickenCount > 0)
            {
                riverTouch = false;
                if (chickenCount > 0)
                {
                    transform.position = GetNewPosition();
                    eventSystem.OnChickenCount.Invoke();
                }
            }
        }
        else
            Destroy(this.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            eventSystem.OnChickenCount.Invoke();
            if (chickenCount > 0)
            {
                transform.position = GetNewPosition();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Feather"))
        {
            updateSpeed = true;
            score += 100;
            eventSystem.OnScore.Invoke();
            updateSpeeCurrentTime = updateSpeedMaxTime;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Saved"))
        {
            score += 400;
            eventSystem.OnScore.Invoke();
            eventSystem.OnChickenCount.Invoke();

            if(chickenCount > 0)
            {
                transform.position = GetNewPosition();
            }
        }

        if (collision.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Tree");
             trunckTouch = true;
        }

        if (collision.gameObject.CompareTag("TreeRight"))
        {
            Debug.Log("TreeRight");
            secondTrunckTouch = true;
        }

        if (collision.gameObject.CompareTag("River"))
        {
            Debug.Log("RIVER");
            riverTouch = true;
        }

    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Tree out");
            trunckTouch = false;
        }
        if (collision.gameObject.CompareTag("TreeRight"))
        {
            Debug.Log("Tree 2 out");
            secondTrunckTouch = false;
        }
        if (collision.gameObject.CompareTag("River"))
        {
            Debug.Log("River out");
            riverTouch = false;
        }
    }

    private Vector3 GetNewPosition()
    {
        return new Vector3(-5f, 0.7f, transform.position.z);
    }

    float GetRandom(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    int GetRandomPrefabType(int max)
    {
        return UnityEngine.Random.Range(0, max);
    }

}
