using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    public Transform location;
    public Vector3 position;
    public float moveSpeed;
    public float turnSpeed;

    // Start er kallað áður en fyrsta rammauppfærsla á sér stað
    void Start()
    {

    }

    // Update er kallað einu sinni í hverjum ramma
    void Update()
    {
        // Athugar hvort ýtt er á upp örina eða W og færir hlutinn áfram
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        // Athugar hvort ýtt er á niður örina eða S og færir hlutinn afturábak
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        // Athugar hvort ýtt er á vinstri örina eða A og færir hlutinn til vinstri
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        // Athugar hvort ýtt er á hægri örina eða D og færir hlutinn til hægri
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        // Athugar hvort LeftShift og Q eru niðri og snýr hlutnum niður á við
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        }
        // Athugar hvort LeftShift og A eru niðri og snýr hlutnum upp á við
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
        }
    }
}
