using System.Collections.Generic;


public class Backpack : Interactable
{
    public ToolManager toolManager;
    public List<Tools> theTool;
    public UiManager UiManager;
    public bool haveBackpack = false;

    public override void Interaction()
    {
        print(player);
        toolManager = player.GetComponent<ToolManager>();
        IHaveBackpack();
    }

    public void IHaveBackpack()
    {
        haveBackpack = true;

        foreach (var item in theTool)
        {
            if (toolManager.playerToolbox.Count >= toolManager.maxInventory)
            {
                print("Inventaire plein");
                return;
            }

            if (toolManager.AddToolToToolbox(item))
            {
                gameObject.SetActive(false);
                print($"Vous avez obtenu {item}");
            }
        }

        if (haveBackpack)
        {
            UiManager.instance.unePlace.SetActive(false);
            UiManager.instance.troisPlaces.SetActive(true);
            toolManager.maxInventory = 3;
        }

        else
        {
            UiManager.instance.unePlace.SetActive(true);
            UiManager.instance.troisPlaces.SetActive(false);
            toolManager.maxInventory = 1;
        }
    }
}
