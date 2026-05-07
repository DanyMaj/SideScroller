using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;


[System.Serializable]
public class StokageV2 : Interactable
{
    public ToolManager playerToolManager;
    public bool CheckEvidence;
    public EvidenceManager playerEvidence;
    public int evidenceNombre;
    public bool isOpen;

    public List<Tools> theTool;


    public override void Interaction()
    {
        playerToolManager = player.GetComponent<ToolManager>();
        OpenStockage();
    }

    private void OpenStockage()
    {
        if (isOpen == false)
        {
            isOpen = true;

            foreach (var item in theTool)
            {
                if(playerToolManager.AddToolToToolbox(item))
                {
                    if (item)
                    {
                        print($"Vous avec obtenue {item}");
                    }
                }
                else
                {

                }
            }
            if (CheckEvidence) 
            {
                playerEvidence.AddEvidence(evidenceNombre);
            }
        }
        else
        {
            print("Ce Stockage est vide");
        }
    }
}
