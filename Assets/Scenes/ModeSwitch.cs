using UnityEngine;
using Vuforia;

public class TrackingModeSwitcher : MonoBehaviour
{
    public GameObject liverTarget;
    public GameObject markerFrameTarget;

    private ModelTargetBehaviour liverMTB;
    private ModelTargetBehaviour markerFrameMTB;

    private bool isLiverActive = false;

    void Start()
    {
        liverMTB = liverTarget.GetComponent<ModelTargetBehaviour>();
        markerFrameMTB = markerFrameTarget.GetComponent<ModelTargetBehaviour>();

        SetActiveTarget(isLiverActive);
    }

    public void ToggleTrackingMode()
    {
        isLiverActive = !isLiverActive;
        SetActiveTarget(isLiverActive);
    }

    private void SetActiveTarget(bool useLiver)
    {
        if (useLiver)
        {
            liverMTB.enabled = true;
            markerFrameMTB.enabled = false;
        }
        else
        {
            liverMTB.enabled = false;
            markerFrameMTB.enabled = true;
        }

        Debug.Log("Switched to " + (useLiver ? "LIVER" : "MARKER FRAME"));
    }
}