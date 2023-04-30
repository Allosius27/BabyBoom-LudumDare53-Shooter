using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCarSwitch : MonoBehaviour
{
    public List<Color> colorPosibility;
    public Material carMaterial;

    // Start is called before the first frame update
    void Start()
    {
        carMaterial = gameObject.GetComponent<Renderer>().material;
        Debug.Log(colorPosibility.Count);
        int rng = Random.Range(0, colorPosibility.Count);
        carMaterial.color = colorPosibility[rng];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
