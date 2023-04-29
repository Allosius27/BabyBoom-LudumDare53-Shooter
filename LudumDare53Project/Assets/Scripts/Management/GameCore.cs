using AllosiusDevCore;
using AllosiusDevUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : Singleton<GameCore>
{
    #region Fields

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
        

    }

    #endregion

    #region Gizmos

    #endregion
}
