using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button menuButton;


    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });

        menuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    private void OnDestroy()
    {
        playAgainButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
    }
}
