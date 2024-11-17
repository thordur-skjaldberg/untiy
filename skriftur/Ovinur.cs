using UnityEngine;

public class Ovinur : MonoBehaviour
{
    public Transform player;  // Spilarinn sem óvinurinn mun fylgja
    private Rigidbody rb;     // Rigidbody fyrir óvininn
    private Vector3 movement; // Stefna hreyfingar óvinarins
    public float hradi = 5f;  // Hraði óvinarins
    public float fallDamageThreshold = 5f; // Lágmarksfallhæð sem veldur fallskaða
    public float maxFallDamage = 100f;     // Hámarks fallskaði (simulated heilsa)
    private float lastYPosition;           // Síðasta y-staðsetning til að reikna fall

    void Start()
    {
        // Nær í Rigidbody hlutinn á óvininum
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody fannst ekki á Ovinur GameObject.");
        }

        // Upphafsstillir síðustu y-staðsetningu
        lastYPosition = transform.position.y;
        Debug.Log("Ovinur er tilbúinn.");
    }

    void Update()
    {
        // Reiknar stefnu óvinarins í átt að leikmanninum
        Vector3 stefna = player.position - transform.position;
        stefna.Normalize(); // Normalíserar áttina (einingavektor)
        movement = stefna;

        // Snýr óvininum þannig að hann horfi á leikmanninn
        Quaternion lookRotation = Quaternion.LookRotation(stefna);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void FixedUpdate()
    {
        // Sér um hreyfingu óvinarins í átt að leikmanninum
        Hreyfing(movement);
    }

    void Hreyfing(Vector3 stefna)
    {
        // Hreyfir óvininn í átt að reiknaðri stefnu
        rb.MovePosition(transform.position + (stefna * hradi * Time.deltaTime));
    }

    // Meðhöndlar árekstra
    private void OnCollisionEnter(Collision collision)
    {
        // Athugar hvort óvinurinn lendir á jörðinni til að reikna fallskaða
        if (collision.collider.CompareTag("Ground"))
        {
            float fallDistance = lastYPosition - transform.position.y; // Reiknar fallhæð
            Debug.Log($"Fallhæð: {fallDistance}");

            // Athugar hvort fallhæð er meiri en viðmiðunarmörk
            if (fallDistance > fallDamageThreshold)
            {
                ApplyFallDamage(fallDistance); // Beitir fallskaða
            }

            // Uppfærir síðustu y-staðsetningu
            lastYPosition = transform.position.y;
        }

        // Athugar hvort óvinurinn rekst á leikmanninn
        if (collision.collider.name == "First Person Controller") // Athugar nafn leikmannsins
        {
            Debug.Log("Leikmaður fær í sig óvin");

            // Nær í Leikmaður scriptuna og kallar á TakeDamage
            Leikmaður leikmaðurScript = collision.collider.GetComponent<Leikmaður>();
            if (leikmaðurScript != null)
            {
                Debug.Log("Óvinur veldur skaða á leikmann...");
                leikmaðurScript.TakeDamage(10); // Dregur 10 af heilsu leikmanns
            }

            // Eyðir óvininum eftir árekstur við leikmann
            Debug.Log("Óvinur hverfur eftir árekstur við leikmann.");
            Destroy(gameObject);
        }
    }

    void ApplyFallDamage(float fallDistance)
    {
        // Reiknar fallskaða út frá fallhæð
        float damage = Mathf.Clamp(fallDistance * 10, 0, maxFallDamage);
        Debug.Log($"Óvinur varð fyrir {damage} fallskaða!");

        // Ef fallskaðinn er jafn eða meiri en hámark, deyr óvinurinn
        if (damage >= maxFallDamage)
        {
            Debug.Log("Fallskaði drap óvininn!");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Óvinur dó!");

        // Bætir stigum við leikmanninn
        Leikmaður leikmaðurScript = FindObjectOfType<Leikmaður>();
        if (leikmaðurScript != null)
        {
            leikmaðurScript.AddScore(10); // Bætir 10 stigum við leikmann
        }

        // Eyðir óvininum úr senunni
        Destroy(gameObject);
    }
}
