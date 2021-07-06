using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    
    public Transform portalOut;

    void OnTriggerEnter(Collider collision) {
        // collision.gameObject.transform.position = portalOut.position;
        collision.gameObject.transform.position = new Vector3(portalOut.position.x,portalOut.position.y+0.1f,portalOut.position.z);
    }

}
