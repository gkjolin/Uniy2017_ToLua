using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public Shader shader;
	// Use this for initialization
	void Start () {
        
        GetComponent<Image>().material = Util.CreateMat("Assets/Shaders/Proj/Effect/effect_ui_grey.shader");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
