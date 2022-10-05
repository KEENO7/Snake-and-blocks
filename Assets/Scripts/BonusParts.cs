using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusParts : MonoBehaviour
{
<<<<<<< HEAD
    public TextMeshPro BonusPartsTXT;
=======
    public TextMeshPro BonusPartsText;
>>>>>>> parent of e89f58b (Added Obstacle numbers)
    public int Parts;

    private void Start()
    {
<<<<<<< HEAD
        Parts = Random.Range(3, 10);
        BonusPartsTXT.SetText(Parts.ToString());
=======
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

>>>>>>> parent of e89f58b (Added Obstacle numbers)
    }
}
