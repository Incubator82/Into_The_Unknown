using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		var obj = gameObject.GetComponentInParent<Transform>().parent.name;
		int x = int.Parse(obj.Substring(obj.IndexOf('_')+1));
		//var objName = other.GetComponentInParent<Transform>().name;

		if(x <= 3) {
			var check = QuestionController._lvl1[x - 1];
			if (check == 1)
				transform.gameObject.tag = "Untagged";
		}

		if (x >= 4 && x <= 9) {
			var check = QuestionController._lvl2[x - 3 - 1];
			if (check == 1)
				transform.gameObject.tag = "Untagged";
		}

		if (x >= 10) {
  			var check = QuestionController._lvl3[x - 3 - 6 - 1];
			if (check == 1)
				transform.gameObject.tag = "Untagged";
		}


		//switch (other.gameObject.tag) {
		//	case "QuestionStart":
		//	//int x = 0;
		//	break;
		//	default:
		//	break;
		//}
	}
}
