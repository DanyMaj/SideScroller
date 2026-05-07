using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class CameraMove : MonoBehaviour
{
    public float SpeedScroll;
    public float timer;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3) 
        {  
            transform.position = new Vector2(transform.position.x + SpeedScroll,transform.position.y);
        }
    }

}