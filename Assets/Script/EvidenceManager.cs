using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    public int EvidencePoint;

      public void AddEvidence(int evidence)
    {
        EvidencePoint += evidence;
    }
}
