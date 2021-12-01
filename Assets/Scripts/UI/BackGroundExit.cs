using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class BackGroundExit : MonoBehaviour {
	private Button btn;
	void Start () {
		btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		GameManager.instance.ContinueGame();
	}
}