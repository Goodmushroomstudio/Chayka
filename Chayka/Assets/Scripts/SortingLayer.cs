using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SortingLayer : MonoBehaviour {
	public Renderer MyRenderer;
	public string MySortingLayer = "3";
	public int MySortingOrderInLayer = 0;

	void Start () {
		if (MyRenderer == null)
			MyRenderer = this.GetComponent<Renderer>();
	}

	void Update () {
		if (MyRenderer == null)
			MyRenderer = this.GetComponent<Renderer>();
		MyRenderer.sortingLayerName = MySortingLayer;
		MyRenderer.sortingOrder = MySortingOrderInLayer;
	}   
}
