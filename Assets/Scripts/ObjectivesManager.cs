using UnityEngine;

public class ObjectivesManager : MonoBehaviour {
    [SerializeField] private int pointsObjective = 0;

    private GameManager gameManager;
    private int points = 0;

    private void Start() {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void AddPoint() {
        points++;
        if(points >= pointsObjective) {
            gameManager.Win();
        }
    }

    public void RemovePoint() {
        points = Mathf.Max(points - 1, 0);
    }
}
