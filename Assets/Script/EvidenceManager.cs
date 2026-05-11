using UnityEngine;
using UnityEngine.UI;

public class EvidenceManager : MonoBehaviour
{
    public int EvidencePoint = 0;
    public Text EvidencePointUi;

    public void AddEvidence(int evidence)
    {
        EvidencePoint += evidence;
        EvidencePointUi.text = EvidencePoint.ToString();
    }
}
