using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public List<Tools> playerToolbox;
    public bool haveBackpack;
    public bool mySelection;
    public int maxInventory = 1;

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
    public void selection()
    {
        mySelection = playerToolbox.Count == 1;

        if(haveBackpack)        
        {
            if (Input.GetKey(KeyCode.A))
            {
                mySelection = playerToolbox.Count == 1;
                print("Vous avez sélectionné l'item 1");
            }
            if (Input.GetKey(KeyCode.R))
            {
                mySelection = playerToolbox.Count == 2;
                print("Vous avez sélectionné l'item 2");
            }
            if (Input.GetKey(KeyCode.F))
            {
                mySelection = playerToolbox.Count == 3;
                print("Vous avez sélectionné l'item 3");
            }
        }       
    }
}
