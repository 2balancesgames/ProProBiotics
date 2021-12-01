using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StatusButton : MonoBehaviour {
	private Button btn;
	void Start () {
		btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		GameManager.instance.PauseGame();
	}
}