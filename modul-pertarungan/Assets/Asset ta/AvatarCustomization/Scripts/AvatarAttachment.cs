using UnityEngine;
using System.Collections;

public class AvatarAttachment : MonoBehaviour {

	int hairType, eyesType, mouthType;
	public GameObject hairStyle1, hairStyle2, hairStyle3;
	public GameObject eyeStyle1, eyeStyle2, eyeStyle3;
	public GameObject mouthStyle1, mouthStyle2, mouthStyle3;
	Object hChild, mChild, eChild;

	// Use this for initialization
	void Start () {
		hairType = getHairType ();
		eyesType = getEyesType ();
		mouthType = getMouthType ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int getHairType()
	{
		hairType = 1;
		return hairType;
	}

	int getEyesType()
	{
		eyesType = 1;
		return eyesType;
	}

	int getMouthType()
	{
		mouthType = 1;
		return mouthType;
	}

	void AttachHair(string hairStyleChosen)
	{
		Destroy (hChild);
		var currentPos = this.transform.position;
		if (hairStyleChosen == "menurambut1") 
		{
			var hairStyle =  Instantiate(hairStyle1, currentPos, Quaternion.identity);
			hChild = hairStyle;
			Debug.Log("hairstyle1");
		} else
			if (hairStyleChosen == "menurambut2") 
		{
			var hairStyle =  Instantiate(hairStyle2, currentPos, Quaternion.identity);
			hChild = hairStyle;
			Debug.Log("hairstyle2");
		} else
			if (hairStyleChosen == "menurambut3") 
		{
			var hairStyle =  Instantiate(hairStyle3, currentPos, Quaternion.identity);
			hChild = hairStyle;
			Debug.Log("hairstyle3");
		}
	}

	void AttachEye (string eyeStyleChosen)
	{
		Destroy (eChild);
		var currentPos = this.transform.position;
		if (eyeStyleChosen == "menumata1") 
		{
			var eyeStyle =  Instantiate(eyeStyle1, currentPos, Quaternion.identity);
			eChild = eyeStyle;
			Debug.Log("eyestyle1");
		} else
			if (eyeStyleChosen == "menumata2") 
		{
			var eyeStyle =  Instantiate(eyeStyle2, currentPos, Quaternion.identity);
			eChild = eyeStyle;
			Debug.Log("eyestyle2");
		} else
			if (eyeStyleChosen == "menumata3") 
		{
			var eyeStyle =  Instantiate(eyeStyle3, currentPos, Quaternion.identity);
			eChild = eyeStyle;
			Debug.Log("eyestyle3");
		}
	}

	void AttachMouth (string mouthStyleChosen)
	{
		Destroy (mChild);
		var currentPos = this.transform.position;
		if (mouthStyleChosen == "menumulut1") 
		{
			var mouthStyle =  Instantiate(mouthStyle1, currentPos, Quaternion.identity);
			mChild = mouthStyle;
			Debug.Log("mouthstyle1");
		} else
			if (mouthStyleChosen == "menumulut2") 
		{
			var mouthStyle =  Instantiate(mouthStyle2, currentPos, Quaternion.identity);
			mChild = mouthStyle;
			Debug.Log("mouthstyle2");
		} else
			if (mouthStyleChosen == "menumulut3") 
		{
			var mouthStyle =  Instantiate(mouthStyle3, currentPos, Quaternion.identity);
			mChild = mouthStyle;
			Debug.Log("mouthstyle3");
		}
	}
}
