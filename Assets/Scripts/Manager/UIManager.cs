using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Level ProgresBar UI")]
    [SerializeField] int sceneOffset;
    [SerializeField] Text nextLevel;
    [SerializeField] Text currentLevelText;
    [Header("Count Cristal for Level")]
    [SerializeField] Text currentCristalText;
    [Space]
    [SerializeField] Image progresFillCristalFever;
    [Space]
    [SerializeField] TMP_Text levelCompletedText;
    [SerializeField] TMP_Text levelText;

    [Space]
    [SerializeField] Image FadePanel;

    [SerializeField] string _nameMusick;
    PlayerManager playerManager;

    [Header("Panel  UI")]
    [SerializeField] GameObject panelStartGameUI;
    [SerializeField] GameObject panelGameOverUI;
    [SerializeField] GameObject panelCompletedUI;

    void Awake() {
       if(Instance == null)
        Instance = this;    
   }
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        StartLevel();

        FadePanelAsStart();
        LevelTextAsStart();
        //AudioMenager.instance.PlaySound(_nameMusick);
    }
    void StartLevel()
    {
        panelStartGameUI.SetActive(true);
        panelGameOverUI.SetActive(false);
        panelCompletedUI.SetActive(false);
    }

    public void PlayGameUI()
    {
        playerManager.playerState = PlayerManager.PlayerState.Move;
        playerManager.levelState = PlayerManager.LevelState.NotFinished;
        panelStartGameUI.SetActive(false);
    }
    void SetLevelProgresText()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        currentLevelText.text = (level).ToString();
        nextLevel.text = (level +1).ToString();
    }
    public void UpdateLevelProgresBarFever(int value)
    {
        float val = ((float)value /  playerManager.countDedEnemy);
        progresFillCristalFever.DOFillAmount(val, .4f);
    }

    public void CountCrystalUI(int value)
    {
        currentCristalText.text = value.ToString();
    }
    public void FadePanelAsStart()
    {
        FadePanel.DOFade(0f,1.5f).From(1f);
    }
    public void LevelTextAsStart()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level "+(level).ToString();
        levelText.DOFade(1f,.9f).From(0f);
        Invoke("LevelTextOnShow",2f);
    }
    void LevelTextOnShow()
    {
        levelText.DOFade(0f,.9f).From(1f);
    }

    public void GameCompletedUI()
    {
        panelCompletedUI.SetActive(true);
    }
    public void GameOverUI()
    {
        panelGameOverUI.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
}