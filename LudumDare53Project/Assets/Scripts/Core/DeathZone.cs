using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
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
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if(vehicle != null)
        {
            vehicle.QuitScreen();
        }

        Baby baby = other.GetComponent<Baby>();
        if(baby != null)
        {
            Destroy(baby.gameObject);
        }
    }

    #endregion

    #region Gizmos

    #endregion
}
