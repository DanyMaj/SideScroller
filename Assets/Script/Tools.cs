using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tools", order = 1)]
public class Tools : ScriptableObject
{
    public GameObject toolsGameObject;
    public Sprite spriteTool;
    public bool validRegion;
    public string name;
    public string ID;
}