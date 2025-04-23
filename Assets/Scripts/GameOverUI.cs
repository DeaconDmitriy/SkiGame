using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Leaderboard leaderboard;
    [SerializeField] private float playerTime;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Image overlay;
    [SerializeField] private int nextLevelIndex = 1;
    private void Start()
    {
        overlay.CrossFadeAlpha(0, 1f, true);
        gameOverUI.SetActive(false);
    }
    private void OnEnable()
    {
        GameManager.RaceFinish += EnableGameOverUI;
        GameManager.gameQuit += Quit;
    }
    private void OnDisable()
    {
        GameManager.RaceFinish -= EnableGameOverUI;
        GameManager.gameQuit -= Quit;
    }
    private void EnableGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public void RestartLevel()
    {
        StartCoroutine(RestartCoroutine());
    }

    public void GameQuit()
    {
        GameManager.CallGameQuit();
    }

    private IEnumerator RestartCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }
    private void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }
    private IEnumerator QuitCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public void GoToNextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }
    private IEnumerator NextLevelCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelIndex);
    }

}
