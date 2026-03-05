using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float SpeedScroll;
    void Update()
    {
        transform.position = new Vector2(transform.position.x + SpeedScroll,transform.position.y);
    }

}