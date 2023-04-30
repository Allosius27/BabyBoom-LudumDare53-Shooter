using System.Collections;
using System.Collections.Generic;
using AllosiusDevUtilities.Audio;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Core/PlayerData")]
public class PlayerData : SerializedScriptableObject
{
    #region UnityInspector

    [SerializeField] public float shootingCooldownTime = 0.5f;

    [SerializeField] public Baby babyPrefab;

    [Header("Feedbacks")]

    [SerializeField] public float launchBabySoundCooldown = 1f;
    
	[SerializeField] public float BabySoundCooldown = 3f;
    
	[SerializeField] public AudioData[] ShootAudio;
	
	[SerializeField] public AudioData[] BabyAudio;

    #endregion
}
