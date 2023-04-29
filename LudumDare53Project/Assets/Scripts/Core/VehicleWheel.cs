using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWheel : MonoBehaviour
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    #endregion

    #region Class

    #endregion

    #region Behaviour

    private void OnTriggerEnter(Collider other)
    {
        Baby baby = other.GetComponent<Baby>();
        if(baby != null)
        {
            baby.BabyDeath();
        }
    }

    #endregion

    #region Gizmos

    #endregion
}
