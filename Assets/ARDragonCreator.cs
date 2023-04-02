using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARDragonCreator : MonoBehaviour
{
    // reference to the dragon prefab that we will instantiate when a tracked image is detected
    [SerializeField] private GameObject dragonPrefab;

    // the offset position at which to instantiate the dragon prefab
    [SerializeField] private Vector3 prefabOffset;

    // reference to the dragon object that we will create and manipulate
    private GameObject dragon;

    // reference to the ARTrackedImageManager component that will detect and track the images
    private ARTrackedImageManager aRTrackedImageManager;

    // called when the ARDragonCreator script component is enabled
    private void OnEnable()
    {
        // get a reference to the ARTrackedImageManager component attached to the same game object
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        // subscribe to the trackedImagesChanged event of the ARTrackedImageManager
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    // called when the tracked images change
    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        // loop through all the added tracked images
        foreach (ARTrackedImage image in obj.added)
        {
            // instantiate the dragon prefab at the position and rotation of the tracked image
            dragon = Instantiate(dragonPrefab, image.transform);

            // add the prefab offset to the position of the dragon object
            dragon.transform.position += prefabOffset;
        }
    }
}
