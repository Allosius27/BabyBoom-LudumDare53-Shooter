using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesSpawner : MonoBehaviour
{
    #region Fields

    private int _currentWaveIndex;

    private float waveCountdown;

    #endregion

    #region Properties

    public List<CarPool> carsPool { get; protected set; } = new List<CarPool>();

    public SpawnState state = SpawnState.COUNTING;

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [Required] [SerializeField] private VehiclePoolData _vehiclesPoolData;

    [SerializeField] private DirectionEnum _wayDirection;

    [SerializeField] private Transform _spawnPoint;

    #endregion

    #region Class

    [Serializable]
    public class CarPool
    {
        public VehicleData vehicle { get; protected set; }
        public float timeRate { get; protected set; } = 1.0f;

        public CarPool(VehicleData vehicleData, float time)
        {
            vehicle = vehicleData;
            timeRate = time;
        }
    }

    #endregion

    #region Enum

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    #endregion

    #region Behaviour

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _vehiclesPoolData.vehicleDatas.Count; i++)
        {
            VehicleData data = _vehiclesPoolData.vehicleDatas[i];
            float time = 1.0f;
            if(i < _vehiclesPoolData.rateTimes.Count)
            {
                time = _vehiclesPoolData.rateTimes[i];
            }

            CarPool carPool = new CarPool(data, time);
            carsPool.Add(carPool);
        }

        carsPool = AllosiusDevUtilities.Utils.AllosiusDevUtils.RandomizeList(carsPool);

        waveCountdown = carsPool[_currentWaveIndex].timeRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            WaveCompleted();
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                // Start Wave Spawn
                StartCoroutine(SpawnWave(carsPool[_currentWaveIndex]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = carsPool[_currentWaveIndex].timeRate;

        if (_currentWaveIndex + 1 > carsPool.Count - 1)
        {
            _currentWaveIndex = 0;
            Debug.Log("All waves complete");
        }
        else
        {
            _currentWaveIndex++;
        }
    }

    IEnumerator SpawnWave(CarPool pool)
    {
        Debug.Log("Spawning Wave :");
        state = SpawnState.SPAWNING;

        // Spawn
        SpawnVehicle(pool.vehicle);

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnVehicle(VehicleData vehicleToSpawn)
    {
        // Spawn Vehicle
        Vehicle vehicle = Instantiate(vehicleToSpawn.vehiclePrefab, _spawnPoint);
        if(_wayDirection == DirectionEnum.Forward)
        {
            vehicle.direction = Vector3.forward;
            vehicle.transform.localScale = new Vector3(vehicle.transform.localScale.x, vehicle.transform.localScale.y, 1);
        }
        else
        {
            vehicle.direction = Vector3.back;
            vehicle.transform.localScale = new Vector3(vehicle.transform.localScale.x, vehicle.transform.localScale.y, -1);
        }
        

        Debug.Log("Spawning Enemy :" + vehicle.name);
    }

    #endregion

    #region Gizmos

    #endregion
}
