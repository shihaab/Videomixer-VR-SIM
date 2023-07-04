using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class VideoMixerLogicPC : MonoBehaviour
{
    public GameObject preview, live, tvlive;
    [SerializeField] public Button[] btnP;
    [SerializeField] public Button[] btnL;
    [SerializeField] public GameObject[] Cams;
    public Material normalMat, selectedMatLive, selectedMatPreview;
    Material matLive, matPreview;
    int btnLive, btnPreview;
    ColorBlock colors;
    int btnIndex;
    bool isPaused = true;

    public void switchLiveSource(Material sourceMat)
    {
        live.GetComponent<MeshRenderer>().material = sourceMat;
        tvlive.GetComponent<MeshRenderer>().material = sourceMat;
        matLive = sourceMat;
    }

    public void switchPreviewSource(Material sourceMat)
    {
        preview.GetComponent<MeshRenderer>().material = sourceMat;
        matPreview = sourceMat;
    }

    // only visual
    public void selectBtn(Button button)
    {
        btnLive = setColor(btnL, Color.red, button);
    }
    // only visual
    public void selectBtnPreview(Button button)
    {
        btnPreview = setColor(btnP, Color.green, button);
    }
    int setColor(Button[] btn,Color a, Button button)
    {
        for (int i = 0; i < btn.Length; i++)
        {
            ColorBlock colors = btn[i].colors;
            colors.normalColor = Color.white;
            btn[i].colors = colors;
            if (Button.ReferenceEquals(btn[i], button))
            {
                btnIndex = i;
            }
        }
        print(btnIndex);

        ColorBlock colorsa = button.colors;
        colorsa.normalColor = a;
        button.colors = colorsa;
        return btnIndex;
    }

    // switch live and preview
    public void cut()
    {
        if (matPreview != null && matLive != null)
        {
            setColor(btnL, Color.red, btnL[btnPreview]);
            setColor(btnP, Color.green, btnP[btnLive]);
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

    public void resetVideo()
    {
        if(isPaused)
        {
            for (int i = 0; i < Cams.Length; i++)
            {
                Cams[i].GetComponent<VideoPlayer>().enabled = true;
            }
            isPaused = false;
        } else
        {
            for (int i = 0; i < Cams.Length; i++)
            {
                Cams[i].GetComponent<VideoPlayer>().enabled = false;
            }
            isPaused = true;
        }
        
    }
}
