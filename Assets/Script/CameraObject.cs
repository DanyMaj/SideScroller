using UnityEngine;

public class CameraObject : MonoBehaviour

{
    public CameraMove mainCamera;
    public float timer;
    public bool playerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement_01>();

        if (player != null)
        {
            mainCamera.SpeedScroll *= 3;
            playerDetected = true;
        }
    }
    private void Update()
    {
        if (playerDetected)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 5)
        {
            timer = 0;
            playerDetected = false;
            mainCamera.SpeedScroll /= 3;
        }
    }
}
