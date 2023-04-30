using AllosiusDevCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    #region Fields

    private Rigidbody _rb;


    private List<Baby> _currentBabies = new List<Baby>();

    private bool _isFull;

    #endregion

    #region Properties

	public float speed { get; set; }
    
	public DirectionEnum wayDirection {get; set;}

	public Vector3 direction { get; set; }
    



    #endregion

    #region UnityInspector

    [Required] [SerializeField] private VehicleData _vehicleData;

    [Required] [SerializeField] private BabySpot[] _spots;

    [SerializeField] private GameObject _heartUI;

    [SerializeField] private Transform _availablesSlotsUIParent;

    #endregion

    #region Behaviour

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;

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

    public void UpdateBabiesStockUI()
    {
        if(_availablesSlotsUIParent == null)
        {
            return;
        }

        if(_currentBabies.Count >= 1 && _vehicleData.sizeInfinite == false)
        {
            _availablesSlotsUIParent.gameObject.SetActive(true);
        }
        else
        {
            _availablesSlotsUIParent.gameObject.SetActive(false);
        }

        for (int i = 0; i < _availablesSlotsUIParent.childCount; i++)
        {
            if(i < _currentBabies.Count)
            {
                _availablesSlotsUIParent.GetChild(i).GetComponent<Image>().enabled = true;
            }
            else
            {
                _availablesSlotsUIParent.GetChild(i).GetComponent<Image>().enabled = false;
            }

            if(_isFull)
            {
                _availablesSlotsUIParent.GetChild(i).GetComponent<Image>().color = _vehicleData.fullColor;
            }
        }
    }

    public void AddBaby(Baby baby)
    {
        BabySpot spotAvailable = GetAvailableBabySpot();
        if(!_isFull && spotAvailable != null && baby.isOnGround == false)
        {
            if(_vehicleData.scorePointsAdded > 0)
            {
                if(_heartUI != null)
                {
                    _heartUI.SetActive(true);
                    _heartUI.GetComponent<Animator>().SetTrigger("Heart");
                }
                

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

                int scoreAmount = (int)(_vehicleData.scorePointsAdded * GameManager.Instance.currentMultiplier);
                GameManager.Instance.ChangeScore(scoreAmount);
                GameCanvasManager.Instance.CreateScorePopUp(transform, scoreAmount);
                GameManager.Instance.ChangeSavedBabiesCount(1);
            }
            else
            {
                int scoreAmount = (int)(_vehicleData.scorePointsAdded);
                GameManager.Instance.ChangeScore(scoreAmount);
                GameCanvasManager.Instance.CreateScorePopUp(transform, scoreAmount);
                baby.BabyDeath();
            }

            _isFull = CheckIsFull();
            UpdateBabiesStockUI();

            if(_isFull)
            {
                int scoreAmount = (int)(_vehicleData.scorePointsToFull * GameManager.Instance.currentMultiplier);
                GameManager.Instance.ChangeScore(scoreAmount);
                GameCanvasManager.Instance.CreateScorePopUp(transform, scoreAmount);
                GameManager.Instance.ChangeMultiplier(_vehicleData.scoreMultiplierBonusToFull);
                GameCanvasManager.Instance.CreateMultiplierPopUp(transform, GameManager.Instance.currentMultiplier);
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
