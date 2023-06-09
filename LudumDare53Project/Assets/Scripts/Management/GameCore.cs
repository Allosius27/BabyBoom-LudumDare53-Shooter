﻿using AllosiusDevCore;
using AllosiusDevUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllosiusDevUtilities.Audio;
using AllosiusDevUtilities.Core;

[RequireComponent(typeof(FeedbacksReader))]
public class GameCore : Singleton<GameCore>
{
    #region Fields

    private bool _gameEnded;

    private FeedbacksReader _feedbaksReader;

    #endregion

    #region Properties

    public Texture2D currentAimCursor { get; set; }

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [SerializeField] private GameData _gameData;
    
	[SerializeField] private AudioData _mainMusic;

    [SerializeField] private DeathZone[] outsidesWays;
    
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    [SerializeField] public Texture2D aimCursor;
    [SerializeField] public Texture2D validAimCursor;
    [SerializeField] public Texture2D invalidAimCursor;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    private void Start()
    {
        currentAimCursor = aimCursor;

        _feedbaksReader = GetComponent<FeedbacksReader>();

	    GameManager.Instance.ResetGame(_gameData);
        
	    AudioController.Instance.PlayAudio(_mainMusic);

        
    }

    private void Update()
    {
        UpdateTimer();

        if(GameStateManager.gameIsPaused == false)
        {
            Cursor.SetCursor(currentAimCursor, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }

    public Transform GetClosestOutsideWay(Transform target)
    {
        float distance = float.MaxValue;
        Transform closest = outsidesWays[0].transform;

        foreach(var item in outsidesWays)
        {
            float dist = Vector3.Distance(target.position, item.transform.position);
            if(dist < distance)
            {
                distance = dist;
                closest = item.transform;
            }
        }

        return closest;
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
