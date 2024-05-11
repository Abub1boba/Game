using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour
{
    [SerializeField] private Button mainMenu;

    private void OnEnable() => mainMenu.onClick.AddListener(CancelClicked);

    private void CancelClicked() => SceneManager.LoadScene(1);

    private void OnDisable() => mainMenu.onClick.RemoveListener(CancelClicked);
}
