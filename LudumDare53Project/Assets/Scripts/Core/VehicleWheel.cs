using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWheel : MonoBehaviour
{
    #region Fields

    #endregion

    #region Properties
    private Material material;
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

    private void Start()
    {
        //var renderer = Visual.GetComponent<MeshRenderer>();
        //material = Instantiate(renderer.sharedMaterial);
        //renderer.material = material;
    }

    private void OnTriggerEnter(Collider other)
    {
	    Baby baby = other.GetComponent<Baby>();
        
        
        if (baby != null)
        {
            Visual.GetComponent<MeshRenderer>().materials[0].SetFloat("_IsBlood", 4.39f);
            Visual.GetComponent<MeshRenderer>().materials[0].SetColor("_BloodColor", Color.red);
            GameObject obj = Instantiate(blood, new Vector3(transform.position.x+0.4f, transform.position.y+0.1f, transform.position.z) , Quaternion.identity);
            //material.SetFloat("IsBlood", 4);
            if (Car.wayDirection == DirectionEnum.Forward)
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
