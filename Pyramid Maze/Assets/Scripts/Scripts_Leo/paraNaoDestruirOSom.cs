using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraNaoDestruirOSom : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
