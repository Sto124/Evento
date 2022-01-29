using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour {

	[SerializeField]
	Text codeText;
	string codeTextValue = "";

	// Update is called once per frame
	void Update () {
		codeText.text = codeTextValue;

		if (codeTextValue == "ðß§") {
			Cat.isSafeOpened = true;
		}

		if (codeTextValue.Length >= 3)
			codeTextValue = "";
	}

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

}
