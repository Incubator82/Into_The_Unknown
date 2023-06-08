using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;
using System;

public class QuestionController : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private AudioSource _audioSource;
	[SerializeField] private AudioClip audioFon;
	[SerializeField] private AudioClip audioAlarm;

	public static byte[] _lvl1;
	public static byte[] _lvl2;
	public static byte[] _lvl3;

	//[SerializeField] private GameObject camera;
	//private Quaternion _startRotationCamera;

	private Vector3 _startPositionPlayer;
	private Quaternion _startRotationPlayer;
	void Start() {

		StartLvl();

		_audioSource = GetComponent<AudioSource>();
		_startPositionPlayer = player.transform.position;
		_startRotationPlayer = player.transform.rotation;
		//_startRotationCamera = camera.transform.rotation;
	}

	public static List<T> Randomize<T>(List<T> list) {
		List<T> randomizedList = new List<T>();
		Random rnd = new Random();
		while (list.Count > 0) {
			int index = rnd.Next(0, list.Count); //pick a random item from the master list
			randomizedList.Add(list[index]); //place it at the end of the randomized list
			list.RemoveAt(index);
		}
		return randomizedList;
	}

	void Shuffle<T>(T[] array) {
		var r = new Random();
		for (int i = array.Length - 1; i > 0; i--) {
			int j = r.Next(i);
			T t = array[i];
			array[i] = array[j];
			array[j] = t;
		}
	}

	void StartLvl() {

		List<int> listInt1 = new List<int> { 1, 2, 3 };
		List<int> listInt2 = new List<int> { 1, 2, 3, 4, 5, 6 };
		List<int> listInt3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
		var randListInt1 = Randomize(listInt1);
		var randListInt2 = Randomize(listInt2);
		var randListInt3 = Randomize(listInt3);

		bool delta_lvl1 = false;
		bool delta_lvl2 = false;
		bool delta_lvl3 = false;

		_lvl1 = new byte[3];
		_lvl2 = new byte[6];
		_lvl3 = new byte[12];

		byte countRows1 = 0;
		byte countRows2 = 0;
		byte countRows3 = 0;


		foreach (var item in randListInt1) {
			++countRows1;
			if (delta_lvl1) {
				_lvl1[item-1] = 0;
				continue;
			}
			var rnd = UnityEngine.Random.Range(0, 2);
			if (rnd == 1) {
				delta_lvl1 = true;
				_lvl1[item - 1] = 1;
			}
			else
				_lvl1[item - 1] = 0;

			if (countRows1 == 3 && !delta_lvl1)
				_lvl1[2] = 1;

		}

		foreach (var item in randListInt2) {
			++countRows2;
			if (delta_lvl2) {
				_lvl2[item - 1] = 0;
				continue;
			}
			var rnd = UnityEngine.Random.Range(0, 2);
			if (rnd == 1) {
				delta_lvl2 = true;
				_lvl2[item - 1] = 1;
			} else
				_lvl2[item - 1] = 0;

			if (countRows2 == 6 && !delta_lvl2)
				_lvl2[2] = 1;

		}

		foreach (var item in randListInt3) {
			++countRows3;
			if (delta_lvl3) {
				_lvl3[item - 1] = 0;
				continue;
			}
			var rnd = UnityEngine.Random.Range(0, 2);
			if (rnd == 1) {
				delta_lvl3 = true;
				_lvl3[item - 1] = 1;
			} else
				_lvl3[item - 1] = 0;

			if (countRows3 == 12 && !delta_lvl3)
				_lvl3[2] = 1;

		}
		////for (int i = 0; i < 3; i++) {
		////	if (delta_lvl1) {
		////		_lvl1[i] = 0;
		////		continue;
		////	}

		////	var rnd = UnityEngine.Random.Range(0, 2);
		////	if (rnd == 1) {
		////		delta_lvl1 = true;
		////		_lvl1[randListInt1[i]-1] = 1;
		////	}
		////	else
		////		_lvl1[randListInt1[i] - 1] = 0;

		////	if(i == 2)
		////		_lvl1[i] = 1;

		////	//if (delta_lvl1) {
		////	//	_lvl1[i] = 0;
		////	//	continue;
		////	//}
		////	//var rnd = UnityEngine.Random.Range(0, 2);
		////	//if (rnd == 1) {
		////	//	delta_lvl1 = true;
		////	//}

		////	//if(i == 2)
		////	//	_lvl1[i] = 1;
		////	//else
		////	//	_lvl1[i] = byte.Parse(rnd.ToString());
		////}

		//for (int i = 0; i < 6; i++) {
		//	if (delta_lvl2) {
		//		_lvl2[i] = 0;
		//		continue;
		//	}
		//	var rnd = UnityEngine.Random.Range(0, 2);
		//	if (rnd == 1) {
		//		delta_lvl2 = true;
		//	}

		//	if (i == 2)
		//		_lvl2[i] = 1;
		//	else
		//		_lvl2[i] = byte.Parse(rnd.ToString());
		//}

		//for (int i = 0; i < 12; i++) {
		//	if (delta_lvl3) {
		//		_lvl3[i] = 0;
		//		continue;
		//	}
		//	var rnd = UnityEngine.Random.Range(0, 2);
		//	if (rnd == 1) {
		//		delta_lvl3 = true;
		//	}

		//	if (i == 2)
		//		_lvl3[i] = 1;
		//	else
		//		_lvl3[i] = byte.Parse(rnd.ToString());
		//}

		var tst = _lvl1;
		var tst2 = _lvl2;
		var tst3 = _lvl3;

		if (Convert.ToByte(_lvl1.Sum(_ => _)) == 0)
			_lvl1[2] = 1;

		if (Convert.ToByte(_lvl2.Sum(_ => _)) == 0)
			_lvl2[5] = 1;

		if (Convert.ToByte(_lvl3.Sum(_ => _)) == 0)
			_lvl3[11] = 1;
	}

	private void Update() {
		if (!_audioSource.isPlaying) {
			_audioSource.PlayOneShot(audioFon);
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void OnCollisionEnter(Collision collision) {
		var obj = gameObject.name;
		switch (collision.gameObject.tag) {
			case "QuestionStart":
			if (obj == "ThirdPersonController_LITE") {
				int x = 0;
			}
			break;
			case "Exit":
			if (obj == "ThirdPersonController_LITE") {
				SceneManager.LoadScene(2);
			}
			break;
			default:
			break;
		}
	}

	private void OnTriggerEnter(Collider other) {
		var obj = gameObject.name;
		var objName = other.GetComponentInParent<Transform>().name;

		//var t1 = other.pa transform.parent.GetComponent<Transform>();
		var t2 = other.GetComponentInParent<Transform>();
		var x = t2.parent.name;

		switch (other.gameObject.tag) {
			case "QuestionStart":
			_audioSource.PlayOneShot(audioAlarm);
			player.transform.position = _startPositionPlayer;
			player.transform.rotation = _startRotationPlayer;
			//camera.transform.rotation = _startRotationCamera;
			break;
			default:
			break;
		}
	}
}
