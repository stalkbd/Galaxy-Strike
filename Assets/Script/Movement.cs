using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField]
    float Speed =10;
    [SerializeField]
    float range_clamp_x = 35f;

    [SerializeField]
    float range_clamp_y = 35f;
    [SerializeField]
    float Contol_rotation_factor_Roll = 40f;
    [SerializeField]
    float Contol_rotation_factor_Pitch = 40f;

    [SerializeField]
    private float Lerping_factor=10f;

    Vector2 MoveMentVec;
    
    

    void Start()
    {
        
    }

   
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessPitch();
    }
   


    private void ProcessPitch()
    {
        float Pitch = Contol_rotation_factor_Pitch*MoveMentVec.y;
        Quaternion TargetPitch = Quaternion.Euler(Pitch,0f,0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation,TargetPitch,Time.deltaTime*Lerping_factor);
    }

    private void ProcessRotation()
    {
        float Roll = Contol_rotation_factor_Roll*MoveMentVec.x;
        Quaternion TargetRotation = Quaternion.Euler(0f,0f,Roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation,TargetRotation,Lerping_factor*Time.deltaTime);
    }

    private void ProcessTranslation()
    {
        float offset_x = -Speed * Time.deltaTime * MoveMentVec.x;
        float offset_y = Speed * Time.deltaTime * MoveMentVec.y;

        float x_pos = transform.localPosition.x + offset_x;
        float x_clamp = Mathf.Clamp(x_pos,-range_clamp_x,range_clamp_x);

        float y_pos = transform.localPosition.y + offset_y;
        float y_clamp = Mathf.Clamp(y_pos,-range_clamp_y,range_clamp_y);

        transform.localPosition = new Vector3(x_clamp,y_clamp,0f);
    }
    public void OnMove(InputValue value)
    {
        MoveMentVec = value.Get<Vector2>();
    }
    
    
    
}

