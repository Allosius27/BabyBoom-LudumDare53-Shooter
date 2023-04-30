using AllosiusDevCore;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Core/GameData")]
public class GameData : SerializedScriptableObject
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [SerializeField] public int partyDuration;

    [SerializeField] public SceneData endGameScene;

    [SerializeField] public FeedbacksData endGameFeedbacks;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    #endregion

    #region Gizmos

    #endregion
}
