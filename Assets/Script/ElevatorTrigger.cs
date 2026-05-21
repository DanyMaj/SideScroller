using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite elevatorOuvert;
    public Sprite elevatorFerme;
    public bool IMaElevator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement_01>() != null && IMaElevator)
        {
            sr.sprite = elevatorOuvert;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement_01>() != null && IMaElevator)
        {
            sr.sprite = elevatorFerme;
        }
    }
}