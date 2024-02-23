using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 100;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] AudioClip engineThrust;
    [SerializeField] AudioClip outOfFuelClip; // New audio clip for when fuel runs out
    [SerializeField] ParticleSystem engineThrustParticles;
    [SerializeField] float thrustDeduction = 3f;
    [SerializeField] float thrustFuel = 100f;

    Rigidbody rb;
    AudioSource audioSource;
    bool thrust = false;
    bool left = false;
    bool right = false;
    bool outOfFuelSoundPlayed = false; // Flag to track if the out of fuel sound has been played

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        FindObjectOfType<MovementController>().SetMovement(this);
        FindObjectOfType<FuelUI>().SetMovementScript(this);
    }

    void Update()
    {
        ProcessInput();

        // Check if fuel has run out and play the out of fuel sound if it has
        if (thrustFuel <= 0 && !outOfFuelSoundPlayed && outOfFuelClip != null)
        {
            audioSource.PlayOneShot(outOfFuelClip); // Play the out of fuel sound
            outOfFuelSoundPlayed = true; // Set the flag to true so it won't play again
        }
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.W) || thrust)
        {
            Thrust();
        }
        else
        {
            StopThrust();
        }

        if (Input.GetKey(KeyCode.A) || left)
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D) || right)
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void StopThrust()
    {
        audioSource.Stop();
        engineThrustParticles.Stop();
    }

    private void Thrust()
    {
        if (thrustFuel <= 0) return;

        thrustFuel -= thrustDeduction * Time.deltaTime;

        rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);

        if (!engineThrustParticles.isPlaying)
        {
            engineThrustParticles.Play();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineThrust);
        }
    }

    void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }

    public void SetThust(bool val)
    {
        thrust = val;
    }

    public void SetLeft(bool val)
    {
        left = val;
    }

    public void SetRight(bool val)
    {
        right = val;
    }

    public float GetFuelPercentage()
    {
        return Mathf.Clamp01(thrustFuel / 100f);
    }
}
