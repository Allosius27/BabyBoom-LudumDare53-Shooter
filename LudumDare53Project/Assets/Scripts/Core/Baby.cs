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

    public Vector3 target{ get; set; }

    public float speed { get; set; }

    public bool isShooted { get; set; }

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [Required] [SerializeField] private BabyData _babyData;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        speed = _babyData.babySpeed;
    }

    private void Update()
    {

        if(isShooted)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                isShooted = false;
            }
        }
        
    }

    #endregion

    #region Gizmos

    #endregion
}
