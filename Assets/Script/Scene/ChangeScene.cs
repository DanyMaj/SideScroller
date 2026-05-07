using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour

{
    public string sceneNameToLoad;

    public void changeScene()
    {
      SceneManager.LoadScene(sceneNameToLoad); //ça change de scène  
    }
}
