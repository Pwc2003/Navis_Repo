using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    private void OnDrawGizmos(){
        SnapToGrid();
    }
    private void SnapToGrid() {
        Vector3 snapPosition = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            Mathf.Round(transform.position.z)
        );
        transform.position = snapPosition;
    }
}
