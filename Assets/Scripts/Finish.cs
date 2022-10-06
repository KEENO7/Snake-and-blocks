using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.rigidbody.TryGetComponent(out SnakeHead snakeHead)) return;
        snakeHead.ReachFinish();
    }
}
