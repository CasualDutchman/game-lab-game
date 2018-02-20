using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	void Start () {
		
	}
	
	public void OnBuildingClick() {
        Debug.Log("Clicked " + gameObject.name);
    }
}
