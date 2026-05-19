

using UnityEngine;

public class CameraMouveVercticaleDown : Interactable
{
    public PlayerMovement_01 isPlayer;
    public Transform ViewCamera;
    public Transform ElevatorA;
    public Transform ElevatorC;
    public bool tpTop;
    public bool tpDown;

    public override void Interaction()
    {
        isPlayer = player.GetComponent<PlayerMovement_01>();

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
                ViewCamera.transform.position = ViewCamera.transform.position + new Vector3(0, -12, 0);
            }
        }
    }
}