using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;

public class PictureTaker : MonoBehaviour
{
    public WebCamTexture picture;
    public RawImage pictureHolder;

    void Start()
    {
        picture = new WebCamTexture(WebCamTexture.devices[1].name );
        picture.Play();
        pictureHolder.material.mainTexture = picture;
    }

    public void takePicture()
    {
        Texture2D t = new Texture2D(68,68);

        t.SetPixels(picture.GetPixels());
        picture.Stop();
        pictureHolder.material.mainTexture = t;
    }

}