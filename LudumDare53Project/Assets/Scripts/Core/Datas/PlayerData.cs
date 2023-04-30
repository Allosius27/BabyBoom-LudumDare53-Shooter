using System.Collections;
using System.Collections.Generic;
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

    #endregion
}
