using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private Movement rocketMovement; // Reference to your Movement script
    [SerializeField] private Slider fuelSlider; // Reference to the UI Slider component

    [SerializeField] private Color normalColor = Color.green; // Color when fuel is above 30%
    [SerializeField] private Color criticalColor = Color.red; // Color when fuel is below 30%
    [SerializeField] [Range(0, 1)] private float criticalThreshold = 0.3f; // Threshold for critical fuel level

    [SerializeField] private AudioSource criticalFuelSound; // Sound to play when fuel reaches critical level
    private bool criticalSoundPlayed = false; // Flag to track if the critical sound has been played

    private void Start()
    {
        fuelSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        // Ensure the rocketMovement reference is not null
        if (rocketMovement != null && fuelSlider != null)
        {
            // Calculate the fuel percentage
            float fuelPercentage = rocketMovement.GetFuelPercentage();

            // Update the value of the fuel slider
            fuelSlider.value = fuelPercentage;

            // Change the fill color based on the fuel percentage
            fuelSlider.fillRect.GetComponentInChildren<Image>().color =
                fuelPercentage <= criticalThreshold ? criticalColor : normalColor;

            // Play critical fuel sound if the fuel reaches critical level and the sound hasn't been played yet
            if (fuelPercentage <= criticalThreshold && !criticalSoundPlayed && criticalFuelSound != null)
            {
                criticalFuelSound.Play();
                criticalSoundPlayed = true;
            }
        }
    }

    public void SetMovementScript(Movement movement)
    {
        rocketMovement = movement;
    }
}
