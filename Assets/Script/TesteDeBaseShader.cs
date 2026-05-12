using System.Collections;
using UnityEngine;
public class TesteDeBaseShader : MonoBehaviour
{
    public float dissolveDuration = 2;
    public float dissolveStrength;

    public void StartDissolver()
    {
        StartCoroutine(dissolver());
    }

    public IEnumerator dissolver()
    {
        float elapsedTime = 0;
        Material dissolveMaterial = GetComponent<Renderer>().material;
        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveStrength = Mathf.Lerp(1, 0, elapsedTime / dissolveDuration);
            dissolveMaterial.SetFloat("_alpha", dissolveStrength);
            yield return null;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDissolver();
        }
    }
}