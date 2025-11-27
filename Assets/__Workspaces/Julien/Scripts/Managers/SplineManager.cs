using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class SplineManager : MonoBehaviour
{
    public SplineContainer SplineContainer;

    public int KnotCount;
    public int TerrainSize;

    public int StartPosX;
    public int EndPosX;

    public Vector2Int RandomPos;
    public Vector2Int MaxWidth;
    public Vector2Int MaxHeight;
    
    private List<Vector3Int> _vector3Ints = new List<Vector3Int>();
    
    // position du dernier point posé, utiliser pour générer loe départ du prochain point
    private Vector3 _lastKnotPosition = Vector3.zero;
        
    private void OnEnable()
    {
        SplineContainer = GetComponent<SplineContainer>();
        EventBus.OnGameStart += GenerateSpline; 
    }

    [ContextMenu("GenerateSpline")]
    public void GenerateSpline()
    {
        _vector3Ints.Clear();
        SplineContainer.Spline.Clear(); // je clear la spline

        float space = TerrainSize / (KnotCount - 1);
        
        for (float i = 0; i <= TerrainSize; i += space)
        {
            
            Vector3 posA = new Vector3(); // position du point A
            Vector3 posB = new Vector3(); // Position du point B
            
            if (i == 0) // Si le knot est le premier, alors on joue l'interieur du code
            {
                posA = new Vector3(StartPosX, 0, MaxHeight.x); // La position X du point A serra = à un random, et il n'y aurra pas de point B vu que c'est le premier
            }
            else // sinon
            {
                int rand = Random.Range(RandomPos.x, RandomPos.y);
                
                posA = new Vector3(_lastKnotPosition.x, 0, i); // La position sur X est celle du dernier point, et i est = à la longueur
                posB = new Vector3(_lastKnotPosition.x + rand, 0, i); // Le second point, le X est randomiser ( la valeur pourrait être tweeker en fonction de la difficulté )

                if (posB.x < MaxWidth.x) posB.x = MaxWidth.x; // verifier si il sort de la zone, si il sort alors on applique le max
                if (posB.x > MaxWidth.y) posB.x = MaxWidth.y;
                if (posA.x < MaxWidth.x) posA.x = MaxWidth.x;
                if (posA.x > MaxWidth.y) posA.x = MaxWidth.y;

                if (posB.z > MaxHeight.y) posB.z = MaxHeight.y;
                if (posA.z > MaxHeight.y) posA.z = MaxHeight.y;
            }

            
            BezierKnot knotA = new BezierKnot(posA, Vector3.zero, Vector3.zero); //Je créer un Knot qui serra le point A
            SplineContainer.Spline.Add(knotA, TangentMode.Linear); // je l'ajoute à ma spline, et le Knot serra Linear
            
            if (i > 0) // Si le knot n'est pas le premier alors on joue le code
            {
                BezierKnot knotB = new BezierKnot(posB, Vector3.zero, Vector3.zero);
                SplineContainer.Spline.Add(knotB, TangentMode.Linear);
            }

            if (i == 0) // Si c'est le premier knot
            {
                _lastKnotPosition = posA; // lastKnotPosition serra égal au premier
            }
            else
            {
                _lastKnotPosition = posB; // lastKnotPosition serra égal au dernier porsé
            }
        }
        PlacePenultimateKnot();
        PlaceLastKnot();
        ParcourSpline();
    }

    private void PlacePenultimateKnot()
    {
        Spline spline = SplineContainer.Splines[0];
        BezierKnot knot = spline[spline.Count - 1];
        knot.Position.x = EndPosX;
        spline.SetKnot(spline.Count - 1, knot);
    }

    private void PlaceLastKnot()
    {
        Spline spline = SplineContainer.Splines[0];
        BezierKnot knot = spline[spline.Count - 1];
        
        BezierKnot copyKnot = knot;
        copyKnot.Position.z = knot.Position.z + 1;
        spline.Add(copyKnot);
    }
    
    private void ParcourSpline()
    {
        // Parcours spline
        for (float i = 0; i <= 1; i += 0.01f)
        {
            SplineContainer.Evaluate(0, i, out float3 pos, out float3 tangent, out _);
            // Sur la spline[0], je prend la pos i, la pos est normalizé, elle me renvoie la pos dans le monde.
            Vector3 lastPosVec = pos;
            
            Vector3Int vector3Int = new Vector3Int(Mathf.RoundToInt(lastPosVec.x),0,Mathf.RoundToInt(lastPosVec.z));

            if (!_vector3Ints.Contains(vector3Int))
            {
                _vector3Ints.Add(vector3Int);
            }
        }
        
        // foreach (Vector3Int v in _vector3Ints)
        // {
        //     Debug.Log(v);
        // }
        
        PathManager.Instance.SetDataPath(_vector3Ints);
        Debug.Log(_vector3Ints);
    }
}
