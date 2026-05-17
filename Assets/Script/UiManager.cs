using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject unePlace;
    public GameObject troisPlaces;
    public Image enplacement1Debut;
    public Image enplacement1;
    public Image enplacement2;
    public Image enplacement3;

    private void Awake()
    {
        instance = this;
    }
}