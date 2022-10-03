using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusParts : MonoBehaviour
{
    public TextMeshPro BonusPartsText;
    public int Parts;

    private void Start()
    {
        BonusPartsText.SetText(Parts.ToString());
        Parts = Random.Range(1, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeHead snake))
        {
            snake.Length += Parts;
            snake._snakeTail.AddBodyPart();
            Destroy(gameObject);
        }

    }
}
