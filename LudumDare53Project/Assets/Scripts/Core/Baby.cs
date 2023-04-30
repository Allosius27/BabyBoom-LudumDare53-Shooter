using AllosiusDevCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FeedbacksReader))]
public class Baby : MonoBehaviour
{
    #region Fields

    private Rigidbody _rb;

    private Collider _col;

    private FeedbacksReader _feedbacksReader;

    #endregion

    #region Properties

    public Rigidbody Rb => _rb;

    public Collider Col => _col;

    public Vector3 target{ get; set; }

    public float speed { get; set; }

    public bool isShooted { get; set; }

    public bool isInMovement { get; set; }

    public bool isOnGround { get; set; }

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [Required] [SerializeField] private BabyData _babyData;

    [Required] [SerializeField] private Animator _animator;

    [SerializeField] private Vector3 rotationToGround = new Vector3(90, 0, 0);

    #endregion

    #region Class

    #endregion

    #region Behaviour

    // Start is called before the first frame update
    void Start()
    {
        _feedbacksReader = GetComponent<FeedbacksReader>();

        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
        _animator = GetComponent<Animator>();

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

        if(_animator != null)
        {
            _animator.SetBool("IsInMovement", isInMovement);
        }
    }

    public void BabyDeath()
    {
        Debug.Log("Baby Death");
        GameManager.Instance.ChangeScore(_babyData.deathPointsScoreAdded);
        GameManager.Instance.ChangeOupsBabiesCount(1);
        _feedbacksReader.ReadFeedback(_babyData.babyDeathFeedbacks);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Entity entity = collision.gameObject.GetComponent<Entity>();
        if(entity != null)
        {
            isOnGround = true;


        }
    }

    #endregion

    #region Gizmos

    #endregion
}
