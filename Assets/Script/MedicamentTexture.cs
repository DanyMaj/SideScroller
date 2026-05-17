using System.Collections;
using UnityEngine;

public class MedicamentTexture : MonoBehaviour
{
    public Medicament collitionMedicament;

    public float dissolveDuration = 2;
    public float dissolveStrength;
    [SerializeField] private Material dissolveMaterial;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dissolveMaterial = spriteRenderer.material;
    }
    public void StartDissolver()
    {
        StartCoroutine(dissolver());
    }

    public IEnumerator dissolver()
    {

        float elapsedTime = 0;       

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;

            dissolveStrength = Mathf.Lerp(0, 1, elapsedTime / dissolveDuration);

            dissolveMaterial.SetFloat("_alpha", dissolveStrength);

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
