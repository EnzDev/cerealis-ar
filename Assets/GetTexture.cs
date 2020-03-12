using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTexture : MonoBehaviour {

    private RegionCapture regionCapture;
    private Camera RenderTextureCamera;
    [Space(20)]
    public GameObject Region_Capture;
    public bool FreezeEnable = false;
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    void Start () {
        RenderTextureCamera = Region_Capture.GetComponentInChildren<Camera>();

        regionCapture = Region_Capture.GetComponent<RegionCapture> ();

        Console.Out.WriteLine("Starting region capture !");
        
        if (FreezeEnable) {
            regionCapture.Check_OutOfBounds = true;
        }

        StartCoroutine(WaitForTexture());

    }

    private IEnumerator WaitForTexture() {

        yield return new WaitForEndOfFrame ();

        if (RenderTextureCamera.targetTexture) {
            GetComponent<Renderer> ().material.SetTexture (MainTex, RenderTextureCamera.targetTexture);
        }
        else StartCoroutine(WaitForTexture());

    }

    void LateUpdate () {

        // if (FreezeEnable && regionCapture.)
        //     RenderTextureCamera.enabled = false;

        // RenderTextureCamera.enabled = true;
    }
}