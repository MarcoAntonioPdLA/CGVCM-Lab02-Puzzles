using UnityEngine;

public class ObjectivesManager : MonoBehaviour {
    [SerializeField] private int pointsObjective = 4;
    private int points = 0;

    public void AddPoint() {
        points++;
        if(points >= pointsObjective) {
            Debug.Log("Ganaste");
        }
    }

    public void RemovePoint() {
        points = Mathf.Max(points - 1, 0);
    }
}
