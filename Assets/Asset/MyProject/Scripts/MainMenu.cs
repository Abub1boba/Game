using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private List<RoleButtons> roleButtons;

    private void OnEnable()
    {
        startGame.onClick.AddListener(StartClicked);
        foreach (var button in roleButtons)
        {
            button.Init();
            button.OnClicked += OnClicked;
        }
    }

    private void OnClicked(Role Role)
    {
        StaticData.playerRole = Role;
        foreach (var button in roleButtons)
        {
            if (button.role == Role)
            {
                button.ResetView(); 
            }
            else
            {
                button.GrayView();
            }
        }
    }

    private void StartClicked()
    {
        if (StaticData.playerRole == null) return;

        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        startGame.onClick.RemoveListener(StartClicked);
        foreach (var button in roleButtons)
        {
            button.UnInit();
            button.OnClicked -= OnClicked;
        }
    }
}

[Serializable]
public class RoleButtons
{
    public event Action<Role> OnClicked;
    public Role role;
    public Button button;

    public void Init() => button.onClick.AddListener(OnButtonClicked);

    private void OnButtonClicked() => OnClicked?.Invoke(role);

    public void UnInit() => button.onClick.RemoveListener(OnButtonClicked);

    public void ResetView() => button.image.color = Color.white;

    public void GrayView() => button.image.color = Color.gray;
}