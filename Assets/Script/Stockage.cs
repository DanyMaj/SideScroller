using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

[System.Serializable]
public class Tool1
{
    public string name;
    public bool isValid;
}

public class Stockage : Interactable
{
    public bool checkAccreditationCardLvl1;
    public Tool playerTool;
    public int accreditationCardLvl1;

    public bool CheckEvidence;
    public Evidence playerEvidence;
    public int evidenceNombre;
    public int openingNumber;

    public List<Tool1> theTool;
    public int numberTools = 0;
    [SerializeField]
    public override void Interaction()
    {
        foreach (var item in theTool) 
        {
            
            
                base.Interaction();
                print($"{openingNumber}");

                if (item.isValid == true)
                {
                    if (numberTools < 1)
                    {
                        openingNumber += 1;

                        numberTools += 1;
                        print($"Vous Avez Obtenu{item.name}");
                    }
                } 
                if (openingNumber != 1)
                {
                    print("Ce Stockage est vide");
                }
            
        }
    }
}
