using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HaisouScript : MonoBehaviour
{
    [SerializeField] GameObject List,Monitor,SelectView,SmartPhone;
    public static int pc=0,Slevel=1,now;
    public static bool TejyunSE = true,h=true,o=true,gamestatus=true;
    public static int count = 0;
    int [] gyoumu = new int[10];
    int [,] zaiko = new int[5,2] {{25,25},{25,25},{25,25},{25,25},{25,25}};
    string [,] nimotu = new string[5,3] {{"小物","キーホルダー","アクセサリー"},{"書籍","漫画","雑誌"},{"電子媒体","ゲーム","DVD"},{"コスプレ用品","衣類","ウィッグ"},{"壊れ物","フィギュア","食器"}};
    int level,num,cat,srow,inp,end=4,i,ransu=0,ransu2=0,LC,LP,LQ;
    public InputField programcount;
    public Text MonitorText,Class,PName,Quantity,SigiText;
    // Start is called before the first frame update
    void Start()
    {
	programcount = GameObject.Find("countField").GetComponent<InputField>();
	MonitorText = GameObject.Find("MonitorText").GetComponent<Text>();
	Class = GameObject.Find("Class").GetComponent<Text>();
	PName = GameObject.Find("ProductName").GetComponent<Text>();
	Quantity = GameObject.Find("Quantity").GetComponent<Text>();
	SigiText = GameObject.Find("SigiText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnClickTejyun(){
	//手順の取得
	if(TejyunSE == true && gamestatus == true){
		o=true;
		h=true;
		if(count - pc == 0){
			now = gyoumu[pc];
			if(gyoumu[pc] == 1){
				Debug.Log("受け取り");
				MonitorText.text = "荷物が来たようだ...";

			}
			else if(gyoumu[pc] == 2){
				Debug.Log("配送");
				MonitorText.text = "配送の指示が入った";
				LC = Random.Range(0,5);
				LP = Random.Range(1,3);
				LQ = Random.Range(1,5*IventScript.dayscount);
				Class.text = nimotu[LC,0];
				PName.text = nimotu[LC,LP];
				Quantity.text = LQ.ToString();
				o = false;
			}
			else if(gyoumu[pc] == 3){
				Debug.Log("ミス");
				MonitorText.text = "配送の途中でミスがあったようだ";
				LC = Random.Range(0,5);
				LP = Random.Range(1,3);
				LQ = Random.Range(1,5*IventScript.dayscount);
				Class.text = nimotu[LC,0];
				PName.text = nimotu[LC,LP];
				Quantity.text = LQ.ToString();
				zaiko[LC,LP-1] -= LQ;
				if(zaiko[LC,LP-1] < 0){
					gamestatus = false;
				}			
				Debug.Log("在庫は:"+zaiko[LC,LP-1]);
				o=false;
				h=false;
			}
			else{
				Debug.Log("業務終了");
				MonitorText.text = "業務終了";
				SigiText.text = "帰宅しよう";
				
			}
			SigiText.text = "正面にあるモニターで確認しよう";
			TejyunSE = false;
			count++;
		}else if(gamestatus == false){
			MonitorText.text = "経営失格";
		}else{
			Debug.Log("同じやないかい");
		}


	}
	
    }
    public void OnClickUketori(){
	//荷物の受け取り
	if(gyoumu[pc] == 1 && h == true){
		ransu = Random.Range(0,5);
		ransu2 = Random.Range(1,3);
		Class.text = nimotu[ransu,0];
		PName.text = nimotu[ransu,ransu2];
		Quantity.text = Random.Range(1,6*IventScript.dayscount).ToString();
		zaiko[ransu,ransu2-1] += int.Parse(Quantity.text);
		Debug.Log("在庫は:"+zaiko[ransu,ransu2-1]);
		h = false;
		SigiText.text = "右の装置で受け取る荷物の確認をしよう";
	}
    }
    public void OnClickHaisou(){
	//荷物を送る
	if(gyoumu[pc] == 2 && o == false){
		SelectView.SetActive(true);
		SmartPhone.SetActive(false);
		o = true;

	}
    }

    public void MakeSagyou(){
	//業務開始ボタンが押されたら
	//業務内容を作成するプログラム
	//作業の内容　1:受け取り, 2:ミス, 3:配送, 4:業務終了
	if(IventScript.hanbetu == 2){
		level = IventScript.nanido;
		num = IventScript.tejyun;
		gyoumu[num-1]=end;		//業務終了の所に終了の値を入れる
		if(level == 1){
			while(cat+srow+inp != num-1){
				cat = Random.Range(1,3);
				srow = Random.Range(1,3);
				inp = Random.Range(0,2);
			}
		}
		else if(level == 2){
			while(cat+srow+inp != num-1){
				cat = Random.Range(2,4);
				srow = Random.Range(2,4);
				inp = Random.Range(0,2);
			}
		}
		else{
			while(cat+srow+inp != num-1){
				cat = Random.Range(2,5);
				srow = Random.Range(3,6);
				inp = Random.Range(2,4);
			}
		}
		Debug.Log("受け取り:"+cat+"配達:"+srow+"ミス:"+inp);
		for(i=0;i<num-1;i++){
			if(Slevel != 3){

			  if(i+1 <= cat){
				gyoumu[i] = 1;
			  }else{	
				ransu = Random.Range(0,srow*10+inp*10);
				if(ransu < srow*10){
					gyoumu[i] = 2;
					srow--;
				}else{
					gyoumu[i] = 3;
					inp--;
				}
			  }	

			}else{
				ransu = Random.Range(0,cat*10+srow*10+inp*10);
				if(ransu < cat*10){
					gyoumu[i] = 1;
					cat--;
				}else if(ransu < cat*10+srow*10){
					gyoumu[i] = 2;
					srow--;
				}else{
					gyoumu[i] = 3;
					inp--;
				}
			  
			}
		Debug.Log("作業"+i+"個目は"+gyoumu[i]);
		}
		Debug.Log("作業は"+gyoumu[i]);
	}
    }


    public void InputPC(){
	pc = int.Parse(programcount.text);
    }

    public void SelectYes(){
	zaiko[LC,LP-1] -= LQ;
	if(zaiko[LC,LP-1] < 0){
		gamestatus = false;
	}
	Debug.Log("在庫残り:"+zaiko[LC,LP-1]);
	TejyunSE=true;
	SelectView.SetActive(false);
	SmartPhone.SetActive(true);
	SigiText.text = "次の手順を取得しよう";
    }

    public void SelectNo(){
	Debug.Log("在庫残り:"+zaiko[LC,LP-1]);
	if(zaiko[LC,LP-1]-LQ < 0){
		Debug.Log("正しい選択だったようだ");
	}
	TejyunSE=true;
	SelectView.SetActive(false);
	SmartPhone.SetActive(true);
	SigiText.text = "次の手順を取得しよう";
    }

    public void OnBatu(){
	if(List.activeSelf == true){
		List.SetActive(false);
	}
    }

}
