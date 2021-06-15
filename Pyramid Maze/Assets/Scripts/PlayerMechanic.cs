using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;

    private Vector3 playerMoviment;
    private bool isMoving;

    private bool isForwardColliding;
    private bool isRightColliding;
    private bool isBackColliding;
    private bool isLeftColliding;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        playerMoviment = new Vector3(0.0f, 0.0f, 0.0f);

        isMoving = false;

        // isForwardColliding = false;
        // isRightColliding = false;
        // isBackColliding = false;
        // isLeftColliding = false;
    }

    void FixedUpdate() {
         if (!isMoving){
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerMoviment = Vector3.forward;
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playerMoviment = Vector3.right;
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerMoviment = Vector3.back;
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerMoviment = Vector3.left;
                isMoving = true;
            }
        }

        movePlayer(playerMoviment);
    }

    void movePlayer(Vector3 playerMoviment){
        rb.MovePosition(transform.position + (playerMoviment * speed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        // float force = 100000;
        // Vector3 dir = collision.contacts[0].point - transform.position;
        // dir = -dir.normalized;
        // Debug.Log(dir);
        // rb.AddForce(dir*force);
        
        // transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        // movePlayer(-10*playerMoviment);
        
        // rb.MovePosition(transform.position + (-10*playerMoviment * speed * Time.deltaTime));
        
        // transform.position = Vector3.MoveTowards(transform.position, transform.position - 10*playerMoviment, speed * Time.deltaTime);

        transform.position = transform.position - Vector3.Scale(new Vector3((float)0.25, (float)0.25, (float)0.25), playerMoviment);

        if (collision.gameObject.name == "Edges" || collision.gameObject.name == "Walls") {
            playerMoviment = Vector3.zero;
            isMoving = false;
            Debug.Log(collision.gameObject.tag);
        }
    }
}