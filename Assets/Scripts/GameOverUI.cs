using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HideUI()
    {
        animator.SetTrigger("Hide");
    }
}
