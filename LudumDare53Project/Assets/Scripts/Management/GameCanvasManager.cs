using AllosiusDevUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AllosiusDevCore;
using static UnityEngine.GraphicsBuffer;

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

    [Space]

    [SerializeField] private PopUpText _addScorePopUp;
    [SerializeField] private PopUpText _removeScorePopUp;
    [SerializeField] private PopUpText _bonusMultiplierScorePopUp;

    [SerializeField] private PopUpImg[] _babyShootPopUps;

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
        _multiplierAmountText.text = GameManager.Instance.currentMultiplier.ToString(".0");
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

    public void CreateScorePopUp(Transform target, int amount)
    {
        PopUpText textToInstantiate = _addScorePopUp;
        if(amount < 0)
        {
            textToInstantiate = _removeScorePopUp;
        }

        var myNewScore = Instantiate(textToInstantiate);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(target.position);


        myNewScore.transform.SetParent(transform, false);
        myNewScore.transform.position = screenPosition;
        myNewScore.GetComponent<PopUpText>().SetPoints(amount);
    }

    public void CreateMultiplierPopUp(Transform target, float amount)
    {
        PopUpText textToInstantiate = _bonusMultiplierScorePopUp;

        var myNewScore = Instantiate(textToInstantiate);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(target.position);


        myNewScore.transform.SetParent(transform, false);
        myNewScore.transform.position = screenPosition;
        myNewScore.GetComponent<PopUpText>().SetMultiplier(amount);
    }

    public void CreateShootBabyPopUp(Transform target)
    {
        PopUpImg imgToInstantiate = _babyShootPopUps[AllosiusDevUtilities.Utils.AllosiusDevUtils.RandomGeneration(0, _babyShootPopUps.Length)];

        var myNewScore = Instantiate(imgToInstantiate);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(target.position);


        myNewScore.transform.SetParent(transform, false);
        myNewScore.transform.position = screenPosition;
    }

    #endregion

    #region Gizmos

    #endregion
}
