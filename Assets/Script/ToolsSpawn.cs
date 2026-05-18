using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class ToolsSpawn : Interactable
{
    public ToolManager toolManagerPlayer;
    public Tools toolsObject;
    public List<Tools> theTool;
    
    public override void Interaction()
    {
        toolManagerPlayer = player.GetComponent<ToolManager>();
        RetrieveTools();
    }

    public void RetrieveTools()
    {
        for (int i = 0; i < theTool.Count; i++)
        {
            Tools item = theTool[i];
            if (toolManagerPlayer.playerToolbox.Count >= toolManagerPlayer.maxInventory)
            {
                Tools oldTool = toolManagerPlayer.playerToolbox[toolManagerPlayer.selectedSlot];

                // Le joueur prend le nouvel objet
                toolManagerPlayer.playerToolbox[toolManagerPlayer.selectedSlot] = item;

                // Le casier récupère l'ancien objet
                theTool[i] = oldTool;

                // Change le sprite au sol
                GetComponent<SpriteRenderer>().sprite = oldTool.spriteTool;

                // Met à jour l'objet sélectionné
                toolManagerPlayer.selectedTool = item;

                if (toolManagerPlayer.selectedSlot == 0)
                {
                    UiManager.instance.enplacement1.sprite = item.spriteTool;
                    UiManager.instance.enplacement1.color = Color.white;
                }
                if (toolManagerPlayer.selectedSlot == 1)
                {
                    UiManager.instance.enplacement2.sprite = item.spriteTool;
                    UiManager.instance.enplacement2.color = Color.white;
                }
                if (toolManagerPlayer.selectedSlot == 2)
                {
                    UiManager.instance.enplacement3.sprite = item.spriteTool;
                    UiManager.instance.enplacement3.color = Color.white;
                }
                print("Inventaire plein");
                return;
            }

            if (toolManagerPlayer.AddToolToToolbox(item))
            {

                print($"Vous avez obtenu {item}");
                print("l'ID de l'objet est : " + item.ID);

                if (item.ID == "BP1")
                {
                    toolManagerPlayer.haveBackpack = true;
                    print("Backpack détecté");
                }

                if (!toolManagerPlayer.haveBackpack)
                {
                    if (toolManagerPlayer.playerToolbox.Count == 1)
                    {
                        UiManager.instance.enplacement1Debut.sprite = item.spriteTool;
                        UiManager.instance.enplacement1Debut.color = Color.white;
                    }
                }

                if (toolManagerPlayer.haveBackpack)
                {
                    if (toolManagerPlayer.playerToolbox.Count == 1)
                    {
                        UiManager.instance.enplacement1.sprite = item.spriteTool;
                        UiManager.instance.enplacement1.color = Color.white;
                    }
                    if (toolManagerPlayer.playerToolbox.Count == 2)
                    {
                        UiManager.instance.enplacement2.sprite = item.spriteTool;
                        UiManager.instance.enplacement2.color = Color.white;
                    }
                    if (toolManagerPlayer.playerToolbox.Count == 3)
                    {
                        UiManager.instance.enplacement3.sprite = item.spriteTool;
                        UiManager.instance.enplacement3.color = Color.white;
                    }
                } 


                if (toolManagerPlayer.haveBackpack)
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

                gameObject.SetActive(false);
            }
        }
    }
}
