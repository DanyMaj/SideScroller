using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class Medicament : Interactable
{
    public ToolManager playerMedicamentToolsManager;
    public Tools toolToCheckMedicament;
    public MedicamentTexture ActiveTextur;
    public Light2D globalLight;
    public Collider2D MedicamentCollider;
    public GameObject Parent;
    private bool ouvert = false;
    private int slot;
    public float timer;

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
        if (!playerMedicamentToolsManager.haveBackpack)
        {
            if (playerMedicamentToolsManager.playerToolbox.Count == 1)
            {
                UiManager.instance.enplacement1Debut.sprite = UiManager.instance.square;
                UiManager.instance.enplacement1Debut.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
        }

        if (playerMedicamentToolsManager.haveBackpack)
        {
            slot = playerMedicamentToolsManager.playerToolbox.IndexOf(toolToCheckMedicament);

            if (slot == 0)
            {
                UiManager.instance.enplacement1.sprite = UiManager.instance.square;
                UiManager.instance.enplacement1.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
            if (slot == 1)
            {
                UiManager.instance.enplacement2.sprite = UiManager.instance.square;
                UiManager.instance.enplacement2.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
            if (slot == 2)
            {
                UiManager.instance.enplacement3.sprite = UiManager.instance.square;
                UiManager.instance.enplacement3.color = new Color(49f / 255f, 72f / 255f, 65f / 255f, 1f);
            }
        }
        ActiveTextur.StartDissolver();
        StartCoroutine(MedicamentEffect());
    }

    public IEnumerator MedicamentEffect()
    {
        Parent.SetActive(true);

        globalLight.color = new Color(72f / 255f, 0f, 0f, 1f);

        yield return new WaitForSeconds(10f);

        Parent.SetActive(false);

        globalLight.color = new Color(75f / 255f, 75f / 255f, 75f / 255f);
    }
}