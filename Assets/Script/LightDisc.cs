using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LightDisc : MonoBehaviour
{
    public MirrorDisc closestMirror;
    public List<MirrorDisc> allMirrorDiscs;

    public void UpdateNearestMirror()
    {
        if (allMirrorDiscs.Count > 0)
        {
            closestMirror = allMirrorDiscs.OrderBy(mirror => Vector3.Distance(transform.position, mirror.transform.position)).First();
        }
    }

}
