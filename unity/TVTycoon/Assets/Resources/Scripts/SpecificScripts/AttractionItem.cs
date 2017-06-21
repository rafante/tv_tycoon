using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttractionItem : MonoBehaviour
{
	public Attraction attraction;
	public int attractionId;
	public float updateSpan = 5;
	public Image image, audienceIcon, popularityIcon, adsValueIcon;
	public Text attractionName, audienceTxt, popularityTxt, adsValueTxt, nameLbl;
	public Button btnAttraction, btnCreate;

	void Start()
	{
		updateUI();
	}

	public void set(Attraction attraction)
	{
		if(attraction == null)
			return;
		this.attraction = attraction;
		attractionId = attraction.id;
		/*if (attraction == null)
		{
			updateUI();
			return;
		}
		this.attraction = attraction;
		attractionId = attraction.id;
		updateUI();*/
	}

	public void updateUI()
	{
		bool existent = attractionId > 0 && attraction != null;
		
		btnCreate.gameObject.SetActive(!existent);
		image.gameObject.SetActive(existent);
		attractionName.gameObject.SetActive(existent);
		audienceTxt.gameObject.SetActive(existent);
		popularityTxt.gameObject.SetActive(existent);
		adsValueTxt.gameObject.SetActive(existent);

		audienceIcon.gameObject.SetActive(existent);
		popularityIcon.gameObject.SetActive(existent);
		adsValueIcon.gameObject.SetActive(existent);
		nameLbl.gameObject.SetActive(existent);
		
		if (existent)
		{
			attractionId = attraction.id;
			image.sprite = Resources.Load<Sprite>(attraction.imagePath);
			attractionName.text = attraction.name;
			audienceTxt.text = attraction.audience.ToString();
			popularityTxt.text = attraction.popularity.ToString();
			adsValueTxt.text = attraction.adsValue.ToString();
		}
	}

	public void toggleAttractionData()
	{
		image.gameObject.SetActive(!image.gameObject.activeSelf);
		attractionName.gameObject.SetActive(!attractionName.gameObject.activeSelf);
		audienceTxt.gameObject.SetActive(!audienceTxt.gameObject.activeSelf);
		popularityTxt.gameObject.SetActive(!popularityTxt.gameObject.activeSelf);
		adsValueTxt.gameObject.SetActive(!adsValueTxt.gameObject.activeSelf);
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
			adsValueTxt.text = AttractionsManager.main.getAdsValue(attractionId).ToString();
			
		}
	}
}
