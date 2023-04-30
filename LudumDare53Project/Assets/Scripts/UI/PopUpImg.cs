using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpImg : MonoBehaviour
{
    public float lifeTime = 3f;
    public float moveSpeed = 50f;

    public float placementJitter = 200f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(Random.Range(-placementJitter, placementJitter), Random.Range(-placementJitter, placementJitter), 0f);

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, moveSpeed * Time.unscaledDeltaTime, 0f);
    }

}
