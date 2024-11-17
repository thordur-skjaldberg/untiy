using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;  // Prefab fyrir skotkúlu
    public float speed = 4000f;  // Hraði skotkúlunnar
    public Transform player;  // Transform leikmannsins
    public Vector3 offset = new Vector3(0f, 0f, 1f);  // Staðsetning byssunnar miðað við leikmanninn

    void Update()
    {
        // Stillir staðsetningu og snúning byssunnar miðað við leikmanninn
        if (player != null)
        {
            transform.position = player.position + player.TransformDirection(offset); // Staðsetning byssunnar miðað við leikmann
            transform.rotation = player.rotation; // Snúningur byssunnar fylgir leikmanninum
        }

        // Athugar hvort "Z" takkanum er ýtt á til að skjóta
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Skýt!");

            // Reiknar staðsetningu þar sem skotkúlan byrjar (örlítið fyrir framan byssuna)
            Vector3 spawnPosition = transform.position + transform.forward * 0.5f; // 0.5f til að forðast árekstur við byssuna

            // Býr til skotkúlu á reiknaðri staðsetningu
            GameObject instBullet = Instantiate(bullet, spawnPosition, transform.rotation);

            // Bætir krafti á skotkúluna til að hún hreyfist fram
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * speed);

            // Eyðir skotkúlunni eftir ákveðinn tíma til að koma í veg fyrir uppsöfnun
            Destroy(instBullet, 2f); // Eyðir skotkúlunni eftir 2 sekúndur
        }
    }
}
