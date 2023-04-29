using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    #region Fields

    private Rigidbody _rb;

    private Vector3 _direction;

    private List<Baby> _currentBabies = new List<Baby>();

    #endregion

    #region UnityInspector

    [Required] [SerializeField] private VehicleData _vehicleData;

    #endregion

    #region Behaviour

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        int rnd = AllosiusDevUtilities.Utils.AllosiusDevUtils.RandomGeneration(0, 100);
        if(rnd <= 50)
        {

            _direction = Vector3.forward;
        }
        else
        {
            _direction = Vector3.back;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveStep = _vehicleData.speed * Time.deltaTime;
        _rb.velocity = _direction * moveStep;
    }

    public void QuitScreen()
    {
        Destroy(gameObject);
    }

    #endregion
}
