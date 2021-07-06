using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanism : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
	private Animator anim;

    private Vector3 playerMoviment;
    private bool isMoving;

    private bool isForwardColliding;
    private bool isRightColliding;
    private bool isBackColliding;
    private bool isLeftColliding;

	private float rot;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
	    anim = GetComponent<Animator>();
        playerMoviment = new Vector3(0.0f, 0.0f, 0.0f);
        isMoving = false;
    }

    void FixedUpdate() {
         if (!isMoving){
            if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W))
            {
				rot = 0;
				transform.eulerAngles = new Vector3(0,rot,0);
                playerMoviment = Vector3.forward;
                isMoving = true;
		        anim.SetInteger("state_transition",1);
            }
            else if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D))
            {
				rot = 90;
				transform.eulerAngles = new Vector3(0,rot,0);
                playerMoviment = Vector3.right;
                isMoving = true;
		        anim.SetInteger("state_transition",1);
            }
            else if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S))
            {
				rot = 180;
				transform.eulerAngles = new Vector3(0,rot,0);
                playerMoviment = Vector3.back;
                isMoving = true;
		        anim.SetInteger("state_transition",1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A))
            {
				rot = 270;
				transform.eulerAngles = new Vector3(0,rot,0);
                playerMoviment = Vector3.left;
                isMoving = true;
		        anim.SetInteger("state_transition",1);
            }
        }

        movePlayer(playerMoviment);
    }

    void movePlayer(Vector3 playerMoviment){
        rb.MovePosition(transform.position + (playerMoviment * speed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.position = transform.position - Vector3.Scale(new Vector3((float)0.5, (float)0.5, (float)0.5), playerMoviment);

		transform.eulerAngles = new Vector3(0,rot+90,0);
        playerMoviment = Vector3.zero;
        isMoving = false;
		anim.SetInteger("state_transition",0);
            // Debug.Log(collision.gameObject.tag);
        
    }
}