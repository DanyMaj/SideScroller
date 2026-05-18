using UnityEngine;
using UnityEngine.LowLevel;

public class Door : Interactable
{
    public ToolManager playerToolsManager;
    public BoxCollider2D doorCollider;


    public Tools toolToCheck;
    public override void Interaction()
    {
        playerToolsManager = player.GetComponent<ToolManager>();   

        if(playerToolsManager.playerToolbox.Contains(toolToCheck) == true)
        {
            DoorOpen();
        }
    }

    public void DoorOpen()
    {
        playerToolsManager.playerToolbox.Remove(toolToCheck);
        GetComponent<SpriteRenderer>().material.color = new Color(208f, 255f, 179f, 163f);
        doorCollider.enabled = false;
        print($"Vous avec perdu {toolToCheck}");
    }
}