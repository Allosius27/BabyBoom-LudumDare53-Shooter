using AllosiusDevCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    #region Fields

    private Rigidbody _rb;


    private List<Baby> _currentBabies = new List<Baby>();

    private bool _isFull;

    #endregion

    #region Properties

    public float speed { get; set; }

    public Vector3 direction { get; set; }


    #endregion

    #region UnityInspector

    [Required] [SerializeField] private VehicleData _vehicleData;

    [Required] [SerializeField] private BabySpot[] _spots;

    #endregion

    #region Behaviour

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        //int rnd = AllosiusDevUtilities.Utils.AllosiusDevUtils.RandomGeneration(0, 100);
        //if(rnd <= 50)
        //{

        //    _direction = Vector3.forward;
        //}
        //else
        //{
        //    _direction = Vector3.back;
        //}
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Baby baby = collision.gameObject.GetComponent<Baby>();
        if(baby != null)
        {
            AddBaby(baby);
        }
    }

    private void Move()
    {
        float moveStep = speed * Time.deltaTime;
        _rb.velocity = direction * moveStep;
    }

    public void QuitScreen()
    {
        Destroy(gameObject);
    }

    public void AddBaby(Baby baby)
    {
        BabySpot spotAvailable = GetAvailableBabySpot();
        if(!_isFull && spotAvailable != null)
        {
            if(_vehicleData.scorePointsAdded > 0)
            {
                _currentBabies.Add(baby);
                spotAvailable.isTaken = true;
                baby.Rb.velocity = Vector3.zero;
                baby.Rb.isKinematic = true;
                baby.Rb.useGravity = false;
                baby.isShooted = false;
                baby.Col.enabled = false;
                baby.transform.SetParent(spotAvailable.transform);
                baby.transform.localPosition = Vector3.zero;
                baby.transform.localEulerAngles = Vector3.zero;

                GameManager.Instance.ChangeScore((int)(_vehicleData.scorePointsAdded * GameManager.Instance.currentMultiplier));
                GameManager.Instance.ChangeSavedBabiesCount(1);
            }
            else
            {
                GameManager.Instance.ChangeScore((int)(_vehicleData.scorePointsAdded));
                baby.BabyDeath();
            }

            _isFull = CheckIsFull();

            if(_isFull)
            {
                GameManager.Instance.ChangeScore((int)(_vehicleData.scorePointsToFull * GameManager.Instance.currentMultiplier));
                GameManager.Instance.ChangeMultiplier(_vehicleData.scoreMultiplierBonusToFull);
            }
        }
        else
        {

        }
    }

    public BabySpot GetAvailableBabySpot()
    {
        for (int i = 0; i < _spots.Length; i++)
        {
            if(_spots[i].isTaken == false)
            {
                return _spots[i];
            }
        }

        return null;
    }

    public bool CheckIsFull()
    {
        if(_vehicleData.sizeInfinite)
        {
            return false;
        }
        else
        {
            if(_currentBabies.Count >= _vehicleData.size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    #endregion
}
