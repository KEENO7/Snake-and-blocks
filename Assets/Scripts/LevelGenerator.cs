using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] GridPrefabs;
    public GameObject StartGridPrefab;

    public int MinGrids;
    public int MaxGrids;
    public float DistanceBetweenGrids;

    public Transform FinishGrid;
    public Transform WayRoot;

    public Game Game;
    public Transform SnakeHead;

    public ObjectPool PickUpsPool;


    private void Awake()
    {
        int LevelIndex = Game.LevelIndex;
        Random random = new Random(LevelIndex);
        int GridCount = RandomRange(random, MinGrids, MaxGrids + 1);

        for (int i = 0; i < GridCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, GridPrefabs.Length);
            GameObject gridPrefab = i == 0 ? StartGridPrefab : GridPrefabs[prefabIndex];
            GameObject grid = Instantiate(gridPrefab, transform);
            grid.transform.localPosition = CalculateGridPosition(i);

        }


        FinishGrid.localPosition = CalculateGridPosition(GridCount);

        WayRoot.localScale = new Vector3(1, 1, GridCount * 2.3f + 0.6f);

    }

    private void Start()
    {

        SnakeHead = FindObjectOfType<SnakeHead>().transform;
        SpawnPickups();
    }

    private void Update()
    {
        float distance = FinishGrid.position.z - SnakeHead.position.magnitude;
        if(distance < 700)
        {
            CancelInvoke("SpawnPickups");
        }
    }

    private void SpawnPickups()
    {
            PickUpsPool.GetObject().transform.position = new Vector3(-2f, 8.9f, SnakeHead.transform.position.z + 260);
            Invoke("SpawnPickups", 5f);
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private Vector3 CalculateGridPosition(int i)
    {
        return new Vector3(-9.1f, 8.8f, DistanceBetweenGrids * i);
    }
}
