using UnityEngine;

public class PopsInteraction : MonoBehaviour
{
    public GameObject sr;

    private void Start()
    {
        sr.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement_01>() != null)
        {
            sr.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement_01>() != null)
        {
            sr.SetActive(false);
        }
    }
}
