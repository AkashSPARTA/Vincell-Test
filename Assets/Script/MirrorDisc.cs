using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDisc : MonoBehaviour
{
    public TriangleSector assignedSector;
    private float Speed = 1.5f;
    private bool isRotating = false;
    public List<CircleCollider2D> MirrorCollider;

    private void OnMouseDown()
    {
        if (assignedSector != null && !isRotating)
        {
            isRotating = true;
            assignedSector.StartRotation();
            StartCoroutine(RotationTime(120f, Speed));
        }
        
    }

    public IEnumerator RotationTime(float targetRotation, float duration)
    {
        isRotating = true;
        foreach(CircleCollider2D col in MirrorCollider )
        {
            col.enabled = false;
        }
        float StartAngle = transform.eulerAngles.z;
        float endAngle = StartAngle + targetRotation;
        float elapsedtime = 0f;

        while (elapsedtime < duration)
        {
            elapsedtime += Time.deltaTime;
            float newAngle = Mathf.Lerp(StartAngle, endAngle, elapsedtime / duration);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 0, endAngle);

        foreach (CircleCollider2D col in MirrorCollider)
        {
            col.enabled = true;
        }
        isRotating = false ;
    }
}
