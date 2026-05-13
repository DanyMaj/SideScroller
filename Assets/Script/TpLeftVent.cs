using UnityEngine;
using UnityEngine.SceneManagement;

public class TpLeftVent : MonoBehaviour
{
    public BoxCollider2D TpCollider;
    public Transform playerPosition;
    public Transform cameraView;
    public Transform TpLocale;
    public Transform TpLocalePlayer;
    public float timer;
    private bool playerIsTp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement_01>();
        if (player != null)
        {
            playerPosition.position = TpLocalePlayer.position;
            cameraView.position = TpLocale.position;
            playerIsTp = true;
        }
    }

    void Update()
    {

        if (playerIsTp)
        {
            timer += Time.deltaTime;

            if (timer > 3)
            {
                cameraView.gameObject.GetComponent<CameraMove>().enabled = true;
            }
        }
    }  
}
