using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase[] tiles;

    public GameObject prefab1;

    //private PlaceableObject objectToPlace;

    // Methods

    private void Awake() {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    // UTILS

    public static Vector3 GetMouseWorldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            return hit.point;
        } else {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinatesToGrid(Vector3 position) {
        Vector3Int cell = grid.WorldToCell(position);
        position = grid.GetCellCenterWorld(cell);
        return position;
    }
}
