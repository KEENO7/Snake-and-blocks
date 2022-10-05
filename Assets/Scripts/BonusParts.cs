using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusParts : MonoBehaviour
{
    public TextMeshPro BonusPartsTXT;
    public int Parts;

    private void Start()
    {
        Parts = Random.Range(3, 10);
        BonusPartsTXT.SetText(Parts.ToString());
    }

}
