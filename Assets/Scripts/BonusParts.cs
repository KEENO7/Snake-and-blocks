using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonusParts : MonoBehaviour
{
    public TextMeshPro BonusPartsText;
    internal int Parts;

    private void OnEnable()
    {     
        Parts = Random.Range(3, 10);
        BonusPartsText.text = Parts.ToString();

    }
}
