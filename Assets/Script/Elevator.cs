using UnityEngine;

public class Elevator : Interactable
{
    public PlayerMovement_01 isPlayer;
    public Transform ElevatorA;
    public Transform ElevatorC;
    public bool tpTop;
    public bool tpDown;

    public override void Interaction()
    {

        isPlayer = player.GetComponent<PlayerMovement_01>();
        base.Interaction();

        if (pressedKc == KeyCode.UpArrow && tpTop)
        {
            player.transform.position = ElevatorA.position;
        }

        if (pressedKc == KeyCode.DownArrow && tpDown)
        {
            player.transform.position = ElevatorC.position;
        }
    }
}
