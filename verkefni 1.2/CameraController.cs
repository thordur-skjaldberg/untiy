using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Tilvísun í staðsetningu leikmanns
    public GameObject player;
    
    // Geymir tilfærslugildi (offset)
    // private - stillt í kóðanum
    private Vector3 offset;

    // Start er kallað áður en fyrsta rammauppfærsla á sér stað
    void Start()
    {
        // Stillir offset þannig að það sé staða myndavélarinnar mínus staða leikmanns
        offset = transform.position - player.transform.position; 
    }

    // LateUpdate er kallað einu sinni í hverjum ramma, eftir að allar Update aðferðir hafa keyrt
    void LateUpdate()
    {
        // Uppfærir stöðu myndavélarinnar til að fylgja leikmanninum með offsetinu
        transform.position = player.transform.position + offset;
    }
}
