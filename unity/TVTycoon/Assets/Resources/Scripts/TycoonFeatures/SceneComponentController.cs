using UnityEngine;
using UnityEngine.UI;

public class SceneComponentController : MonoBehaviour
{
    public SceneComponent component;
    public GameObject actorPrefab;
    public GameObject[] allSpawnPoints;
    public Button confirmBtn, cancelBtn;
    public SceneState state = SceneState.IDLE;

    public static SceneComponentController main;

    void Awake()
    {
        if (main == null)
            main = this;
        updateSpawnPointsBuffer();
        uiUpdate();
    }

    void Update()
    {
        if (component != null)
        {
            switch (component.type)
            {
                case ComponentType.ACTOR:
                    moveActor(component);
                    break;
                default:
                    break;
            }
        }
        defineState();
    }

    public void uiUpdate()
    {
        setBtnsEvent();
        bool movingActor = component != null;
        confirmBtn.image.enabled = movingActor;
        cancelBtn.image.enabled = movingActor;
    }

    public void defineState()
    {
        SceneState curState = state;
        if (component != null)
        {
            if (component.type == ComponentType.ACTOR)
                state = SceneState.MOVING_ACTOR;
            else
                state = SceneState.MOVING_ITEM;
        }
        else
            state = SceneState.IDLE;
        if (curState != state)
        {
            updateState();
        }
    }

    public void updateState()
    {
        uiUpdate();
    }

    public void removeEvents()
    {
        confirmBtn.onClick.RemoveAllListeners();
        cancelBtn.onClick.RemoveAllListeners();
    }

    public void setBtnsEvent()
    {
        removeEvents();
        switch (state)
        {
            case SceneState.IDLE:

                break;
            case SceneState.MOVING_ACTOR:
                confirmBtn.onClick.AddListener(confirmComponent);
                cancelBtn.onClick.AddListener(cancelComponent);
                break;
            case SceneState.MOVING_ITEM:

                break;
        }
    }

    public void confirmComponent()
    {
        component = null;
        hideSpawnPoints(ComponentType.ACTOR);
    }

    public void cancelComponent()
    {
        DestroyImmediate(component.gameObject);
        component = null;
        hideSpawnPoints(ComponentType.ACTOR);
    }

    public void updateSpawnPointsBuffer()
    {
        allSpawnPoints = GameObject.FindGameObjectsWithTag(Tags.SCENE_SPAWN_POINT);
    }

    public GameObject[] getSpawnPoints()
    {
        if (allSpawnPoints == null)
            updateSpawnPointsBuffer();
        return allSpawnPoints;
    }

    public void spawnActor()
    {
        SceneComponent actor = null;
        if (component == null)
            actor = Instantiate(actorPrefab).GetComponent<SceneComponent>();
        else
            actor = component;
        component = actor;
        showSpawnPoints(ComponentType.ACTOR);
        uiUpdate();
    }

    private void moveActor(SceneComponent comp)
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider != null)
                {
                    comp.transform.position = hit.collider.transform.position;
                    comp.transform.rotation = hit.collider.transform.rotation;
                }
            }
        }
    }

    private void toggleSpawnPoints(ComponentType compType, bool active)
    {
        GameObject[] actorSpawnPoints = getSpawnPoints();
        foreach (var spawnPoint in actorSpawnPoints)
        {
            var spawn = spawnPoint.GetComponent<SpawnPoint>();
            if (spawn.type == compType)
            {
                spawn.setActivated(active);
            }
        }
    }

    private void showSpawnPoints(ComponentType compType)
    {
        toggleSpawnPoints(compType, true);
    }

    private void hideSpawnPoints(ComponentType compType)
    {
        toggleSpawnPoints(compType, false);
    }

    private GameObject[] findSpawnPoints(string spawnTag)
    {
        return GameObject.FindGameObjectsWithTag(spawnTag);
    }
}

public enum SceneState
{
    MOVING_ACTOR,
    MOVING_ITEM,
    IDLE
}