using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float thrusterForce = 1000f;
    [SerializeField]
    private float sprintSpeed = 10f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //calculate movement velocity as a 3D vector for moving char
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        if (Input.GetKey("left shift")) 
        {
            //final movement vector
            Vector3 _velocity = (_movHorizontal + _movVertical).normalized * sprintSpeed;
            //apply movement
            motor.Move(_velocity);
        }
        else
        {
            //final movement vector
            Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
            //apply movement
            motor.Move(_velocity);
        }

        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetKey("space"))
        {
            Debug.Log("Jump");
            _thrusterForce = Vector3.up * thrusterForce;
        }

        
        //calculate rotation as 3D vector for turning char
        float _yRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //apply rotation
        motor.RotatePlayer(_rotation);

        //calculate camera rotation as 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _camRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //apply rotation
        motor.RotateCamera(_camRotation);


    }

}
