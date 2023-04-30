using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffect : MonoBehaviour
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [SerializeField] private float _lifetime = 2f;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    private void Start()
    {
        if(_lifetime != 0)
        {
            Destroy(gameObject, _lifetime);
        }
        
    }

    public void DeactiveObj()
    {
        gameObject.SetActive(false);
    }

    #endregion

    #region Gizmos

    #endregion
}
