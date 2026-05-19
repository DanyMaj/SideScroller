using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class Door : Interactable
{
    public ToolManager playerToolsManager;
    public Tools toolToCheck;
    public BoxCollider2D doorCollider;
    private int slot;

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
        if (!playerToolsManager.haveBackpack)
        {
            if (playerToolsManager.playerToolbox.Count == 1)
            {
                UiManager.instance.enplacement1Debut.sprite = Square.sprite;
                UiManager.instance.enplacement1Debut.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
        }

        if (playerToolsManager.haveBackpack)
        {
            slot = playerToolsManager.playerToolbox.IndexOf(toolToCheck);

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
        playerToolsManager.playerToolbox.Remove(toolToCheck);
        GetComponent<SpriteRenderer>().material.color = new Color(208f, 255f, 179f, 163f);
        doorCollider.enabled = false;
        print($"Vous avec perdu {toolToCheck}");
    }
}