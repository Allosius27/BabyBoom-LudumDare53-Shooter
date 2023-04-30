using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    #region Fields

    private Baby _currentBaby;

    private bool _canShoot = true;

    private IEnumerator _shootCooldownCoroutine;

    private Animator anim;
    [SerializeField] GameObject Visual;

    #endregion

    #region UnityInspector

    [Required] [SerializeField] private PlayerData _playerData;

    [Required] [SerializeField] private Transform _bulletStart;

    #endregion

    #region Behaviour


    private void Start()
    {
        InstantiateBaby();
        anim = Visual.GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider);
            //transform.LookAt(hit.point);
            Vector3 difference =  transform.position - hit.point;
            float rotation = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);

            if (Input.GetMouseButton(0) && _canShoot)
            {

                anim.SetTrigger("Shot");
                //float distance = -difference.magnitude;
                //Vector3 direction = difference / distance;
                //direction.Normalize();
                Vector3 dir = hit.point - transform.position;
                dir.Normalize();
                FireBullet(hit.point);
            }
        }

        if(_canShoot && _currentBaby == null)
        {
            InstantiateBaby();
        }
        
    }

    private void InstantiateBaby()
    {
        _currentBaby = Instantiate(_playerData.babyPrefab, _bulletStart);
    }

    private void FireBullet(Vector3 direction)
    {
        if(_currentBaby == null || _canShoot == false)
        {
            return;
        }

        _currentBaby.Rb.isKinematic = false;
        _currentBaby.Rb.useGravity = true;
        _currentBaby.transform.SetParent(null);
        //_currentBaby.Rb.velocity = direction * _playerData.babySpeed;
        //_currentBaby.transform.position = direction;
        _currentBaby.target = direction;
        _currentBaby.isShooted = true;

        _currentBaby = null;
        _canShoot = false;

        if(_shootCooldownCoroutine != null)
        {
            StopCoroutine(_shootCooldownCoroutine);
        }
        _shootCooldownCoroutine = ShootCooldown();
        StartCoroutine(_shootCooldownCoroutine);
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(_playerData.shootingCooldownTime);

        _canShoot = true;
    }

    #endregion
}
