using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            child.AddComponent<CoinController>();
        }
    }
}