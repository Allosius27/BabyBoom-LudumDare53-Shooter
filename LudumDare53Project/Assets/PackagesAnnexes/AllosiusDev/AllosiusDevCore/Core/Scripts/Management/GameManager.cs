using AllosiusDevUtilities;
using AllosiusDevCore.DialogSystem;
using AllosiusDevCore.QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AllosiusDevCore
{
    public class GameManager : Singleton<GameManager>
    {
        #region Properties

        public bool firstParty { get; set; } = true;

        public QuestList QuestManager => questManager;

        public int score { get; protected set; }

        public float currentMultiplier { get; protected set; } = 1;

        public float currentTimer { get; protected set; }

        public int currentSavedBabiesCount { get; protected set; }
        public int currentOupsBabiesCount { get; protected set; }

        #endregion

        #region UnityInspector

        [SerializeField] private QuestList questManager;

        #endregion

        #region Events

        public event Action SetScoreEvent;
        public event Action SetMultiplierEvent;
        public event Action SetTimerEvent;
        public event Action SetSavedBabiesEvent;
        public event Action SetOupsBabiesEvent;


        #endregion

        #region Behaviour

        public void ResetGame(GameData gameData)
        {
            Debug.Log("Reset Game");
            SetScore(0);
            SetMultiplier(1);
            SetTimer(gameData.partyDuration);
            SetSavedBabiesCount(0);
            SetOupsBabiesCount(0);
        }

        public void ChangeScore(int amount)
        {
            SetScore(score + amount);
        }

        private void SetScore(int amount)
        {
            score = amount;
            SetScoreEvent?.Invoke();
        }

        public void ChangeMultiplier(float amount)
        {
            SetMultiplier(currentMultiplier + amount);
        }

        private void SetMultiplier(float amount)
        {
            currentMultiplier = amount;
            SetMultiplierEvent?.Invoke();
        }

        public void ChangeTimer(float amount)
        {
            SetTimer(currentTimer + amount);
        }

        private void SetTimer(float amount)
        {
            currentTimer = amount;
            SetTimerEvent?.Invoke();
        }

        public void ChangeSavedBabiesCount(int amount)
        {
            SetSavedBabiesCount(currentSavedBabiesCount + amount);
        }

        private void SetSavedBabiesCount(int amount)
        {
            currentSavedBabiesCount = amount;
            SetSavedBabiesEvent?.Invoke();
        }

        public void ChangeOupsBabiesCount(int amount)
        {
            SetOupsBabiesCount(currentOupsBabiesCount + amount);
        }

        private void SetOupsBabiesCount(int amount)
        {
            currentOupsBabiesCount = amount;
            SetOupsBabiesEvent?.Invoke();
        }

        #endregion
    }
}
