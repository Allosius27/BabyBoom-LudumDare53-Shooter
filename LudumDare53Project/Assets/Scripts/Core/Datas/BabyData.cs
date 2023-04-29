using AllosiusDevCore;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BabyData", menuName = "Core/BabyData")]
public class BabyData : SerializedScriptableObject
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [Header("Stats")]

    [SerializeField] public float babySpeed = 50.0f;

    [SerializeField] public FeedbacksData babyDeathFeedbacks;

    [Header("Score")]

    [SerializeField] public int deathPointsScoreAdded = -4;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    #endregion

    #region Gizmos

    #endregion
}
