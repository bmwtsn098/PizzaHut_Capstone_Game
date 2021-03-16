using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapToSpawnObject : MonoBehaviour
{

    public GameObject AR_object;
    public Camera AR_Camera;
    public ARRaycastManager raycastManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = AR_Camera.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(AR_object, pose.position, pose.rotation);
            }
        }

    }
}
