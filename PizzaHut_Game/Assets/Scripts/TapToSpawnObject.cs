using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToSpawnObject : MonoBehaviour
{

    public GameObject AR_object;
    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private Vector2 touchPos;

    static public List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    private void Awake()
    {

        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool getTouch(out Vector2 touchPos)
    {

        if(Input.touchCount > 0)
        {

            touchPos = Input.GetTouch(0).position;
            return true;
        }

        touchPos = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!getTouch(out Vector2 touchPos))
            return;

        if(raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
        {

            var hitPose = hits[0].pose;

            if(spawnedObject = null)
            {

                spawnedObject = Instantiate(AR_object, hitPose.position, hitPose.rotation);
            } else
            {

                AR_object.transform.position = hitPose.position;
            }
        }
    }
}
