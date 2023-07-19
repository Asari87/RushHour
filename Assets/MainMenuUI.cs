using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;


    private void Awake()
    {
        playButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene(1);
        });
        optionsButton.onClick.AddListener(() =>
        {

        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        optionsButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
}
