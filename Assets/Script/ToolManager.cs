using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public List<Tools> playerToolbox;
    public int numberScrewdriver;
    public int screwdriver;
    public int numberAccreditationCardLvl1 ;
    public int AccreditationCardLvl1;

    public void AddToolToToolbox()
    {

    }
    public void Inventory()
    {
    }

    public void Addscrewdriver(int screwdriver)
    {
        numberScrewdriver += screwdriver;
    }
    public void AddAccreditationCardLvl1(int AccreditationCardLvl1)
    {
        numberAccreditationCardLvl1 += AccreditationCardLvl1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
