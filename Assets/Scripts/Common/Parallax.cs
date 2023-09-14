using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;

    private RawImage _image;
    private float _imageUvPos;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imageUvPos += _parallaxSpeed * Time.deltaTime;

        if (_imageUvPos > 15)
            _imageUvPos = 0; 

        _image.uvRect = new Rect(_imageUvPos, 0 , _image.uvRect.width, _image.uvRect.height);
    }
}
