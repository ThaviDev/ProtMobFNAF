using UnityEngine;

public class BossCharacter : MonoBehaviour
{
    private void Start()
    {
        MyARManager.Instance.SetCharacter(this.gameObject);
    }
}
