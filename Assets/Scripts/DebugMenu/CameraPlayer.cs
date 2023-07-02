using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField]
    private Camera _cameraPlayer;
    [SerializeField]
    private Slider _silderFieldOfView;

    const float BASE_FOV_OFFSET = 60f;
    float _minFieldOfView;

    bool _isFirstPersonView = false;
    Vector3 _posCameraThirdPersionView;
    Vector3 _eulerAnglesCameraThirdPersionView;
    Vector3 _posCameraFirstPersionView = new Vector3(0f, 1.9f, -3.6f);
    Vector3 _eulerAnglesCameraFirstPersionView = new Vector3(0.08f, 0f, 0f);
    // Use this for initialization
    void Start()
    {
        _minFieldOfView = _cameraPlayer.fieldOfView;
        _posCameraThirdPersionView = _cameraPlayer.transform.position;
        _eulerAnglesCameraThirdPersionView = _cameraPlayer.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeNearFarCamera()
    {
        _cameraPlayer.fieldOfView = _minFieldOfView + BASE_FOV_OFFSET * _silderFieldOfView.value;
    }


    public void ChangeViewFirstPersonCamera()
    {
        _isFirstPersonView = true;
        if (_isFirstPersonView)
        {
             _cameraPlayer.transform.position = _posCameraFirstPersionView;
             _cameraPlayer.transform.eulerAngles = _eulerAnglesCameraFirstPersionView;
        }
       
    }
    public void ChangeViewThirdPersonCamera()
    {
        _isFirstPersonView = false;

        {
            _cameraPlayer.transform.position = _posCameraThirdPersionView;
            _cameraPlayer.transform.eulerAngles = _eulerAnglesCameraThirdPersionView;
        }
    }
}
