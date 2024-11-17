using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{
    public string sceneName = "leikurinn"; // Settu þetta sem nafn á senunni sem þú vilt fara í

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Vertu viss um að þetta fall sé skilgreint sem "public"
    public void Byrja()
    {
        Debug.Log("Byrja method called"); // Þetta birtir skilaboð í Console til að staðfesta að fallið er kallað
        SceneManager.LoadScene(sceneName); // Hleður inn senunni með nafninu sceneName
    }
}
