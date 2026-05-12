using UnityEngine;
using UnityEngine.LowLevel;

public class Medicament : Interactable
{
    public ToolManager playerMedicamentToolsManager;
    public BoxCollider2D MedicamentCollider;


    public Tools toolToCheckMedicament;
    public override void Interaction()
    {
        playerMedicamentToolsManager = player.GetComponent<ToolManager>();   

        if(playerMedicamentToolsManager.playerToolbox.Contains(toolToCheckMedicament) == true)
        {
            MedicamentIsTrigger();
            playerMedicamentToolsManager.playerToolbox.Remove(toolToCheckMedicament);
        }
    }

    public void MedicamentIsTrigger()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(208f, 255f, 179f, 163f);
        print($"Vous avec perdu {toolToCheckMedicament}");
    }
}