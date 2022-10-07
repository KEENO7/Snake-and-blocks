using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public TextMeshPro MinusPartsText;
    internal int MinusParts;
    public Material Gradient;

    private void Start()
    {
        MinusParts = Random.Range(1, 30);
        MinusPartsText.text  = MinusParts.ToString();
        Coloring();
    }

    private void Coloring()
    {
        gameObject.GetComponentInChildren<Renderer>().material.SetFloat("_BlockValue", 0.04f * MinusParts);
        Invoke("Coloring", 0.01f);
    }
}
