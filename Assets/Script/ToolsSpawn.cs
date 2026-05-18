using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ToolsSpawn : Interactable
{
    public ToolManager toolManagerPlayer;
    public Tools toolsObject;
    public PlayerHaveBacpak backpackPlayerRef;
    public List<Tools> theTool;
    public bool haveBackpack = false;
    public override void Interaction()
    {
        toolManagerPlayer = player.GetComponent<ToolManager>();
        RetrieveTools();
    }

    public void RetrieveTools()
    {
        foreach (var item in theTool)
        {
            if (toolManagerPlayer.playerToolbox.Count >= toolManagerPlayer.maxInventory)
            {
                print("Inventaire plein");
                return;
            }

            if (toolManagerPlayer.AddToolToToolbox(item))
            {
                //gameObject.SetActive(false);

                print($"Vous avez obtenu {item}");

                if (item.ID == "BP1")
                {
                    haveBackpack = true;
                }

                if (!haveBackpack)
                {
                    if (toolManagerPlayer.playerToolbox.Count == 1)
                    {
                        UiManager.instance.enplacement1Debut.sprite = item.spriteTool;
                        UiManager.instance.enplacement1Debut.color = Color.white;
                    }
                }

                if (haveBackpack)
                {
                    if (backpackPlayerRef.refToBackpack.haveBackpack)
                    {
                        if (toolManagerPlayer.playerToolbox.Count == 1)
                        {
                            UiManager.instance.enplacement1.sprite = item.spriteTool;
                        }
                        if (toolManagerPlayer.playerToolbox.Count == 2)
                        {
                            UiManager.instance.enplacement2.sprite = item.spriteTool;
                        }
                        if (toolManagerPlayer.playerToolbox.Count == 3)
                        {
                            UiManager.instance.enplacement3.sprite = item.spriteTool;
                        }
                    }
                } 


                if (haveBackpack)
                {
                    UiManager.instance.unePlace.SetActive(false);
                    UiManager.instance.troisPlaces.SetActive(true);
                    toolManagerPlayer.maxInventory = 3;
                }

                else
                {
                    UiManager.instance.unePlace.SetActive(true);
                    UiManager.instance.troisPlaces.SetActive(false);
                    toolManagerPlayer.maxInventory = 1;
                }
            }
        }
    }
}
