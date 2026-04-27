using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Stockage VariableStockage;
    public Interactable currentInteractable;
    void Update()
    {
        if (currentInteractable != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && currentInteractable.gameObject.tag == "stockage")
            {
                Debug.Log("poupette");
                currentInteractable.Interaction();
            }


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentInteractable.Interaction();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentInteractable.Interaction();
            }
        }
    }

    void canInteract(GameObject interactable)
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable.tag == "stockage")
        {
            currentInteractable.Interaction();
        }

    }

}
