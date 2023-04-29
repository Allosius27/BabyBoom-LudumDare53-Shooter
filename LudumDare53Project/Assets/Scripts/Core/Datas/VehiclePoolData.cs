using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New VehiclePoolData", menuName = "Core/VehiclePoolData")]
public class VehiclePoolData : SerializedScriptableObject
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [SerializeField] public List<VehicleData> vehicleDatas = new List<VehicleData>();

    [SerializeField] public List<float> rateTimes = new List<float>();

    #endregion

    #region Class

    #endregion

    #region Behaviour

    #endregion

    #region Gizmos

    #endregion
}
