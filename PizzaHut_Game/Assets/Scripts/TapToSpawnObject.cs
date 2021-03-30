using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToSpawnObject : MonoBehaviour
{
    /*
    public GameObject gameObjectToTnstantiate;

    private GameObject spawnedObject = null;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {

        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {

        if(Input.touchCount > 0)
        {

            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {

            var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {

                spawnedObject = Instantiate(gameObjectToTnstantiate, hitPose.position, hitPose.rotation);
            } else
            {

                gameObjectToTnstantiate.transform.position = hitPose.position;
            }
        }
    }
    */

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;
    private GameObject Level;

    [SerializeField]
    private GameObject PlaceablePrefab;
    [SerializeField]
    private GameObject Obstacle;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public GameObject joystick;
    public GameObject button;
    public GameObject text;

    private bool firstTouch = true;
    private bool obstacle = false;

    private List<GameObject> ObstacleList = new List<GameObject>();
    public int maxObstacles = 0;
    private int curObstacleCount = 0;

    private void Awake()
    {

        raycastManager = GetComponent<ARRaycastManager>();
        joystick.SetActive(false);
        button.SetActive(false);
        text.SetActive(true);
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {

        if(Input.touchCount > 0)
        {

            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {

        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {

            return;
        }

        if(raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {

            if (firstTouch)
            {

                var fhitPose = s_Hits[0].pose;
                Level = Instantiate(PlaceablePrefab, fhitPose.position, fhitPose.rotation);

                while (Input.GetTouch(0).phase != TouchPhase.Ended)
                {

                    Level.transform.position = fhitPose.position;
                    Level.transform.rotation = fhitPose.rotation;
                }

                firstTouch = false;
                text.SetActive(false);
                joystick.SetActive(true);
                button.SetActive(true);
            }
            else
            {

                var hitPose = s_Hits[0].pose;

                if (curObstacleCount < maxObstacles && obstacle)
                {

                    spawnedObject = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);
                    while (Input.GetTouch(0).phase != TouchPhase.Ended)
                    {

                        spawnedObject.transform.position = hitPose.position;
                        spawnedObject.transform.rotation = hitPose.rotation;
                    }

                    ObstacleList.Add(spawnedObject);

                }
            } 
        }
    }

    public void placeCubes()
    {
        if(obstacle)
        {

            obstacle = false;
            joystick.SetActive(true);
        }
        else
        {

            obstacle = true;
            joystick.SetActive(false);
        }
        
    }
}
