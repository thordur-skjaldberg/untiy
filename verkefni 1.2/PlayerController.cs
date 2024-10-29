using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float speed = 5.0f; // Hraði bílsins
    public float horizontalSpeed = 5.0f; // Hliðarsnúningshraði bílsins
    public float turnSpeed = 100.0f; // Snúningur bílsins
    private float horizontalInput; // Inntak fyrir hliðarsnúningsstýring
    private float forwardInput; // Inntak fyrir hreyfingu áfram
    private float rotationInput; // Inntak fyrir snúning með Q og R

    // Start er kallað einu sinni við upphaf
    void Start()
    {
        
    }

    // Update er kallað einu sinni á hverjum ramma
    void Update()
    {
        // Fá inntak fyrir lárétta og lóðrétta hreyfingu
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Fá inntak fyrir snúning með Q (vinstri) og R (hægri)
        if (Input.GetKey(KeyCode.Q))
        {
            rotationInput = -1; // Snúa bílnum til vinstri
        }
        else if (Input.GetKey(KeyCode.R))
        {
            rotationInput = 1; // Snúa bílnum til hægri
        }
        else
        {
            rotationInput = 0; // Engin snúningur
        }

        // Hreyfa bílinn áfram eða afturábak
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Hreyfa bílinn til vinstri og hægri
        transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput);

        // Snúa bílinn með Q og R
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * rotationInput);
    }
}
