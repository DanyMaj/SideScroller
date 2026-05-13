using UnityEngine;
using UnityEngine.LowLevel;

public class Screwdriver : Interactable
{
    public ToolManager playerScrewdriverManager;
    public BoxCollider2D screwdriverCollider;
    public Tools toolToCheck;
    public Transform playerPosition;
    public Transform TpScrewdriverPlayer;
    public Transform TpScrewdriverCamera;
    public Transform cameraView;
    public override void Interaction()
    {
        playerScrewdriverManager = player.GetComponent<ToolManager>();   

        if(playerScrewdriverManager.playerToolbox.Contains(toolToCheck) == true)
        {
            ScrewdriverIsTrigger();
            playerScrewdriverManager.playerToolbox.Remove(toolToCheck);
        }
    }

    public void ScrewdriverIsTrigger()
    {
        playerPosition.position = TpScrewdriverPlayer.position;
        cameraView.position = TpScrewdriverCamera.position;

        print($"Vous avec perdu {toolToCheck}");
        cameraView.gameObject.GetComponent<CameraMove>().enabled = false;
    }
}