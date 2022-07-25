using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice;
using Photon.Realtime;
using Photon;
using Photon.Pun;

public class Test : MonoBehaviourPunCallbacks
{
    // アバター
    public GameObject PhotonObject;

    [SerializeField] Text textField;

    void Start()
    {
        Debug.Log("sTART");
        PhotonNetwork.ConnectUsingSettings();
    }
    // マスターサーバーに接続したとき
    public override void OnConnectedToMaster()
    {
        // ルームがないならルームを作り,あとならそのままルームに入る
        Debug.Log("Connected master");
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }
    // ルームに入ったとき
    public override void OnJoinedRoom()
    {
        // アバター(オブジェクト)を作成する
        Debug.Log("Join the master");
        var position = new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Cube", position, Quaternion.identity, 0);
        Player p = PhotonNetwork.LocalPlayer;
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        Debug.Log($"{targetPlayer.NickName}({targetPlayer.ActorNumber})");

        Debug.LogWarning(changedProps.Count);

        // 更新されたプレイヤーのカスタムプロパティのペアをコンソールに出力する
        foreach (var prop in changedProps)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
            string m = $"{prop.Key}: {prop.Value}";
            if (textField == null)
            {
                Debug.LogWarning("textFiled is NULL");
                continue;
            }
            if (textField.text == null)
            {
                Debug.LogWarning("textFiled.text is NULL");
                continue;
            }
            textField.text = m;
        }
    }
}
