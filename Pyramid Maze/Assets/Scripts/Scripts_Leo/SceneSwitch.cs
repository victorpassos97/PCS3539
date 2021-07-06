using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int cenaDestino = 0;
    void OnTriggerEnter(Collider other)
    {
        // Para mandar da cena atual para a cena 1
        SceneManager.LoadScene(cenaDestino);
    }
}
