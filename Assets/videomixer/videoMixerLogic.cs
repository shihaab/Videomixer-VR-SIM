using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoMixerLogic : MonoBehaviour
{
    public GameObject preview,live,tvlive,btn1P,btn2P,btn3P,btn4P,btn5P,btn1L,btn2L,btn3L,btn4L,btn5L;
    public Material normalMat,selectedMatLive,selectedMatPreview;
    Material matLive,matPreview;


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
        live.GetComponent<MeshRenderer> ().material = sourceMat;
        tvlive.GetComponent<MeshRenderer> ().material = sourceMat;
        matLive = sourceMat;
    }

    public void switchPreviewSource(Material sourceMat) 
    {
        preview.GetComponent<MeshRenderer> ().material = sourceMat;
        matPreview = sourceMat;
    }

    // only visual
    public void selectBtn(GameObject button) 
    {
        btn1L.GetComponent<Renderer>().material = normalMat;
        btn2L.GetComponent<Renderer>().material = normalMat;
        btn3L.GetComponent<Renderer>().material = normalMat;
        btn4L.GetComponent<Renderer>().material = normalMat;
        btn5L.GetComponent<Renderer>().material = normalMat;
        button.GetComponent<Renderer>().material = selectedMatLive;
        
    }
    // only visual
    public void selectBtnPreview(GameObject button) 
    {
        btn1P.GetComponent<Renderer>().material = normalMat;
        btn2P.GetComponent<Renderer>().material = normalMat;
        btn3P.GetComponent<Renderer>().material = normalMat;
        btn4P.GetComponent<Renderer>().material = normalMat;
        btn5P.GetComponent<Renderer>().material = normalMat;
        button.GetComponent<Renderer>().material = selectedMatPreview;
        
    }

    // switch live and preview
    public void cut() 
    {
        if(matPreview!=null && matLive!=null) 
        {
            // preview to live
            live.GetComponent<MeshRenderer> ().material = matPreview;
            tvlive.GetComponent<MeshRenderer> ().material = matPreview;
            // live to preview
            preview.GetComponent<MeshRenderer> ().material = matLive;
        }
        
    }
}
