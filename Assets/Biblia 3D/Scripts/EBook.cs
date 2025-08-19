using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EBook : MonoBehaviour {

	public List<GameObject> pages;

	public int atualPage = 0;

	public void Back ()
	{
		pages [atualPage].SetActive (false);
		if (atualPage == 0)
			atualPage = pages.Count - 1;
		else
			atualPage -= 1;
		
		pages [atualPage].SetActive (true);
	}

	public void Next ()
	{
		pages [atualPage].SetActive (false);
		if (atualPage == pages.Count-1)
			atualPage = 0;
		else
			atualPage += 1;

		pages [atualPage].SetActive (true);
	}

}
