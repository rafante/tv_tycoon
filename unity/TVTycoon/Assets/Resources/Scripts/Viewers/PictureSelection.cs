using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class PictureSelection : MonoBehaviour
{
    public GameObject pictureSelectionPrefab;
    public GameObject thumbnailPrefab;
    public Image image;
    public void showPictures()
    {
        GameObject pictureSelection = Instantiate(pictureSelectionPrefab);

        pictureSelection.transform.SetParent(transform);
        pictureSelection.transform.localPosition = Vector3.zero;
        pictureSelection.transform.localScale = Vector3.one;

        GetComponent<ScrollRect>().content = pictureSelection.GetComponent<RectTransform>();

        string path = GamePaths.ATTRACTION_PICS;
        Sprite[] allPics = Resources.LoadAll<Sprite>(path);
        foreach (var pic in allPics)
        {
            Image picImg = Instantiate(thumbnailPrefab).GetComponent<Image>();
            picImg.sprite = pic;
            
            picImg.gameObject.transform.SetParent(pictureSelection.transform);
            picImg.gameObject.transform.localPosition = Vector3.zero;
            picImg.gameObject.transform.localScale = Vector3.one;
            
            picImg.GetComponent<Button>().onClick.AddListener(() =>
            {
                image.sprite = picImg.sprite;
                DestroyImmediate(pictureSelection.gameObject);
            } );
        }
    }

}