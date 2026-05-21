using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    //public Stockage VariableStockage;
    public Interactable currentInteractable;
    void Update()
    {
        if (currentInteractable != null)
        {
            foreach (KeyCode key in currentInteractable.keyToPress)
            {
                if (Input.GetKeyDown(key))
                {
                    currentInteractable.Pressed(key);   
                    currentInteractable.Interaction();
                    currentInteractable?.Pressed(default);   
                }
            }
        }
    }

}
