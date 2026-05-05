using UnityEngine;

[System.Serializable]
public struct boolName
{
    public string objectName;
    public bool valeur;
}

public class ToolsOnPlayer : MonoBehaviour
{
    
    public boolName[] tools = new boolName[8];

    public void Start()
    {
        tools[0].valeur = false;
    }
}