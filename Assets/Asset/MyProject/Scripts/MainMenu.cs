using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGame;

    private void OnEnable() => startGame.onClick.AddListener(StartClicked);

    private void StartClicked() => SceneManager.LoadScene(0);

    private void OnDisable() => startGame.onClick.RemoveListener(StartClicked);
}
