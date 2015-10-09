﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lampGlow : MonoBehaviour {

	public Color colorStart = Color.white;
	public Color colorEnd = Color.black;
    //public Color colPstart;
    //public ParticleSystem rendParticles;
    //public Color colPend;
    public Renderer rend;
    //public float duration = 1.0F;
	public float intencity;
    public bool isOn = true;
    //private Particle particles;
    //public Color startColor;

    public void toggle(bool b) {
        isOn = b;
    }
    void Start () {
		rend = GetComponentInChildren<Renderer>();
       // rendParticles = GetComponentInChildren<ParticleSystem>();
     /*   colPstart = rendParticles.GetComponent<ParticleSystem>().startColor;
        colPstart = new Color(0, 0, 0, 1.0f);
        colPend = rendParticles.GetComponent<ParticleSystem>().startColor;
        colPend= new Color(1.0f, 1.0f, 1.0f, 1.0f);
      */  
    }

    void Update() {
        rend.enabled = false;
        if (isOn) {
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorStart, colorEnd, PathTracer.nearestP);
            //rendParticles.startColor = Color.Lerp(colPstart, colPend, PathTracer.nearestP);
        }
    }
}
