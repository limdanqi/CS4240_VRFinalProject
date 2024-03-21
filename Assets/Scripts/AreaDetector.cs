using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    private string currentArea = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string areaTag = gameObject.tag;
            if (areaTag != currentArea)
            {
                currentArea = areaTag;
                Debug.Log("Entered " + currentArea);
                // Perform any additional actions based on entering the area
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(currentArea))
            {
                Debug.Log("Exited " + currentArea);
            }
            else
            {
                Debug.Log("Exited an unknown area");
            }

            // Set currentArea to "Others" when exiting a known area
            currentArea = "Others";

            // Perform any additional actions based on exiting the area
        }
    }
}
