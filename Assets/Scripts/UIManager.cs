using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    PlayerManager playerManager;

    [SerializeField] GameObject panelStartGameUI;
    [SerializeField] GameObject panelGameOverUI;
    // [SerializeField] GameObject panelCompletedUI;

    [SerializeField] Text textCountEnemy;
    [SerializeField] Text textCountCrystal;

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        StartLevel();
        CountCrystalUI(0);
        CountEnemyUI(0);
    }

    void StartLevel()
    {
        CountEnemyUI(0);
        panelStartGameUI.SetActive(true);
        panelGameOverUI.SetActive(false);
        //panelCompletedUI.SetActive(false);
    }
    public void PlayGameUI()
    {
        playerManager.playerState = PlayerManager.PlayerState.Move;
        playerManager.levelState = PlayerManager.LevelState.NotFinished;
        panelStartGameUI.SetActive(false);
    }

    public void GameOverUI()
    {
        panelGameOverUI.SetActive(true);
        
    }
    public void GameCompletedUI()
    {

    }

    public void CountEnemyUI(int value)
    {
        textCountEnemy.text = value.ToString();
    }
    public void CountCrystalUI(int value)
    {
        textCountCrystal.text = value.ToString();
    }

    public void RestsrtLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
