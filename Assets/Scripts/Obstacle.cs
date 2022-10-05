using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public TextMeshPro MinusPartsText;
    internal int MinusParts;

    private void Start()
    {
        MinusParts = Random.Range(1, 30);
        MinusPartsText.SetText(MinusParts.ToString());
    }
}
