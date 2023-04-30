using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
	

	public ParticleSystem Particle_Blood;
	public Sprite blood;
	
	
	void OnParticleCollision(GameObject col)
	{		
		Debug.Log("sdfg");
		
	}
}
