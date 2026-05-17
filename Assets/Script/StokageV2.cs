using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class StokageV2 : Interactable
{
    public ToolManager playerToolManager;
    public EvidenceManager playerEvidence;
    private SpriteRenderer sr;
    public Sprite bureauOuvert;
    public Sprite CasierOuvert;
    public GameObject toolsGameObject;
    public Transform[] spawnPoints;
    public Transform centerPoint;

    public Transform[] pathRight;
    public Transform[] pathLeft;

    public float speed = 5f;

    public bool CheckEvidence;
    public bool canOpen = true;
    public bool Casier;
    public int evidenceNombre = 1;


    public override void Interaction()
    {
        if (canOpen)
        {
            playerToolManager = player.GetComponent<ToolManager>();
            OpenStockage();
        }
    }

    private void OpenStockage()
    {  
        canOpen = false;

        // Début Ai
        GameObject instantiated = Instantiate(
        toolsGameObject,
        centerPoint.position,
        Quaternion.identity
         );

        bool goRight = Random.Range(0, 2) == 0;

        if (goRight)
        {
            StartCoroutine(MoveOnPath(instantiated, pathRight));
        }
        else
        {
            StartCoroutine(MoveOnPath(instantiated, pathLeft));
        }
        //Fin Ai

        if (Casier)
        {
            //pour le casier
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = CasierOuvert;
        }
        if (!Casier)
        {
            //pour le bureau
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = bureauOuvert;
        }

        if (CheckEvidence) 
        {
            playerEvidence.AddEvidence(evidenceNombre);
        }
    }

    private IEnumerator MoveOnPath(GameObject obj, Transform[] path)
    {
        foreach (Transform point in path)
        {
            while (Vector2.Distance(obj.transform.position, point.position) > 0.1f)
            {
                obj.transform.position = Vector2.MoveTowards(
                    obj.transform.position,
                    point.position,
                    speed * Time.deltaTime
                );
                yield return null;
            }
        }
    }
}
