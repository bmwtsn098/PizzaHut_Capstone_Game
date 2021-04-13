using UnityEngine;

public class CityLevelController : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnItems()
    {
        Debug.Log("Testing");

        bool[] places = {false, false, false, false, false, false, false, false, false, false};
        GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("ItemSpawnLocation");
        foreach(GameObject itemToPlace in items)
        {
            int place = (int)Random.Range(0, 10);
            while(places[place])
            {

                place = (int)Random.Range(0, 10);
            }

            Debug.Log("Instanciate");
            GameObject curObject = Instantiate(itemToPlace, spawnLocations[place].transform.position, spawnLocations[place].transform.rotation);
            var pos = curObject.transform.position;
            pos.y += .02f;
            curObject.transform.position = pos;
            places[place] = true;

        }
    }
}
