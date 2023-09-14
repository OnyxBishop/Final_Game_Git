using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Hero _target;
    private Camera _camera;
    private float _maxHeigth = 2.2f;

    public void Initialise(Hero target)
    {
        _camera = Camera.main;
        _target = target;
    }

    private void Update()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        _camera.transform.position = new Vector3(_target.transform.position.x,
            _target.transform.position.y + _maxHeigth, _camera.transform.position.z);
    }
}
