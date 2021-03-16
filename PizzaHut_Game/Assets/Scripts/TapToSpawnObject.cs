using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToSpawnObject : MonoBehaviour
{

    public GameObject gameObjectToTnstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {

        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool getTouch(out Vector2 touchPosition)
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

        if (!getTouch(out Vector2 touchPosition))
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
}
