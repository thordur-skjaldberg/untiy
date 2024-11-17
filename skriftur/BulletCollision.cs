using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Athugar hvort skotkúlan rekst á óvin með tagið "Ovinur"
        if (collision.collider.CompareTag("Ovinur"))
        {
            Debug.Log("Óvinur varð fyrir skoti!");

            // Nær í "Ovinur" scriptuna frá hlutnum sem varð fyrir árekstri
            Ovinur ovinur = collision.collider.GetComponent<Ovinur>();
            if (ovinur != null)
            {
                ovinur.Die(); // Kallar beint á Die fallið til að eyða óvininum
            }

            // Eyðir skotkúlunni sjálfri eftir að hún rekst á óvin
            Destroy(gameObject);
        }
    }
}
