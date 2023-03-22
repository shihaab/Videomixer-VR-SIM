using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refreshratechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(60f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
