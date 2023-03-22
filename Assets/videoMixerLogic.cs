using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoMixerLogic : MonoBehaviour
{
    public GameObject preview,live;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void switchLiveSource(Material sourceMat) 
    {
        //TODO: GameObject live source verranderen naar source, dit doen door de texture te verranderen
        // of door meerdere planes met alle cams erop te hebben staan te switchen van hun 'active' state
        // live.render.material = sourceMat;
        live.GetComponent<MeshRenderer> ().material = sourceMat;


    }
}
