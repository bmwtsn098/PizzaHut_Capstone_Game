using System.Collections.Generic;
using UnityEngine;

public class CityLevelController : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;

    private GameObject selectedBuilding = null;
    private GameObject[] nonPickedUpItems;
    private bool deliveryLocationPicked = false;

    private int rounds = 0;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("Summer BGM");

        deliveryLocationPicked = false;
        selectedBuilding = null;

        GameObject pizza = GameObject.FindGameObjectWithTag("Exit");
        if (pizza != null)
            pizza.gameObject.tag = "PizzaHut";
    }

    // Update is called once per frame
    void Update()
    {

        nonPickedUpItems = GameObject.FindGameObjectsWithTag("Point");

        if(nonPickedUpItems.Length <= 0 && !deliveryLocationPicked)
        {

            GameObject[] deliveryLoccations = GameObject.FindGameObjectsWithTag("Building");
            selectedBuilding = deliveryLoccations[(int)Random.Range(0, 74)];
            selectedBuilding.tag = "DeliveryLocation";
            deliveryLocationPicked = true;
            
        }

        if (selectedBuilding != null)
        {

            Debug.Log("Selected Building");
            Light light = selectedBuilding.GetComponent<Light>();
            light.enabled = true;
            light.range = Mathf.PingPong(Time.time, .2f);

            GameObject[] delivery = GameObject.FindGameObjectsWithTag("DeliveryLocation");
            if (delivery.Length > 0) {


            } else if(rounds > 0)
            {
                light.enabled = false;
                selectedBuilding = null;
                deliveryLocationPicked = false;

                spawnItems();
                rounds--;
                Debug.Log("Rounds Left: " + rounds);

            } else
            {
                Debug.Log("out of rounds");

                //light.enabled = false;
                selectedBuilding = GameObject.FindGameObjectWithTag("PizzaHut");
                selectedBuilding.tag = "Exit";
            }
        }
    }

    public void placedLevelStart()
    {
        spawnItems();
    }
    public void spawnItems()
    {

        bool[] places = {false, false, false, false, false, false, false, false, false, false};
        GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("ItemSpawnLocation");
        foreach(GameObject itemToPlace in items)
        {
            int place = (int)Random.Range(0, 10);
            while(places[place])
            {

                place = (int)Random.Range(0, 10);
            }

            GameObject curObject = Instantiate(itemToPlace, spawnLocations[place].transform.position, spawnLocations[place].transform.rotation);
            var pos = curObject.transform.position;
            pos.y += .02f;
            curObject.transform.position = pos;
            places[place] = true;

        }
    }
}
