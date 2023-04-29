using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New VehicleData", menuName = "Core/VehicleData")]
public class VehicleData : SerializedScriptableObject
{
    #region UnityInspector

    [Header("Stats")]

    [SerializeField] public float speed = 1.0f;

    [SerializeField] public bool sizeInfinite;
    [HideIfGroup("sizeInfinite")]
    [SerializeField] public int size = 2;

    [SerializeField] public Vehicle vehiclePrefab;

    [Header("Score")]

    [SerializeField] public int scorePointsAdded = 10;

    [HideIfGroup("sizeInfinite")]
    [SerializeField] public int scorePointsToFull = 20;
    [SerializeField] public float scoreMultiplierBonusToFull = 0.1f;

    #endregion
}
