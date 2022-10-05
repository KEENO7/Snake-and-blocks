using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public Transform SnakeCircle;
    public float CircleDiameter;

    internal List<Transform> _bodyParts = new List<Transform>();
    internal List<Vector3> _positions = new List<Vector3>();

    void Start()
    {
        _positions.Add(SnakeHead.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = ((Vector3)SnakeHead.position - _positions[0]).magnitude;

        if(distance > CircleDiameter)
        {
            Vector3 direction = ((Vector3)SnakeHead.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0]+direction*CircleDiameter);
            _positions.RemoveAt(_positions.Count - 1);
            distance -= CircleDiameter;
        }

        for (int i = 0; i < _bodyParts.Count; i++)
        {
            _bodyParts[i].position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / CircleDiameter);
        }
    }

    public void AddBodyPart()
    {
      Transform part = Instantiate(SnakeCircle, _positions[_positions.Count - 1], Quaternion.identity, transform);
        _bodyParts.Add(part);
        _positions.Add(part.position);
    }

    public void RemoveBodyPart()
    {
        Destroy(_bodyParts[0].gameObject);
        _bodyParts.RemoveAt(0);
        _positions.RemoveAt(_positions.Count -1);
    }
}
