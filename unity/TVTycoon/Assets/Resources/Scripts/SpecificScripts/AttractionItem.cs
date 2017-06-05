using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttractionItem : MonoBehaviour
{
	public int attractionId;
	public float updateSpan = 5;
	public Image image;
	public Text attractionName, audienceTxt, popularityTxt, valueTxt;

	void Start()
	{
		//StartCoroutine(updateValues());
	}

	public void toggleAttractionData()
	{
		image.gameObject.SetActive(!image.gameObject.activeSelf);
		attractionName.gameObject.SetActive(!attractionName.gameObject.activeSelf);
		audienceTxt.gameObject.SetActive(!audienceTxt.gameObject.activeSelf);
		popularityTxt.gameObject.SetActive(!popularityTxt.gameObject.activeSelf);
		valueTxt.gameObject.SetActive(!valueTxt.gameObject.activeSelf);
	}

	IEnumerator updateValues()
	{
		while (true)
		{
			yield return new WaitForSeconds(updateSpan);
			if(attractionId == 0)
				continue;
			
			image.sprite = AttractionsManager.main.getImage(attractionId);
			attractionName.text = AttractionsManager.main.getName(attractionId);
			audienceTxt.text = AttractionsManager.main.getAudience(attractionId).ToString();
			popularityTxt.text = AttractionsManager.main.getPopularity(attractionId).ToString();
			valueTxt.text = AttractionsManager.main.getValue(attractionId).ToString();
			
		}
	}
}
