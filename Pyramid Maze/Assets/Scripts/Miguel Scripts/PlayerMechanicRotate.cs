using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanicRotate : MonoBehaviour
{
    public float speed = 12.5f;
    private Rigidbody rb;

    private Vector3 playerMoviment;
    private Vector3 playerRotation;
    private Quaternion rotation; 
    private float angle;
    private bool isMoving;
    private bool isRotating;
    
    // private Animator animator;

    public Transform target;
    private Quaternion targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        playerMoviment = new Vector3(0.0f, 0.0f, 0.0f);
        playerRotation = new Vector3(0.0f, 0.0f, 0.0f);

        isMoving = false;
        isRotating = false;

        // animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        if (!isMoving && !isRotating){
            
            if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W))
            {
                // playerMoviment = Vector3.forward;
                playerMoviment = new Vector3(-1,0,0);
                target.position = new Vector3(transform.position.x,transform.position.y,10+transform.position.z);
                isRotating = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D))
            {
                // playerMoviment = Vector3.right;
                playerMoviment = new Vector3(0,0,1);
                target.position = new Vector3(10+transform.position.x,transform.position.y,transform.position.z);
                isRotating = true;
                
            }
            else if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S))
            {  
                // playerMoviment = Vector3.back;
                playerMoviment = new Vector3(1,0,0);
                target.position = new Vector3(transform.position.x,transform.position.y,-10+transform.position.z);
                isRotating = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A))
            {
                // playerMoviment = new Vector3(0,0,-1);
                playerMoviment = new Vector3(0,0,-1);
                target.position = new Vector3(-10+transform.position.x,transform.position.y,transform.position.z);
                isRotating = true;
            }
        }

        if(isMoving){
            movePlayer(playerMoviment);
        }

        if(isRotating){
            rotatePlayer();
        }
        
    }

    void movePlayer(Vector3 playerMoviment){
        rb.MovePosition(transform.position + (playerMoviment * speed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.position = transform.position - Vector3.Scale(new Vector3((float)0.25, (float)0.25, (float)0.25), playerMoviment);

        if (collision.gameObject.tag == "Block" || collision.gameObject.name == "Edges" || collision.gameObject.name == "Walls") {
            playerMoviment = Vector3.zero;
            isMoving = false;
            // Debug.Log(collision.gameObject.name);
        }
    }

    void rotatePlayer(){

        var previousPosition = transform.rotation;
        targetPosition = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetPosition, 200 * Time.deltaTime);  
        // Debug.Log("obj" + transform.rotation);
        
        if (transform.rotation != previousPosition){
            previousPosition = transform.rotation;
        }
        else {
            isRotating = false;
            isMoving = true;
        }
        
    }
}
