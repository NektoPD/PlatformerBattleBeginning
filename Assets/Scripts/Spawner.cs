using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;

    private void Start()
    {
       foreach (Transform childTransform in transform)
        {
            Instantiate(_template, childTransform.position, Quaternion.identity);
        }
    }
}
