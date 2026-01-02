using UnityEngine;
public class Transformations : MonoBehaviour
{
    CreateGrid createGrid;
    Vector3[] startPosition;
    [Header("Movement Controls")]
    public float moveFrequency = 2f;
    public float moveAmplitude = 5f;
    public float moveOffset = 0f;
    Vector3 startScale = Vector3.zero;
    [Header("Scale Controls")]
    public float scaleFrequency = 2f;
    public float scaleAmplitude = 5f;
    public float scaleOffset = 0f;
    [Header("Rotation Controls")]
    public float rotationSpeed = 1f;
    private void Start()
    {
        createGrid = GetComponent<CreateGrid>();
        startPosition = createGrid.startPosition;
        startScale = createGrid.grid[0].localScale;
    }
    void Update()
    {
        for (int i = 0, z = 0; z < createGrid.gridSize; z++)
        {
            for (int y = 0; y < createGrid.gridSize; y++)
            {
                for (int x = 0; x < createGrid.gridSize; x++, i++)
                {
                    createGrid.grid[i].localPosition = startPosition[i] + Vector3.up * Mathf.Sin(Time.time * moveFrequency + moveOffset) * moveAmplitude;
                    // createGrid.grid[i].localScale = startScale * Mathf.Sin(Time.time * scaleFrequency) * scaleAmplitude + Vector3.one * scaleOffset;
                    createGrid.grid[i].localScale = startScale * Mathf.Cos(Time.time * scaleFrequency) * scaleAmplitude + Vector3.one * scaleOffset; // Uses Cos for scaling                                                                                                                           // createGrid.grid[i].Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
                    int dir = ((x + y + z) % 2 == 0) ? 1 : -1; // Sets rotation direction to 1 for even coordinate sums and -1 for odd ones
                    createGrid.grid[i].Rotate(Vector3.forward * Time.deltaTime * rotationSpeed * dir); // Rotates the cube AROUND the Z‑axis using that direction
                    // Added below to gradually change color (HSV) each frame
                    float t = Mathf.PingPong(Time.time, 1f);
                    Color c = Color.HSVToRGB(t, 1f, 1f);
                    createGrid.grid[i].GetComponent<Renderer>().material.color = c;
                }
            }
        }
    }
}
