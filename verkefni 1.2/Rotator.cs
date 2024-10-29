using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{ 
    // Update er kallað einu sinni í hverjum ramma
    void Update()
    {
        // Snýr hlutnum með ákveðnum hraða yfir tíma
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
