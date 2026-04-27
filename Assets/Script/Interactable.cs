using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractionManager player;
    /// <summary>
    /// public GameObject gInteractable;
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///gInteractable = collision.gameObject;
        player = collision.GetComponent<InteractionManager>();
        if (player != null)
        {
            player.currentInteractable = this;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ///gInteractable = null;
        player = collision.GetComponent<InteractionManager>();
        if (player != null)
        {
            if (player.currentInteractable == this)
            {
                player.currentInteractable = null;
            }
        }
    }


    public virtual void Interaction()
    {
    
    }
   
}
