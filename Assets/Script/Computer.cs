using UnityEngine;
using System.Collections;


public class Computer : MonoBehaviour
{
    public ToolManager toolManager;

    public CameraObject theCameraObject;
    public portiqueDeSécurité theSecurityGate;

    private bool canUsePC = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && canUsePC)
        {
            CheckPC();
        }
    }

    void CheckPC()
    {
        // Vérifie qu'un objet est sélectionné
        if (toolManager.selectedTool != null)
        {
            print("un sélectionné");
            // Vérifie si c'est le PC
            if (toolManager.selectedTool.ID == "PC1")
            {
                print("le PC est sélectionné");
                StartCoroutine(DisableDetection());
            }
        }
    }

    IEnumerator DisableDetection()
    {
        canUsePC = false;

        theCameraObject.canDetectPlayer = false;
        theSecurityGate.canDetectPlayer = false;

        print("Systèmes de sécurité désactivés");

        yield return new WaitForSeconds(20f);

        theCameraObject.canDetectPlayer = true;
        theSecurityGate.canDetectPlayer = true;

        print("Systèmes de sécurité réactivés");

        canUsePC = true;
    }
}