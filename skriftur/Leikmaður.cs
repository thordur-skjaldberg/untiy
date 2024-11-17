using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Nauðsynlegt til að skipta um senu

public class Leikmaður : MonoBehaviour
{
    public int health = 100; // Byrjunarheilsa leikmanns
    public TextMeshProUGUI healthText; // Texti til að sýna heilsu leikmanns
    public TextMeshProUGUI scoreText; // Texti til að sýna stig leikmanns
    private int score = 0; // Stigaleikmaðurinn hefur safnað
    public AudioClip deathSound; // Hljóð sem spilar þegar leikmaður deyr
    private AudioSource audioSource; // Tilvísun í AudioSource

    void Start()
    {
        UpdateHealthText(); // Uppfærir heilsutextann í byrjun
        UpdateScoreText();  // Uppfærir stigatöflu í byrjun

        // Sækir eða býr til AudioSource fyrir hljóðspilun
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Fall sem tekur af heilsu leikmannsins
    public void TakeDamage(int damage)
    {
        health -= damage; // Dregur frá heilsu leikmanns
        UpdateHealthText(); // Uppfærir heilsutextann
        
        // Athugar ef heilsa er 0 eða minna
        if (health <= 0)
        {
            Die(); // Kallar á dauðafallið ef leikmaður hefur enga heilsu
        }
    }

    // Uppfærir heilsutextann
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Heilsa: " + health.ToString();
        }
    }

    // Uppfærir stigatöflu texta
    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Stig: " + score.ToString();
        }
    }

    // Fall sem keyrist þegar leikmaður deyr
    private void Die()
    {
        Debug.Log("Leikmaður hefur dáið");

        // Spilar hljóðið ef deathSound er til staðar
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound); // Spilar dauðahljóðið
        }

        // Biður um smá töf til að leyfa hljóðinu að spila áður en senan skiptist
        Invoke("LoadDeathScene", deathSound.length);
    }

    // Hleður inn "Dóst" senunni eftir töf
    private void LoadDeathScene()
    {
        SceneManager.LoadScene("Dóst");
    }

    // Fall sem bætir við stigum
    public void AddScore(int points)
    {
        score += points; // Bætir stigum við
        UpdateScoreText(); // Uppfærir stigatöflu
    }

    // Fall sem bætir heilsu við leikmanninn
    public void AddHealth(int healthAmount)
    {
        health += healthAmount;  // Bætir heilsu við leikmann
        UpdateHealthText();  // Uppfærir heilsutextann
    }
}
