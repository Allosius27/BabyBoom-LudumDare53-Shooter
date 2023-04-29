using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    #region Fields

    private Baby _currentBaby;

    #endregion

    #region UnityInspector

    [Required] [SerializeField] private PlayerData _playerData;

    [Required] [SerializeField] private Transform _bulletStart;

    #endregion

    #region Behaviour


    private void Start()
    {
        InstantiateBaby();
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            //transform.LookAt(hit.point);
            Vector3 difference = hit.point - transform.position;
            float rotation = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);

            if (Input.GetMouseButtonDown(0))
            {
                float distance = difference.magnitude;
                Vector3 direction = difference / distance;
                direction.Normalize();
                FireBullet(direction);
            }
        }

        
    }

    private void InstantiateBaby()
    {
        _currentBaby = Instantiate(_playerData.babyPrefab);
        _currentBaby.transform.position = _bulletStart.transform.position;
        _currentBaby.transform.SetParent(transform);
    }

    private void FireBullet(Vector3 direction)
    {
        if(_currentBaby == null)
        {
            return;
        }

        _currentBaby.Rb.isKinematic = false;
        _currentBaby.Rb.useGravity = true;
        _currentBaby.transform.SetParent(null);
        _currentBaby.Rb.velocity = direction * _playerData.babySpeed;
        _currentBaby = null;
    }

    #endregion
}
