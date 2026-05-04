using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour {
    public Tilemap tilemap;
    [SerializeField] private float moveSpeed = 3f;

    private PlayerInput playerInput;
    private InputAction moveAction;

    private Vector2Int gridPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    private void Start() {
        Vector3Int cell = tilemap.WorldToCell(transform.position);
        gridPosition = new Vector2Int(cell.x, cell.y);
        targetPosition = tilemap.GetCellCenterWorld(cell);
        transform.position = targetPosition;
    }

    private void Update() {
        if (!playerInput.enabled) return;
        HandleMovement();

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition) {
            isMoving = false;
        }
    }

    private void HandleMovement() {
        if (isMoving) return;

        Vector2 input = moveAction.ReadValue<Vector2>();
        if (input == Vector2.zero) return;

        Vector2 nextDirection = input;
        if (Mathf.Abs(nextDirection.x) > Mathf.Abs(nextDirection.y)) {
            nextDirection.y = 0;
        }
        else {
            nextDirection.x = 0;
        }
        nextDirection = nextDirection.normalized;
        Vector3 direction = new Vector3(nextDirection.x, nextDirection.y, 0);

        TryMove(direction);
    }

    private void TryMove(Vector3 direction) {
        Vector3 nextPosition = targetPosition + direction;
        Collider2D hit = Physics2D.OverlapCircle(nextPosition, 0.2f);

        if (hit == null) {
            Debug.Log("Hola");
            MoveTo(nextPosition);
        }
        else if (hit.CompareTag("Box")) {
            Vector3 boxTarget = nextPosition + direction;
            Collider2D nextHit = Physics2D.OverlapCircle(boxTarget, 0.2f);
            if (nextHit == null) {
                hit.GetComponent<BoxMovement>().Move(direction);
                MoveTo(nextPosition);
            }
        }
    }

    private void MoveTo(Vector3 newPosition) {
        targetPosition = newPosition;
        isMoving = true;
    }
}
