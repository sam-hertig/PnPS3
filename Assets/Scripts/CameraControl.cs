using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float DampTime = 0.2f;                 // Approximate time for the camera to refocus.
    public float ScreenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.
    public float MinSize = 6.5f;                  // The smallest orthographic size the camera can be.
    public Transform[] Targets;                   // All the targets the camera needs to encompass.

    private Camera _camera;                        // Used for referencing the camera.
    private float _zoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
    private Vector3 _moveVelocity;                 // Reference velocity for the smooth damping of the position.
    private Vector3 _desiredPosition;              // The position the camera is moving towards.


    private void Awake()
    {
        _camera = GetComponentInChildren<Camera> ();
    }


    private void FixedUpdate()
    {
        Move ();
        Zoom ();
    }


    private void Move()
    {
        FindAveragePosition ();
        transform.position = Vector3.SmoothDamp(transform.position, _desiredPosition, ref _moveVelocity, DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3 ();
        int numTargets = 0;
        for (int i = 0; i < Targets.Length; i++)
        {
            averagePos += Targets[i].position;
            numTargets++;
        }
        if (numTargets > 0) 
        {
            averagePos /= numTargets;
        }
        averagePos.y = transform.position.y;
        _desiredPosition = averagePos;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        _camera.orthographicSize = Mathf.SmoothDamp (_camera.orthographicSize, requiredSize, ref _zoomSpeed, DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(_desiredPosition);
        float size = 0f;
        for (int i = 0; i < Targets.Length; i++)
        {
            Vector3 targetLocalPos = transform.InverseTransformPoint(Targets[i].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / _camera.aspect);
        }
        size += ScreenEdgeBuffer;
        size = Mathf.Max (size, MinSize);
        return size;
    }


    public void SetStartPositionAndSize()
    {
        FindAveragePosition ();
        transform.position = _desiredPosition;
        _camera.orthographicSize = FindRequiredSize ();
    }
}