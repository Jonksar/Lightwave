using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BloomController : MonoBehaviour {
	public int specStat1 = 350;
	public int specStat2 = 150;
	public AudioSource audio;
	private float spectrumScale,curveEnhancer = 950f;
	private GameObject[] soundObject;    
	private BloomOptimized bloom;

	// Use this for initialization
	void Start () 
	{
		bloom = gameObject.GetComponent<BloomOptimized> ();
		bloom.intensity = 1;
	}

	// Update is called once per frame
	void Update () 
	{
		float[] spectrum = this.audio.GetSpectrumData (1024, 1, FFTWindow.BlackmanHarris);// you can use other calculations than blackmanharris.

		spectrumScale = 0.2f + 400f * (spectrum[specStat1] + spectrum[specStat2]);
		bloom.intensity = spectrumScale;
	}

	private float SumArray(float[] arr) {
		float res = 0;
		foreach (float el in arr) {
			res += el;
		}
		return res;
	}


	private float MeanArray(float[] arr) {
		float res = 0;
		foreach (float el in arr) {
			res += el;
		}
		return res / arr.Length;
	}
}
