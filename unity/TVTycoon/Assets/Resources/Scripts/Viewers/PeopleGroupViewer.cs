using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PeopleGroupViewer : MonoBehaviour
{

	public PeopleGroup peopleGroup;
	public Text quantity, gender, age, profession;
	
	void OnGUI () {
		if (peopleGroup != null)
		{
			quantity.text = peopleGroup.number.ToString("N1", new CultureInfo("pt-BR"));
			gender.text = peopleGroup.people.gender.ToString();
			age.text = peopleGroup.people.ageGroup.ToString();
			profession.text = peopleGroup.people.profession.ToString();
		}
	}
}
