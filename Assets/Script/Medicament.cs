using UnityEngine;

public class Medicament : Interactable
{
    public ToolManager playerMedicamentToolsManager;
    public Collider2D MedicamentCollider;
    public Tools toolToCheckMedicament;
    public MedicamentTexture ActiveTextur;
    public GameObject Parent;
    public GameObject GlobalLight;
    private bool ouvert = false;

    public float dissolveDuration = 2;
    public float dissolveStrength;

    public override void Interaction()
    {
        if (ouvert) return;
        playerMedicamentToolsManager = player.GetComponent<ToolManager>();

        if (playerMedicamentToolsManager.playerToolbox.Contains(toolToCheckMedicament))
        {
            ouvert = true;
            MedicamentIsTrigger();
            playerMedicamentToolsManager.playerToolbox.Remove(toolToCheckMedicament);
        }
    }

    public void MedicamentIsTrigger()
    {
        ActiveTextur.StartDissolver();
        Parent.SetActive(true);
        //GlobalLight.GetComponent<Light2D>().color = Color.red;
        
    }
}