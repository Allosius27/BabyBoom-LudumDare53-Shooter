using AllosiusDevUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AllosiusDevCore;

public class GameCanvasManager : Singleton<GameCanvasManager>
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [SerializeField] private TextMeshProUGUI _scoreAmountText;
    [SerializeField] private TextMeshProUGUI _multiplierAmountText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _savedAmountText;
    [SerializeField] private TextMeshProUGUI _oupsAmountText;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    private void Start()
    {
        GameManager.Instance.SetScoreEvent += UpdateScore;
        GameManager.Instance.SetMultiplierEvent += UpdateMultiplier;
        GameManager.Instance.SetTimerEvent += UpdateTimer;
        GameManager.Instance.SetSavedBabiesEvent += UpdateSavedBabies;
        GameManager.Instance.SetOupsBabiesEvent += UpdateOupsBabies;
    }

    private void OnDestroy()
    {
        GameManager.Instance.SetScoreEvent -= UpdateScore;
        GameManager.Instance.SetMultiplierEvent -= UpdateMultiplier;
        GameManager.Instance.SetTimerEvent -= UpdateTimer;
        GameManager.Instance.SetSavedBabiesEvent -= UpdateSavedBabies;
        GameManager.Instance.SetOupsBabiesEvent -= UpdateOupsBabies;
    }

    public void UpdateScore()
    {
        _scoreAmountText.text = GameManager.Instance.score.ToString();
    }

    public void UpdateMultiplier()
    {
        _multiplierAmountText.text = GameManager.Instance.currentMultiplier.ToString();
    }

    public void UpdateTimer()
    {
        int timer = (int)GameManager.Instance.currentTimer;

        int seconds = timer % 60;
        int minutes = timer / 60;
        _timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void UpdateSavedBabies()
    {
        _savedAmountText.text = GameManager.Instance.currentSavedBabiesCount.ToString();
    }

    public void UpdateOupsBabies()
    {
        _oupsAmountText.text = GameManager.Instance.currentOupsBabiesCount.ToString();
    }

    #endregion

    #region Gizmos

    #endregion
}
