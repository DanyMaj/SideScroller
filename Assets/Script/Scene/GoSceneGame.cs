using UnityEngine;
using UnityEngine.SceneManagement;

public class GoSceneGame : MonoBehaviour
{
    private bool playerIsTrigger;
    public string sceneNameToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement_01>();
        if (player != null)
        {
            playerIsTrigger = true;
            SceneManager.LoadScene(sceneNameToLoad); //ça change de scène  
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement_01>();
        if (player != null)
        {
            playerIsTrigger = false;
        }
    }
    public void Update()
    {
        if (playerIsTrigger == true)
        {
            //Debug.Log("Je suis l1");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Je suis e");
                OpenStockage();
            }
        }
    }
    private void OpenStockage()
    {
        SceneManager.LoadScene(sceneNameToLoad); //ça change de scène  
    }
}
