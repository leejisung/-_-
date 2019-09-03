using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test : MonoBehaviour {

	public int _exp = 0;

	void Start () {
		List<Dictionary<string,object>> data = CSVReader.Read("save");

		for(var i=0; i< data.Count; i++){
			Debug.Log("index " + (i).ToString() + " : " + data[i]["atk"] + " " + data[i]["def"] + " " + data[i]["tec"]);
		}

		_exp = (int)data[0]["EXP"];
		Debug.Log(_exp);
	}
}
