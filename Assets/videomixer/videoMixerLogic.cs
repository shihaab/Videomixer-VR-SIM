using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoMixerLogic : MonoBehaviour
{
    public GameObject preview,live,tvlive,btn1P,btn2P,btn3P,btn4P,btn5P,btn6P,btn1L,btn2L,btn3L,btn4L,btn5L,btn6L;
    public Material normalMat,selectedMatLive,selectedMatPreview;
    Material matLive,matPreview;
    //GameObject btnLive,btnPreview;

    [SerializeField] public GameObject[] ArrbtnP;
    [SerializeField] public GameObject[] ArrbtnL;
    int btnLive, btnPreview;
    ColorBlock colors;
    int btnIndex;

    [SerializeField] public GameObject[] Cams;
    bool isPaused = true;


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

    //// only visual
    //public void selectBtn(GameObject button) 
    //{
    //    btn1L.GetComponent<Renderer>().material = normalMat;
    //    btn2L.GetComponent<Renderer>().material = normalMat;
    //    btn3L.GetComponent<Renderer>().material = normalMat;
    //    btn4L.GetComponent<Renderer>().material = normalMat;
    //    btn5L.GetComponent<Renderer>().material = normalMat;
    //    btn6L.GetComponent<Renderer>().material = normalMat;
    //    button.GetComponent<Renderer>().material = selectedMatLive;

    //    btnLive = button;
    //}
    //// only visual
    //public void selectBtnPreview(GameObject button) 
    //{
    //    btn1P.GetComponent<Renderer>().material = normalMat;
    //    btn2P.GetComponent<Renderer>().material = normalMat;
    //    btn3P.GetComponent<Renderer>().material = normalMat;
    //    btn4P.GetComponent<Renderer>().material = normalMat;
    //    btn5P.GetComponent<Renderer>().material = normalMat;
    //    btn6P.GetComponent<Renderer>().material = normalMat;
    //    button.GetComponent<Renderer>().material = selectedMatPreview;

    //    btnPreview = button;
    //}

    //public void selectBtnLiveDebug(GameObject button)
    //{
    //    btn1L.GetComponent<Renderer>().material = normalMat;
    //    btn2L.GetComponent<Renderer>().material = normalMat;
    //    btn3L.GetComponent<Renderer>().material = normalMat;
    //    btn4L.GetComponent<Renderer>().material = normalMat;
    //    btn5L.GetComponent<Renderer>().material = normalMat;
    //    btn6L.GetComponent<Renderer>().material = normalMat;


    //    button.GetComponent<Renderer>().material = selectedMatLive;

    //    btnLive = button;
    //}
    //public void selectBtnPreviewDebug(GameObject button)
    //{
    //    button.GetComponent<Renderer>().material = selectedMatPreview;

    //    btnPreview = button;
    //}

    // only visual
    public void selectBtn(GameObject button)
    {
        btnLive = setColor(ArrbtnL, selectedMatLive, button);
    }
    // only visual
    public void selectBtnPreview(GameObject button)
    {
        btnPreview = setColor(ArrbtnP, selectedMatPreview, button);
    }
    int setColor(GameObject[] btn, Material a, GameObject button)
    {
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].GetComponent<Renderer>().material = normalMat;
            if (GameObject.ReferenceEquals(btn[i], button))
            {
                btnIndex = i;
            }
        }
        print(btnIndex);

        button.GetComponent<Renderer>().material = a;
        return btnIndex;
    }
    // switch live and preview
    public void cut()
    {
        if (matPreview != null && matLive != null)
        {
            setColor(ArrbtnL, selectedMatLive, ArrbtnL[btnPreview]);
            setColor(ArrbtnP, selectedMatPreview, ArrbtnP[btnLive]);
            int btnPTemp = btnPreview;
            int btnLTemp = btnLive;
            btnPreview = btnLTemp;
            btnLive = btnPTemp;
            live.GetComponent<MeshRenderer>().material = matPreview;
            tvlive.GetComponent<MeshRenderer>().material = matPreview;
            preview.GetComponent<MeshRenderer>().material = matLive;
            Material tempP = matPreview;
            Material tempL = matLive;
            matPreview = tempL;
            matLive = tempP;
        }

    }

    //// switch live and preview
    //public void cut() 
    //{
    //    if(matPreview!=null&&matLive!=null) 
    //    {
    //        GameObject tempBtnP = btnPreview;
    //        GameObject tempBtnL = btnLive;

    //        // preview to live
    //        live.GetComponent<MeshRenderer> ().material = matPreview;
    //        tvlive.GetComponent<MeshRenderer> ().material = matPreview;

    //        if(GameObject.ReferenceEquals(tempBtnL,btn1L)) {
    //            selectBtnPreview(btn1P);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnL,btn2L)) {
    //            selectBtnPreview(btn2P);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnL,btn3L)) {
    //            selectBtnPreview(btn3P);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnL,btn4L)) {
    //            selectBtnPreview(btn4P);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnL,btn5L)) {
    //            selectBtnPreview(btn5P);
    //        }
    //        else if (GameObject.ReferenceEquals(tempBtnL, btn6L))
    //        {
    //            selectBtnPreview(btn6P);
    //        }
    //        Debug.Log(btnLive.GetComponent<Renderer>().material);

    //        // live to preview
    //        preview.GetComponent<MeshRenderer> ().material = matLive;

    //        if(GameObject.ReferenceEquals(tempBtnP,btn1P)) {
    //            selectBtn(btn1L);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnP,btn2P)) {
    //            selectBtn(btn2L);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnP,btn3P)) {
    //            selectBtn(btn3L);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnP,btn4P)) {
    //            selectBtn(btn4L);
    //        }
    //        else if(GameObject.ReferenceEquals(tempBtnP,btn5P)) {
    //            selectBtn(btn5L);
    //        }
    //        else if (GameObject.ReferenceEquals(tempBtnP, btn6P))
    //        {
    //            selectBtn(btn6L);
    //        }

    //        Material tempP = matPreview;
    //        Material tempL = matLive;
    //        matPreview = tempL;
    //        matLive = tempP;
    //    }

    //}

    public void resetVideo()
    {
        if (isPaused)
        {
            for (int i = 0; i < Cams.Length; i++)
            {
                Cams[i].GetComponent<VideoPlayer>().enabled = true;
            }
            isPaused = false;
        }
        else
        {
            for (int i = 0; i < Cams.Length; i++)
            {
                Cams[i].GetComponent<VideoPlayer>().enabled = false;
            }
            isPaused = true;
        }

    }
}
