using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StokageV2 : Interactable
{
    public ToolManager playerToolManager;
    public bool CheckEvidence;
    public EvidenceManager playerEvidence;
    public int evidenceNombre = 1;
    public bool isOpen;
    public bool Casier;
    public Sprite bureauOuvert;
    public Sprite CasierOuvert;
    private SpriteRenderer sr;
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

            if (Casier)
            {
                //pour le casier
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = CasierOuvert;
            }
            if (!Casier)
            {
                //pour le bureau
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = bureauOuvert;
            }

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
