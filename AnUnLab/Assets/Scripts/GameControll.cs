using UnityEngine;
using System.Collections;

public class GameControll : MonoBehaviour {

	//einzigartiger Name
	private const string typeName = "qwertzusdfghxcvbnbgtcfdxsdevgnj";
	//Raumname
	private const string gameName = "blablaRoom";
	//Needed for joining
	private HostData[] hostList;

	public GameObject playerShip;

	static GameControll reference;


	public static GameControll getRef(){
		return reference;
	}

	private GameObject selectedShip = null;

	public GameObject SelectedShip {
				get {
						return selectedShip;
				}
				set {
						selectedShip = value;
				}
		}

	public GameObject getSelectedShip(){
		return selectedShip;
	}

	private void StartServer()
	{
		Network.InitializeServer(4, 5000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}
	
	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}
	
	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}

	void OnServerInitialized()
	{
		SpawnPlayer();
	}
	
	void OnConnectedToServer()
	{
		SpawnPlayer();
	}

	private void SpawnPlayer()
	{
		selectedShip = (GameObject) GameObject.Instantiate (playerShip);
	}


	// Use this for initialization
	void Start () {
		reference = this;
		//selectedShip = (GameObject) GameObject.Instantiate (playerShip);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
