using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class ToolsSpawn : Interactable
{
    public ToolManager toolManagerPlayer;
    public List<Tools> theTool;
    public CameraObject theCameraObject;
    public portiqueDeSécurité theSecurityGate;

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
                if (item.ID == "BP1" && toolManagerPlayer.haveBackpack)
                {
                    print("Vous avez déjà un sac à dos");
                    return;
                }
                Tools oldTool = toolManagerPlayer.playerToolbox[toolManagerPlayer.selectedSlot];

                if (oldTool.ID == "BP1")
                {
                    toolManagerPlayer.haveBackpack = false;

                    // Sauvegarde des items du sac
                    toolManagerPlayer.backpackStorage.Clear();

                    if (toolManagerPlayer.playerToolbox.Count > 1)
                    {
                        toolManagerPlayer.backpackStorage.Add(toolManagerPlayer.playerToolbox[1]);
                    }

                    if (toolManagerPlayer.playerToolbox.Count > 2)
                    {
                        toolManagerPlayer.backpackStorage.Add(toolManagerPlayer.playerToolbox[2]);
                    }

                    // Supprime les slots 2 et 3
                    if (toolManagerPlayer.playerToolbox.Count > 2)
                    {
                        toolManagerPlayer.playerToolbox.RemoveAt(2);
                    }

                    if (toolManagerPlayer.playerToolbox.Count > 1)
                    {
                        toolManagerPlayer.playerToolbox.RemoveAt(1);
                    }

                    toolManagerPlayer.maxInventory = 1;

                    UiManager.instance.unePlace.SetActive(true);
                    UiManager.instance.troisPlaces.SetActive(false);

                    print("Sac retiré");
                }

                // Le joueur prend le nouvel objet
                toolManagerPlayer.playerToolbox[toolManagerPlayer.selectedSlot] = item;

                if (item.ID == "BP1")
                {
                    toolManagerPlayer.haveBackpack = true;

                    toolManagerPlayer.maxInventory = 3;

                    UiManager.instance.unePlace.SetActive(false);
                    UiManager.instance.troisPlaces.SetActive(true);

                    // Restaurer les objets du sac
                    foreach (Tools storedTool in toolManagerPlayer.backpackStorage)
                    {
                        if (toolManagerPlayer.playerToolbox.Count < toolManagerPlayer.maxInventory)
                        {
                            toolManagerPlayer.playerToolbox.Add(storedTool);
                        }
                    }

                    toolManagerPlayer.backpackStorage.Clear();

                    print("Sac récupéré");
                }

                // Le casier récupère l'ancien objet
                theTool[i] = oldTool;

                // Change le sprite au sol
                GetComponent<SpriteRenderer>().sprite = oldTool.spriteTool;

                // Met à jour l'objet sélectionné
                toolManagerPlayer.selectedTool = item;

                if (!toolManagerPlayer.haveBackpack)
                {
                    if (toolManagerPlayer.playerToolbox.Count == 1)
                    {
                        UiManager.instance.enplacement1Debut.sprite = item.spriteTool;
                        UiManager.instance.enplacement1Debut.color = Color.white;
                    }
                }

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
                return;
            }

            if (toolManagerPlayer.playerToolbox.Count == 0 && item.ID == "PC1" && Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(DisableDetection());
            }

            if (toolManagerPlayer.playerToolbox.Count == 1 && item.ID == "PC1" && Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(DisableDetection());
            }

            if (toolManagerPlayer.playerToolbox.Count == 2 && item.ID == "PC1" && Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(DisableDetection());
            }

            if (item.ID == "BP1" && toolManagerPlayer.haveBackpack)
            {
                print("Vous avez déjà un sac à dos");
                return;
            }

            if (toolManagerPlayer.AddToolToToolbox(item))
            {

                print($"Vous avez obtenu {item}");

                if (item.ID == "BP1")
                {
                    toolManagerPlayer.haveBackpack = true;

                    toolManagerPlayer.maxInventory = 3;

                    UiManager.instance.unePlace.SetActive(false);
                    UiManager.instance.troisPlaces.SetActive(true);

                    // Restaure les anciens objets
                    foreach (Tools storedTool in toolManagerPlayer.backpackStorage)
                    {
                        if (toolManagerPlayer.playerToolbox.Count < toolManagerPlayer.maxInventory)
                        {
                            toolManagerPlayer.playerToolbox.Add(storedTool);
                        }
                    }

                    toolManagerPlayer.backpackStorage.Clear();
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
    IEnumerator DisableDetection()
    {
        theCameraObject.canDetectPlayer = false;
        theSecurityGate.canDetectPlayer = false;

        print("Les système de sécurité son désactiver");

        yield return new WaitForSeconds(20f);

        theCameraObject.canDetectPlayer = true;
        theSecurityGate.canDetectPlayer = true;

        print("Les système de sécurité son réactivée");
    }
}
