using UnityEngine;
using UnityEngine.SceneManagement;

public class Dammage : MonoBehaviour
{
    public HealthManager PlayerHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       var player = collision.GetComponent<HealthManager>();
       if (player != null)
        {
          SceneManager.LoadScene(0);
        }
    }
}
