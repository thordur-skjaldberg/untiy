using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -10);

    void Start()
    {
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
