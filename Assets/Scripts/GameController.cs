using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	private void Start () 
	{
        DistributePlayers();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Randomly distribute players to countries 
     **/
	private void DistributePlayers()
    {
	    /*
        var players = new List<PlayerController>(FindObjectsOfType<PlayerController>());
        var countries = new List<Country>(FindObjectsOfType<Country>());

       while (countries.Count >= players.Count && players.Count > 0)
        {
            var countryIndex = Random.Range(0, countries.Count);
            var homeCountry = countries[countryIndex];

            // assign home countries and position player objects
            var player = players[0];
            player._homeCountry = homeCountry;
            player.gameObject.transform.position = new Vector3(
                homeCountry.gameObject.transform.position.x,
                homeCountry.gameObject.transform.position.y + 1.0f,
                homeCountry.gameObject.transform.position.z);
	        player.gameObject.SetActive(false);

            players.RemoveAt(0);
            countries.RemoveAt(countryIndex);
        }
        */
    }
}
