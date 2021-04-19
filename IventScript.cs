using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IventScript : MonoBehaviour
{
    [SerializeField] GameObject TD,NotePC,SmartPhone,Monitor,StartButton,ListView,SText;
    public static int value = 0,nanido = 1,count=100,dayscount=1;
    public GameObject Abutton;
    public static int tejyun=-1,hanbetu=0,List;
    public static bool kaisi=true;
    public Text SigiText,DaysText;
    
    // Start is called before the first frame update
    void Start()
    {
	SigiText = GameObject.Find("SigiText").GetComponent<Text>();
	DaysText = GameObject.Find("DaysText").GetComponent<Text>();
	SigiText.text = "受付で手順を入手しよう";
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButton(0)) {
            //ここにタップされた時の処理を書く
	    if(TD.activeSelf == true){
		TD.SetActive(false);
		
	    }
      }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("EntryDoor")){
 
            Abutton.SetActive(true);
	    Debug.Log("入口");
	    value = 1;	    
        }
        if(other.gameObject.CompareTag("OutDoor")){
 
            Abutton.SetActive(true);
	    Debug.Log("出口");
	    value = 2;
        }
        if(other.gameObject.CompareTag("CPU")){
 
            Abutton.SetActive(true);
	    Debug.Log("制御");
	    value = 3;
        }
        if(other.gameObject.CompareTag("Listdevice")){
 
            Abutton.SetActive(true);
	    Debug.Log("手順");
	    value = 4;
        }
        if(other.gameObject.CompareTag("InputDevice")){
 
            Abutton.SetActive(true);
	    Debug.Log("入力");
	    value = 5;
        }
	if(other.gameObject.CompareTag("List")){
 
            Abutton.SetActive(true);
	    Debug.Log("データ");
	    value = 6;
        }
	if(other.gameObject.CompareTag("Monitor")){
 
              Abutton.SetActive(true);
	    Debug.Log("モニター");
	    value = 7;
        }

    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("EntryDoor")){
 
            Abutton.SetActive(false);
	    Debug.Log("入口離れた");	    
        }
        if(other.gameObject.CompareTag("OutDoor")){
 
            Abutton.SetActive(false);
	    Debug.Log("出口離れた");
        }
        if(other.gameObject.CompareTag("CPU")){
 
            Abutton.SetActive(false);
	    Debug.Log("制御離れた");
        }
        if(other.gameObject.CompareTag("Listdevice")){
 
            Abutton.SetActive(false);
	    Debug.Log("手順離れた");
        }
        if(other.gameObject.CompareTag("InputDevice")){
 
            Abutton.SetActive(false);
	    Debug.Log("入力離れた");
        }
	if(other.gameObject.CompareTag("List")){
 
            Abutton.SetActive(false);
	    Debug.Log("データ離れた");
        }
	if(other.gameObject.CompareTag("Monitor")){
 
            Abutton.SetActive(false);
	    Debug.Log("モニター離れた");
        }
    }

    public void OnClick()
    {
      if(value == 1){
	  if(HaisouScript.count == tejyun){
		hanbetu = 0;
		HaisouScript.pc = 0;
		HaisouScript.TejyunSE = true;
		kaisi=true;
		if(HaisouScript.Slevel != 3){	//難易度の設定
		   HaisouScript.Slevel++;
		   nanido++;
		}else{
		   nanido=Random.Range (1,4);
		}
		Debug.Log("ネクストデイ");
		dayscount++;
		DaysText.text = dayscount.ToString()+"日目";
		if(dayscount == 1){
			SText.SetActive(false);
		}
	  }else{
		Debug.Log("まだ帰るわけにはいかない");
	  }
	  
      	}
     	else if(value == 2){
     	}
     	else if(value == 3){

	  if(kaisi == true){
	　	StartButton.SetActive(true);
	  }else{
		SmartPhone.SetActive(true);
	  }

     	}
      	else if(value == 4){
	  if(hanbetu == 1){
	  	NotePC.SetActive(true);
	  }
      	}
      	else if(value == 5){
	  Debug.Log("o="+HaisouScript.o + "h="+HaisouScript.h + "now=" + HaisouScript.now + "Tejyun=" + HaisouScript.TejyunSE);
	  if(((HaisouScript.now == 1 && HaisouScript.h == false) || (HaisouScript.now == 2 && HaisouScript.o == false) || (HaisouScript.now == 3 && HaisouScript.h == false)) && HaisouScript.TejyunSE == false){
	  	ListView.SetActive(true);
	  	HaisouScript.TejyunSE = true;
		count = HaisouScript.pc;
		Debug.Log("リスト表示");
		if(HaisouScript.now == 2){
			SigiText.text = "荷物を送るか決めよう";
		}else{
			SigiText.text = "次の手順を確認しよう";
		}
	  }
      	}
	else if(value == 6){
	  if(hanbetu == 0){				//難易度によって手順数を決める
		    if(nanido == 1){
		    	tejyun=Random.Range (5,7);
		    }
		    else if(nanido == 2){
			tejyun=Random.Range (7,9);
		    }
		    else{
			tejyun=Random.Range (9,11);
		    }
		    Debug.Log("手順"+tejyun);
	            TD.SetActive(true);
		    hanbetu++;
		    SigiText.text = "保存庫でデータを入力しよう";
	  }else{
	    Debug.Log("すでに手順は取得しているようだ");
	  }
      	}
	else{
	  Monitor.SetActive(true);
	  if(HaisouScript.now == 1){
	　	SigiText.text = "制御装置で荷物を受け取ろう";
	  }
	  else if(HaisouScript.now == 2){
		SigiText.text = "右の装置で送る荷物の確認をしよう";
	  }
	  else if(HaisouScript.now == 3){
		SigiText.text = "右の装置で誤送を確認しよう";
	  }
	  else if(HaisouScript.now == 4){
		SigiText.text = "帰宅しよう";
	  }else{
		SigiText.text = "次の手順を見よう";
	  }
	}
	Abutton.SetActive(false);
    }    

    public void StartClick(){
    	SmartPhone.SetActive(true);
	StartButton.SetActive(false);
	kaisi = false;
	SigiText.text = "手順を入手しよう";
	//業務開始ボタンON
    }


    public void OnBatu(){
	if(SmartPhone.activeSelf == true){
		SmartPhone.SetActive(false);
	}
	if(NotePC.activeSelf == true){
		NotePC.SetActive(false);
	}
	if(Monitor.activeSelf == true){
		Monitor.SetActive(false);
		if(HaisouScript.gamestatus == false){
			SceneManager.LoadScene("GameOverScene"); 
		}
	}	
    }
 
}
