using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject SnakeHead;
    public Transform FinishGrid;
    public Slider Slider;

    private float _startZ;
    public float MaximumReachedZ;
    public float AcceptableFinishPlayerDistance = 1f;

    private void Start()
    {
        _startZ = SnakeHead.transform.position.z;
    }

    private void Update()
    {
        MaximumReachedZ = Mathf.Max(MaximumReachedZ, SnakeHead.transform.position.z);
        float finishZ = FinishGrid.position.z;
        float t = Mathf.InverseLerp(_startZ, finishZ + AcceptableFinishPlayerDistance, MaximumReachedZ);
        Slider.value = t;
    }
}
