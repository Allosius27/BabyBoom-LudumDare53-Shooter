using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWheel : MonoBehaviour
{
    #region Fields

    #endregion

    #region Properties
	public GameObject blood;
	public Vehicle Car;
	public GameObject Visual;
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
	    Baby baby = other.GetComponent<Baby>();
	    Visual.GetComponent<MeshRenderer>().materials[0].SetFloat("IsBlood",1);
        {
        	
        	GameObject obj = Instantiate(blood, new Vector3(transform.position.x+0.4f, transform.position.y+0.1f, transform.position.z) , Quaternion.identity);
        	
        	if(Car.wayDirection == DirectionEnum.Forward)
        	{
        		obj.transform.localEulerAngles = new Vector3(90.0f, 0, 0);
        	}
        	else
        	{
        		obj.transform.localEulerAngles = new Vector3(-90.0f, 0, 0);
        	}
        	
        	
        	
            baby.BabyDeath();
        }
    }

    #endregion

    #region Gizmos

    #endregion
}
