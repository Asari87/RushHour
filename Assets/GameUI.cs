using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        quitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
    private void OnDestroy()
    {
        quitButton.onClick.RemoveAllListeners();
    }
}
