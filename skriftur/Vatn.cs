using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vatn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Athuga hvort "other" hefur tag "Player"
        {
            Debug.Log("Drukknaði");
            SceneManager.LoadScene("Dóst"); // Hleður inn senunni með nafninu "Drukknaði"
        }
    }
}
