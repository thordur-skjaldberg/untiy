using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kassi : MonoBehaviour
{
    // Breyta sem heldur utan um fjölda stig
    public static int count = 0;

    // GameObject sem á að nota til að búa til sprengingu
    public GameObject sprenging;

    // TextMeshPro sem sýnir stigatölu á skjánum
    private TextMeshProUGUI countText;

    // Keyrist í upphafi þegar hluturinn er virkjaður
    void Start()
    {
        // Nær í TextMeshPro hluta með nafninu "Text" til að uppfæra stigatölu
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();

        // Endurstillir stigin í 0 í byrjun
        count = 0;

        // Uppfærir textann til að sýna stigin
        SetCountText();
    }

    // Keyrist á hverjum ramma
    private void Update()
    {
        // Athugar hvort kassinn hefur fallið út fyrir heiminn (y-hnit minna en -10)
        if (transform.position.y < -10)
        {
            Destroy(gameObject); // Eyðir kassanum úr senunni
            gameObject.SetActive(false); // Gerir hlutinn óvirkan (fyrir öryggi)
        }
    }

    // Keyrist þegar kassi rekst á annan hlut
    private void OnCollisionEnter(Collision collision)
    {
        // Athugar hvort áreksturinn er við hlut með tagið "kula"
        if (collision.collider.tag == "kula")
        {
            // Eyðir kassanum úr senunni
            Destroy(gameObject);

            // Gerir hlutinn óvirkan (þó hann sé nú þegar eytt)
            gameObject.SetActive(false);

            // Skráir skilaboð í Console til að staðfesta að árekstur varð
            Debug.Log("varð fyrir kúlu");

            // Eykur stigatölu um 1
            count = count + 1;

            // Uppfærir stigatölu á skjánum
            SetCountText();

            // Býr til sprengingu í staðsetningu kassans
            Sprengin();
        }
    }

    // Fall sem uppfærir stigatölu textann á skjánum
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString(); // Sýnir stigin sem texta
    }

    // Fall sem býr til sprengingu á staðsetningu kassans
    void Sprengin()
    {
        Instantiate(sprenging, transform.position, transform.rotation); // Býr til sprengingu
    }
}
