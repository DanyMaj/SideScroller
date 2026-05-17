using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject unePlace;
    public GameObject troisPlaces;

    private void Awake()
    {
        instance = this;
    }
}