using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class interactTest : MonoBehaviour
{

    // public GameObject
    public GameObject Cube;
    private Random rnd = new Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor()
    {
        rnd = new Random();
        Cube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        // Cube.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
    }

}
