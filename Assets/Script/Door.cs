using UnityEngine;
using UnityEngine.LowLevel;

public class Door : Interactable
{
    public Tool tools;
    public BoxCollider2D doorCollider;


    public override void Interaction()
    {
        base.Interaction();
        if (tools.numberAccreditationCardLvl1 > 0)
        { 
            tools.AddAccreditationCardLvl1(-1);
            DoorOpen();
            print("La Porte Est Ouverte");
        }
    }

    public void DoorOpen()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(208f, 255f, 179f, 163f);
        doorCollider.enabled = false;
    }
}