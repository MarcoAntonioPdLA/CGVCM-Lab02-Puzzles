using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Tilemap tilemap;

    private Vector2Int gridPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start() {
        Vector3Int cell = tilemap.WorldToCell(transform.position);
        gridPosition = new Vector2Int(cell.x, cell.y);
        targetPosition = tilemap.GetCellCenterWorld(cell);
        transform.position = targetPosition;
    }

    private void Update() {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition) {
                isMoving = false;
            }
        }
    }

    public void Move(Vector3 direction) {
        if (!isMoving) {
            targetPosition += direction;
            isMoving = true;
        }
    }
}