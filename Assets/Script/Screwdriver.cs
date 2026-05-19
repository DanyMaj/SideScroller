using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.Splines.ExtrusionShapes;

public class Screwdriver : Interactable
{
    public ToolManager playerScrewdriverManager;
    public BoxCollider2D screwdriverCollider;
    public Tools toolToCheck;
    public Transform playerPosition;
    public Transform TpScrewdriverPlayer;
    public Transform TpScrewdriverCamera;
    public Transform cameraView;
    private int slot;
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
        if (!playerScrewdriverManager.haveBackpack)
        {
            if (playerScrewdriverManager.playerToolbox.Count == 1)
            {
                UiManager.instance.enplacement1Debut.sprite = Square.sprite;
                UiManager.instance.enplacement1Debut.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
        }

        if (playerScrewdriverManager.haveBackpack)
        {
            slot = playerScrewdriverManager.playerToolbox.IndexOf(toolToCheck);

            if (slot == 0)
            {
                UiManager.instance.enplacement1.sprite = Square.sprite;
                UiManager.instance.enplacement1.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
            if (slot == 1)
            {
                UiManager.instance.enplacement2.sprite = Square.sprite;
                UiManager.instance.enplacement2.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
            if (slot == 2)
            {
                UiManager.instance.enplacement3.sprite = Square.sprite;
                UiManager.instance.enplacement3.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
        }
        playerPosition.position = TpScrewdriverPlayer.position;
        cameraView.position = TpScrewdriverCamera.position;
        cameraView.gameObject.GetComponent<CameraMove>().enabled = false;
 
        print($"Vous avec perdu {toolToCheck}");
    }
}