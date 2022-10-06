using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Prefab;
    public int Amount;

    public GameObject[] Prefabs;

    internal int index;

    private void Awake()
    {
        Prefabs = new GameObject[Amount];
        for (int i = 0; i < Amount; i++)
        {
            Prefabs[i] = Instantiate(Prefab, new Vector3(-70, 8.9f, 15), Quaternion.identity);
            Prefabs[i].SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        index++;
        if (index >= Amount) index = 0;

        Prefabs[index].SetActive(true);
        return Prefabs[index];
    }
}
