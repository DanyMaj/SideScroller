using UnityEngine;
using UnityEngine.LowLevel;

public class Stockage : Interactable
{
    public bool checkAccreditationCardLvl1;
    public Tool playerTool;
    public int accreditationCardLvl1;

    public bool CheckEvidence;
    public Evidence playerEvidence;
    public int evidenceNombre;
 
    public override void Interaction()
    {
        base.Interaction();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (checkAccreditationCardLvl1 == true)
            {
                playerTool.AddAccreditationCardLvl1(accreditationCardLvl1);
                print("Vous Avez Obtenu une carte d'accreditation");
                CheckEvidence = false;
            }

            if(CheckEvidence == true)
            {
                playerEvidence.AddEvidence(evidenceNombre);
                print($"Vous Avez Obtenu {evidenceNombre} Informations");
                CheckEvidence = false;
            }
            else
            {
                print("Ce Stockage est vide");
            }
        }

    }
}