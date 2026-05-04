using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private const int MAX_LEVEL_BUILD_INDEX = 2;

    public void Win() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == MAX_LEVEL_BUILD_INDEX) {
            Invoke(nameof(LoadFirstLevel), 1f);
        }
        else {
            Invoke(nameof(LoadNextLevel), 1f);
        }
    }

    private void LoadFirstLevel() {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
