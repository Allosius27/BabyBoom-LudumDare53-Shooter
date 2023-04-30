using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using AllosiusDevCore;
using TMPro;

public class ScoreMenu : MonoBehaviour
{


    #region UnityInspector

    [SerializeField] private TextMeshProUGUI _scoreAmountText;
    [SerializeField] private TextMeshProUGUI _savedBabiesAmountText;
    [SerializeField] private TextMeshProUGUI _oupsBabiesAmountText;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    #endregion

    #region Behaviour

    private void Start()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);

        if (GameManager.Instance != null)
        {
            _scoreAmountText.text = GameManager.Instance.score.ToString();
            _savedBabiesAmountText.text = GameManager.Instance.currentSavedBabiesCount.ToString();
            _oupsBabiesAmountText.text = GameManager.Instance.currentOupsBabiesCount.ToString();
        }
    }

    public void MainMenuButton()
    {
        SceneLoader.Instance.ChangeScene(Scenes.MainMenu);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    #endregion
}
