using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{
    public List<TriangleSector> triangleSectors;

    void Start()
    {
        foreach (var sector in triangleSectors)
        {
            foreach (var lightDisc in sector.allLightDiscs)
            {
                lightDisc.UpdateNearestMirror();
            }
        }
    }
}