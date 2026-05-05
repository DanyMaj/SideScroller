using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;


[System.Serializable]
public class StokageV2 : MonoBehaviour
{
    public bool checkAccreditationCardLvl1;
    public ToolManager playerToolManager;
    public int accreditationCardLvl1;

    public bool CheckEvidence;
    public Evidence playerEvidence;
    public int evidenceNombre;
    public bool isOpen;

    public List<Tools> theTool;
    [SerializeField]
    private bool playerIsTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement_01>();
        if (player != null)
        {
            playerIsTrigger = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement_01>();
        if (player != null)
        {
            playerIsTrigger = false;
        }
    }

    public void Update()
    {
        if (playerIsTrigger == true)
        {
            //Debug.Log("Je suis l1");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Je suis e");
                OpenStockage();
            }
        }
    }

    private void OpenStockage()
    {

        
        if (isOpen == false)
        {
            isOpen = true;

            foreach (var item in theTool)
            {
                //if (item.isValid == true)
                {
                //    playerToolManager.add(item);
                }
            }
        }
        else
        {
            print("Ce Stockage est vide");
        }
    }
}
