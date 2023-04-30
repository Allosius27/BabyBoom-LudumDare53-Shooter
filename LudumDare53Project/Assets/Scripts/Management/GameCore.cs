using AllosiusDevCore;
using AllosiusDevUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FeedbacksReader))]
public class GameCore : Singleton<GameCore>
{
    #region Fields

    private bool _gameEnded;

    private FeedbacksReader _feedbaksReader;

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [SerializeField] private GameData _gameData;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    private void Start()
    {
        _feedbaksReader = GetComponent<FeedbacksReader>();

        GameManager.Instance.ResetGame(_gameData);
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if(GameManager.Instance.currentTimer > 0)
        {
            GameManager.Instance.ChangeTimer(-Time.deltaTime);
        }
        else
        {
            if(_gameEnded == false)
            {
                EndGame();
            }
        }

    }

    private void EndGame()
    {
        _gameEnded = true;

        _feedbaksReader.ReadFeedback(_gameData.endGameFeedbacks);

        SceneLoader.Instance.ChangeScene(_gameData.endGameScene.sceneToLoad);

    }

    #endregion

    #region Gizmos

    #endregion
}
