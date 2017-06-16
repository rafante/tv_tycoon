using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool active;
    private GameObject marker;
    public ComponentType type;

    void Start()
    {
        marker = gameObject;
        setActivated(false);
    }

    public void activate()
    {
        setActivated(true);
    }

    public void deActivate()
    {
        setActivated(false);
    }

    public void setActivated(bool active)
    {
        this.active = active;
        updateProperties();
    }

    public void updateProperties()
    {
        MeshRenderer mesh = marker.GetComponent<MeshRenderer>();
        Collider col = marker.GetComponent<Collider>();

        mesh.enabled = active;
        col.enabled = active;
    }

    void OnMouseClick()
    {
        Debug.Log("Funcionou");
    }
}