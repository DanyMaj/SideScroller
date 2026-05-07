using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public List<Tools> playerToolbox;
    public int maxInventory = 3;

    public bool AddToolToToolbox(Tools toolToAdd)
    {
        if(playerToolbox.Count < maxInventory)
        {
            playerToolbox.Add(toolToAdd);   
            return true;
        }
        return false;
    }
    public void Inventory()
    {
    }

}
