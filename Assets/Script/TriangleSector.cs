using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TriangleSector : MonoBehaviour
{
    public MirrorDisc mirrorDisc; 
    public List<LightDisc> allLightDiscs; 
    private bool isMoving = false;

    void Start()
    {

    }

    public void StartRotation()
    {
        if (!isMoving)
        {
            List<LightDisc> nearestDiscs = GetNearestLightDiscs();
            StartCoroutine(RotateSector(nearestDiscs));
        }
    }

    private List<LightDisc> GetNearestLightDiscs()
    {
        // Sort all Light Discs by distance from the Mirror Disc
        return allLightDiscs.OrderBy(disc => Vector3.Distance(disc.transform.position, mirrorDisc.transform.position))
                            .Take(3)
                            .ToList();
    }

    public IEnumerator RotateSector(List<LightDisc> ClosestLightDisc)
    {
        isMoving = true;
        float duration = 1.5f;
        float elapsedTime = 0f;

        // Store initial positions of only the 3 nearest Light Discs
        Vector3[] initialPositions = new Vector3[ClosestLightDisc.Count];
        for (int i = 0; i < ClosestLightDisc.Count; i++)
        {
            initialPositions[i] = ClosestLightDisc[i].transform.position;
        }


        // Move Light Discs anticlockwise
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;

            for (int i = 0; i < ClosestLightDisc.Count; i++)
            {
                int nextIndex = (i - 1 + ClosestLightDisc.Count) % ClosestLightDisc.Count;
                ClosestLightDisc[i].transform.position = Vector3.Lerp(initialPositions[i], initialPositions[nextIndex], progress);
            }

            yield return null;
        }

        // Update nearest Mirror Discs
        foreach (var disc in ClosestLightDisc)
        {
            disc.UpdateNearestMirror();
        }

        isMoving = false;
    }
}
