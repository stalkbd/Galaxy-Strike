using UnityEngine;
using UnityEngine.InputSystem;


public class FireLesar : MonoBehaviour
{
    [SerializeField]
    GameObject[] Lasers;
    bool isPressed = false;

    private void Update()
    {
        ProccesedInput();
    }
    public void OnSpace(InputValue inputValue)
    {
        isPressed = inputValue.isPressed;
    }
    public void ProccesedInput()
    {
        foreach (var Laser in Lasers)
        {
            var emissionModule = Laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isPressed; 
        }
              
    }
    
}
