using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject player;

    int bulletCount;
    public void Kill()
    {
        if (bulletCount >= 1)
            return;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.DOMove(player.transform.position, 0.8f).SetEase(Ease.InOutQuad).OnComplete(GameOver);
        bulletCount++;
    }

    public void GameOver()
    {
        player.transform.GetChild(0).gameObject.SetActive(true);
        UIScript.UIS.GameOver();
    }
}
