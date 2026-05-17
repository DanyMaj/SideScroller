using System.Collections.Generic;

[System.Serializable]
public class ToolsSpawn : Interactable
{
    public ToolManager toolManagerPlayer;
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
                gameObject.SetActive(false);
                print($"Vous avez obtenu {item}");
            }
        }
    }
}
