using UnityEngine;

public class ObjectiveCollisionChecker : MonoBehaviour {
    public ObjectivesManager objectivesManager;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Box")) {
            objectivesManager.AddPoint();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Box")) {
            objectivesManager.RemovePoint();
        }
    }
}