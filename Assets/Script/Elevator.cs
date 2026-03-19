using UnityEngine;

public class Elevator : Interactable
{
    public bool tpTop;
    public bool tpDown;

    public Transform ElevatorA;
    public Transform ElevatorC;


    public override void Interaction()
    {
        base.Interaction();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (tpTop == true)
            {
                player.transform.position = ElevatorA.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (tpDown == true)
            {
                player.transform.position = ElevatorC.position;
            }
        }


    }
}
