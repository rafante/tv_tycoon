using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public Slider upDownSlider;
    public Slider leftRightSlider;
    public Slider rotationSlider;
    public Camera controlledCam;
    public float upDownFactor;
    public float leftRightFactor;
    public float rotationFactor;
    private Vector3 resetPosition;
    private float upDownLast;
    private float leftRightLast;

    private Transform[] possiblePlaces;
    private int curPlaceIndex;

    // Use this for initialization
    void Start()
    {
        setZeroPosition();
        findPossiblePlaces();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void findPossiblePlaces()
    {
        GameObject[] places = GameObject.FindGameObjectsWithTag(Tags.SCENE_CAM_PLACE);
        possiblePlaces = new Transform[places.Length];
        for (int i = 0; i < places.Length; i++)
        {
            possiblePlaces[i] = places[i].transform;
        }
    }

    public void nextPlace()
    {
        curPlaceIndex = (curPlaceIndex == possiblePlaces.Length - 1) ? 0 : curPlaceIndex + 1;
    }

    public void previousPlace()
    {
        curPlaceIndex = curPlaceIndex == 0 ? possiblePlaces.Length - 1 : curPlaceIndex + 1;
    }

    public void placeCam()
    {
        controlledCam.transform.position = possiblePlaces[curPlaceIndex].position;
        controlledCam.transform.rotation = possiblePlaces[curPlaceIndex].rotation;
    }

    public void setZeroPosition()
    {
        resetPosition = controlledCam.transform.position;
    }

    public void moveCam(float sliderValue, float factor, Vector3 direction)
    {
        float value = sliderValue * factor;
        Vector3 pos = controlledCam.transform.position;
        Vector3 newPos = pos;
        newPos.x = direction.x == 0 ? pos.x : resetPosition.x + value;
        newPos.y = direction.y == 0 ? pos.y : resetPosition.y + value;
        newPos.z = direction.z == 0 ? pos.z : resetPosition.z + value;
        controlledCam.transform.position = newPos;
    }

    public void moveHorizontally()
    {
        Vector3 direction = Vector3.right;
//        Vector3 direction = controlledCam.transform.right.normalized;
        moveCam(leftRightSlider.value, leftRightFactor, direction);
    }

    public void moveVertically()
    {
        Vector3 direction = Vector3.forward;
//        Vector3 direction = controlledCam.transform.forward.normalized;
        moveCam(upDownSlider.value, upDownFactor, direction);
    }

    public void rotate()
    {
        //controlledCam.transform.Translate(amount * leftRightFactor, 0, 0);
    }

    public void resetCam()
    {
        float upDown = upDownSlider.value;
        float leftRight = leftRightSlider.value;
        float rotation = upDownSlider.value;

        upDownSlider.value = 0;
        leftRightSlider.value = 0;
        rotationSlider.value = 0;

        controlledCam.transform.position = resetPosition;
    }
}