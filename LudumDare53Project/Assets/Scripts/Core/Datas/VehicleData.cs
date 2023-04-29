using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New VehicleData", menuName = "Core/VehicleData")]
public class VehicleData : SerializedScriptableObject
{
    #region UnityInspector

    [SerializeField] public float speed = 1.0f;

    [SerializeField] public bool sizeInfinite;
    [HideIfGroup("sizeInfinite")]
    [SerializeField] public int size = 2;

    #endregion
}
