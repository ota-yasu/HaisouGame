using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TejyunScript : MonoBehaviour
{
     [SerializeField] GameObject NotePC;
    public Text Tejyuntext,SigiText;
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
	SigiText = GameObject.Find("SigiText").GetComponent<Text>();
	Tejyuntext = GameObject.Find("Kazu").GetComponent<Text>();
	inputField = inputField.GetComponent<InputField> ();
    }

    // Update is called once per frame
    void Update()
    {

	Tejyuntext.text = IventScript.tejyun.ToString();

	
    }
    public void OnClick()
    {
	Debug.Log(inputField.ToString());
	if(IventScript.tejyun.ToString() == inputField.text && IventScript.hanbetu == 1){
		Debug.Log("手順が"+ inputField.text + "セットされた");
		NotePC.SetActive(false);
		IventScript.hanbetu++;
		SigiText.text = "制御装置で業務を始めよう";
	}	
    }
}
