using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public TextMeshPro MinusPartsText;
    internal int MinusParts;
    public Material Gradient;

    private void Start()
    {
        MinusParts = Random.Range(1, 30);
        MinusPartsText.SetText(MinusParts.ToString());
        gameObject.GetComponentInChildren<Renderer>().material.SetFloat("_BlockValue", 0.08f * MinusParts);
    }

}
