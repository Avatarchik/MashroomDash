﻿using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    void Awake () {
        Camera cam = gameObject.GetComponent<Camera>();
        float baseAspect = 640f/1136f;
        float nowAspect = (float)Screen.height/(float)Screen.width;
        float changeAspect;

        if(baseAspect>nowAspect){   
            changeAspect = nowAspect/baseAspect;
            cam.rect=new Rect((1-changeAspect)*0.5f,0,changeAspect,1);
        }else{
            changeAspect = baseAspect/nowAspect;
            cam.rect=new Rect(0,(1-changeAspect)*0.5f,1,changeAspect);
        }
        Destroy(this);
    }
}
    