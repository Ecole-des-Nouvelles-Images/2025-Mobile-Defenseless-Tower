using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class PathManager : MonoBehaviourSingleton<PathManager>
{
    public int Height;
    public int Width; 
    
    public Cell[,] CellsMatrix;
    
    [SerializeField] private GameObject _wayGround;
    [SerializeField] private GameObject _ground;
    
    [SerializeField] private GameObject _castlePrefab;
    
    [SerializeField] private List<GameObject> _cellGameObjects = new List<GameObject>();

    public void SetDataPath(List<Vector3Int> vector3Ints)
    {
        CellsMatrix =  new Cell[Width, Height];
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                CellsMatrix[i, j] = new Cell();
            }
        }
        
        foreach (Vector3Int vector3Int in vector3Ints)
        {
            int x = Mathf.Clamp(vector3Int.x, 0, Width - 1);
            int z = Mathf.Clamp(vector3Int.z, 0, Height - 1);
            CellsMatrix[x, z].IsAPath = true;
        }
        
        SetVisual();
    }

    public void SetVisual()
    {
        ResetVisual();
        Debug.Log("SetVisual");
        int height = CellsMatrix.GetLength(0); 
        int width = CellsMatrix.GetLength(1); 

        for (int x = 0; x < height; x++)
        {
            for (int j = 0; j < width; j++)
            {
                if (!CellsMatrix[x, j].IsAPath)
                {
                    GameObject instance = Instantiate(_ground, new Vector3(x, 0, j), Quaternion.identity,transform);
                    _cellGameObjects.Add(instance);
                }
                else
                {
                    GameObject instance = Instantiate(_wayGround, new Vector3(x, 0, j), Quaternion.identity, transform);
                    _cellGameObjects.Add(instance);
                }
            }
        }
        
        PlaceCastle();
    }

    public void PlaceCastle()
    {
        GameObject castleA = Instantiate(_castlePrefab, transform.position, quaternion.identity, transform);
        GameObject castleB = Instantiate(_castlePrefab, transform.position, quaternion.identity, transform);
        _cellGameObjects.Add(castleA);
        _cellGameObjects.Add(castleB);

        castleB.AddComponent<Castle>();
        
        Spline spline = GameObject.FindGameObjectWithTag("Spline").GetComponent<SplineContainer>().Splines[0];

        BezierKnot firstKnot = spline[0];
        BezierKnot lastKnot = spline[spline.Count - 1];
        
        castleA.transform.position = firstKnot.Position;
        castleA.transform.position = new Vector3(firstKnot.Position.x, 0, firstKnot.Position.z - 1);
        
        castleB.transform.position = lastKnot.Position;
        castleB.transform.position = new Vector3(lastKnot.Position.x, 0, lastKnot.Position.z + 1);
        
        EventBus.OnTerrainGenerate?.Invoke();
        Debug.Log("Terrain generate complete REGLER LE PROBLEME DU INVOKE QUI NE SE FAIT PAS");
    }

    public void ResetVisual()
    {
        foreach (GameObject gm in _cellGameObjects)
        {
            if (!Application.isPlaying) DestroyImmediate(gm);
            else
            {
                Destroy(gm);
            }
        }
        _cellGameObjects.Clear();
    }
}