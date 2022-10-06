using UnityEngine;
using TMPro;

public class BonusParts : MonoBehaviour
{
    public TextMeshPro BonusPartsText;
    internal int Parts;

    private void OnEnable()
    {     
        Parts = Random.Range(3, 10);
        BonusPartsText.SetText(Parts.ToString());

    }
}
