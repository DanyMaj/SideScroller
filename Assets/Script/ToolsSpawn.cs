using System.Collections.Generic;

[System.Serializable]
public class ToolsSpawn : Interactable
{
    public ToolManager toolManagerPlayer;
    public Tools toolsObject;
    public Backpack backpackRef;
    public List<Tools> theTool;
    public override void Interaction()
    {
        toolManagerPlayer = player.GetComponent<ToolManager>();
        RetrieveTools();
    }

    public void RetrieveTools()
    {
        foreach (var item in theTool)
        {
            if (toolManagerPlayer.playerToolbox.Count >= toolManagerPlayer.maxInventory)
            {
                print("Inventaire plein");
                return;
            }

            if (toolManagerPlayer.AddToolToToolbox(item))
            {
                //gameObject.SetActive(false);

                print(UiManager.instance);

                print(UiManager.instance.enplacement1.sprite);

                if (backpackRef.haveBackpack == false) 
                {
                    if (toolManagerPlayer.playerToolbox.Count == 1)
                    {
                        UiManager.instance.enplacement1Debut.sprite = item.spriteTool;
                    }
                }

                if (backpackRef.haveBackpack)
                {
                    if (toolManagerPlayer.playerToolbox.Count == 1)
                    {
                        UiManager.instance.enplacement1.sprite = item.spriteTool;
                    }
                    if (toolManagerPlayer.playerToolbox.Count == 2)
                    {
                        UiManager.instance.enplacement2.sprite = item.spriteTool;
                    }
                    if (toolManagerPlayer.playerToolbox.Count == 3)
                    {
                        UiManager.instance.enplacement3.sprite = item.spriteTool;
                    }
                }
                print($"Vous avez obtenu {item}");
            }
        }
    }
}
