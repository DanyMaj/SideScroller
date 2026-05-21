using System.Collections.Generic;
using UnityEngine;

public class portiqueDeSécurité : MonoBehaviour

{
    public CameraMove mainCamera;
    public ToolManager playerToolsManager;
    public List<Tools> toolToCheck;
    public float timer;
    private bool playerDetected;
    public bool canDetectPlayer = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement_01>();

        if (player != null)
        {
            if (canDetectPlayer)
            {
                canDetectPlayer = false;

                foreach (Tools tool in toolToCheck)
                {
                    if (playerToolsManager.playerToolbox.Contains(tool))
                    {
                        mainCamera.SpeedScroll *= 3;
                        playerDetected = true;

                        Debug.Log("Objet interdit détecté : " + tool.name);

                        break;
                    }
                }
            }
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
            canDetectPlayer = true;
            playerDetected = false;
            mainCamera.SpeedScroll /= 3;
        }
    }
}
