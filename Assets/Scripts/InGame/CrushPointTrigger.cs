using UnityEngine;

public class CrushPointTrigger : MonoBehaviour
{
    private RoadRoller roadRoller;

    private void Awake()
    {
        roadRoller = GetComponentInParent<RoadRoller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Car"))
        {
            roadRoller.OnCrushPointTrigger(other);
        }
    }
}
