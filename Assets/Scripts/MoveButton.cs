using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using Photon.Realtime;
using UnityEngine.UI;
public class MoveButton : MonoBehaviour
{

    [SerializeField] Button button;
    [SerializeField] GameObject obj;

    [SerializeField] float posx1, posx2;

    private bool Ispos1;

    [SerializeField] string message;

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            // Ispos1 = !Ispos1;
            // var p = obj.transform.position;
            // p.x = Ispos1 ? posx1 : posx2;
            // obj.transform.position = p;

            Player pl = PhotonNetwork.LocalPlayer;
            ExitGames.Client.Photon.Hashtable table = new ExitGames.Client.Photon.Hashtable();
            table["Message"] = message;
            pl.SetCustomProperties(table);
            Debug.Log("send message");
        });
    }
}
