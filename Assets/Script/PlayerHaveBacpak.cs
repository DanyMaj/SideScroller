using UnityEngine;

public class PlayerHaveBacpak : MonoBehaviour
{
    public Backpack refToBackpack;
    
    public void PlayerHaveBackpack()
    {
        if (refToBackpack.haveBackpack)
        {
            refToBackpack.IHaveBackpack();
        }
    }
}
