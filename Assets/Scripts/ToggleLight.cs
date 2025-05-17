using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    public Light currentLight = null;   // reference to light source 
    public bool isOn = false;    // light source?s state


    void Start()
    {
        currentLight.enabled = isOn;    // initialise light to on/off 
    }
    // toggles the light on/off 
    public void ToggleLightOnOff()

    {
        currentLight.enabled = !currentLight.enabled;
    }
}