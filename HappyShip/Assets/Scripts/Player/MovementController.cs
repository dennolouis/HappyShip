using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    Movement movement;

    public void SetMovement(Movement move)
    {
        movement = move;
    }
   
    // Callback method for when the "left" button is clicked
    public void OnLeftButtonClicked()
    {
        movement.SetLeft(true);
    }

    // Callback method for when the "left" button is released
    public void OnLeftButtonReleased()
    {
        movement.SetLeft(false);
    }

    // Callback method for when the "right" button is clicked
    public void OnRightButtonClicked()
    {
        movement.SetRight(true);
    }

    // Callback method for when the "right" button is released
    public void OnRightButtonReleased()
    {
        movement.SetRight(false);
    }

    // Callback method for when the "thrust" button is clicked
    public void OnThrustButtonClicked()
    {
        movement.SetThust(true);
    }

    // Callback method for when the "thrust" button is released
    public void OnThrustButtonReleased()
    {
        movement.SetThust(false);
    }
}
