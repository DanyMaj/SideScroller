using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public Tools selectedTool;
    public List<Tools> playerToolbox;
    public bool haveBackpack;
    public int selectedSlot = 0;
    public int maxInventory = 1;

    private void Update()
    {
        Selection();
    }

    public bool AddToolToToolbox(Tools toolToAdd)
    {
        if (playerToolbox.Count < maxInventory)
        {
            playerToolbox.Add(toolToAdd);

            // Sélection automatique du premier item
            if (playerToolbox.Count == 1)
            {
                selectedSlot = 0;
                selectedTool = playerToolbox[0];
            }

            return true;
        }

        return false;
    }

    public void Selection()
    {
        // Sans sac à dos = toujours slot 1
        if (!haveBackpack)
        {
            if (playerToolbox.Count > 0)
            {
                selectedSlot = 0;
                selectedTool = playerToolbox[0];
            }

            return;
        }

        // Slot 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (playerToolbox.Count >= 1)
            {
                selectedSlot = 0;
                selectedTool = playerToolbox[0];

                print("Objet sélectionné : " + selectedTool.name);
            }
        }

        // Slot 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerToolbox.Count >= 2)
            {
                selectedSlot = 1;
                selectedTool = playerToolbox[1];

                print("Objet sélectionné : " + selectedTool.name);
            }
        }

        // Slot 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerToolbox.Count >= 3)
            {
                selectedSlot = 2;
                selectedTool = playerToolbox[2];

                print("Objet sélectionné : " + selectedTool.name);
            }
        }
    }
}