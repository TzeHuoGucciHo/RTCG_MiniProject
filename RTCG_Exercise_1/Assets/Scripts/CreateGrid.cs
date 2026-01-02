using UnityEngine;
public class CreateGrid : MonoBehaviour
{
    public Transform prefab;
    public int gridSize = 10;
    public Transform[] grid;
    public Vector3[] startPosition;
    void Awake()
    {
        grid = new Transform[gridSize * gridSize * gridSize];
        startPosition = new Vector3[gridSize * gridSize * gridSize];
        for (int i = 0, z = 0; z < gridSize; z++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++, i++)
                {
                    grid[i] = CreateGridPoint(x, y, z);
                    startPosition[i] = GetCoordinates(x, y, z);
                }
            }
        }
    }
    Transform CreateGridPoint(int x, int y, int z)
    {
        Transform point = Instantiate<Transform>(prefab);
        point.localPosition = GetCoordinates(x, y, z);
        point.GetComponent<MeshRenderer>().material.color = new Color(
            (float)x / gridSize,
            (float)y / gridSize,
            (float)z / gridSize
        );
        return point;
    }
    Vector3 GetCoordinates(int x, int y, int z)
    {
        return new Vector3(
            x - (gridSize - 1) * 0.5f,
            y - (gridSize - 1) * 0.5f,
            z - (gridSize - 1) * 0.5f
        );
    }
}
