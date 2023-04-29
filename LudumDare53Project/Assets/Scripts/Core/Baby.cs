using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    #region Fields

    private Rigidbody _rb;

    #endregion

    #region Properties

    public Rigidbody Rb => _rb;

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    #endregion

    #region Class

    #endregion

    #region Behaviour

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    #endregion

    #region Gizmos

    #endregion
}
