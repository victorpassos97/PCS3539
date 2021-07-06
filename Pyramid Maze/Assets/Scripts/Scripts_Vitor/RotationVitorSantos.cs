using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationVitorSantos : MonoBehaviour
{
    public Quaternion startQuaternion;

    public bool rotateConstantly;

    void Start()
    {
        startQuaternion = transform.rotation;
    }

    void Update()
    {
        if(rotateConstantly)
        {
            transform.Rotate(new Vector3(0f,100f,0f)*Time.deltaTime);
        }
        
 
    }


}