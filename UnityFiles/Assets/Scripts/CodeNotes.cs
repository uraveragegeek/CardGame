/*  SERVER CODES
else if (type == "Loading New Scene")
                    {
                        try
                        {
                            Console.WriteLine("Type of Data is " + type);
                            string SceneName = (string)MyFormatter.Deserialize(NtwrkStrm);
                            NtwrkStrm.Flush();
                            string Username = (string)MyFormatter.Deserialize(NtwrkStrm);
                            Console.WriteLine("Adding Player " + Username + " to scene " + SceneName);
                            NtwrkStrm.Flush();
                            string responce = Dbh.SceneManagerAdder(SceneName, Username, ClientSocket);
                            //send responce back
                            if (responce == "Added to Starting Area")
                            {
                                PlayerClass.Area = SceneName;
                                //Console.WriteLine(PlayerClass.Area);
                            }
                            MyFormatter.Serialize(NtwrkStrm, type);
                            NtwrkStrm.Flush();
                            MyFormatter.Serialize(NtwrkStrm, responce);
                            NtwrkStrm.Flush();
                            foreach (KeyValuePair<string, TcpClient> Kvp in ServerController.ClientsInStartArea)
                            {
                                if (Kvp.Key != Username)
                                {
                                    MyFormatter.Serialize(Kvp.Value.GetStream(), "Player Joined Starting Area");
                                    Kvp.Value.GetStream().Flush();
                                    MyFormatter.Serialize(Kvp.Value.GetStream(), Username);
                                    Kvp.Value.GetStream().Flush();
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                    else if ( type == "Check for players in area")
                    {
                        Console.WriteLine("Type of Data is " + type);
                        string SceneName = (string)MyFormatter.Deserialize(NtwrkStrm);//Recieve
                        Console.WriteLine("Checking " + SceneName + " for players");
                        NtwrkStrm.Flush();
                        List<string> responce = Dbh.CheckForPlayerInScene(SceneName) as List<string>;
                        //send responce back
                        Console.WriteLine(responce.Count);
                        //MyFormatter.Serialize(NtwrkStrm, type);
                        //NtwrkStrm.Flush();
                        if (responce.Count != 0)
                        {
                            bool listempty = false;
                            MyFormatter.Serialize(NtwrkStrm, listempty);//Send 
                            NtwrkStrm.Flush();
                            MyFormatter.Serialize(NtwrkStrm, responce);//Send 
                            NtwrkStrm.Flush();
                        }
                        else
                        {
                            bool listEmpty = true;
                            MyFormatter.Serialize(NtwrkStrm, listEmpty);//Send 
                            NtwrkStrm.Flush();
                        }
                        Console.WriteLine("Responce Sent");
                    }
                    else if (type == "Current Position")
                    {
                        //Console.WriteLine("Type of data is " + type);
                        string name = (string)MyFormatter.Deserialize(NtwrkStrm); //receive
                        NtwrkStrm.Flush();
                        PlayerClass.xPosition = (float)MyFormatter.Deserialize(NtwrkStrm); //receive
                        NtwrkStrm.Flush();
                        PlayerClass.yPosition = (float)MyFormatter.Deserialize(NtwrkStrm); //receive
                        NtwrkStrm.Flush();
                        PlayerClass.zPosition = (float)MyFormatter.Deserialize(NtwrkStrm); //receive
                        NtwrkStrm.Flush();
                        PlayerClass.Rotation = (float)MyFormatter.Deserialize(NtwrkStrm); //receive
                        NtwrkStrm.Flush();
                        foreach (KeyValuePair<string,TcpClient> KvP in ServerController.ClientsInStartArea)
                        {
                            if (KvP.Key != name)
                            {
                                MyFormatter.Serialize(KvP.Value.GetStream(), type); //Send
                                NtwrkStrm.Flush();
                                MyFormatter.Serialize(KvP.Value.GetStream(), PlayerClass.UserName); //Send
                                NtwrkStrm.Flush();
                                MyFormatter.Serialize(KvP.Value.GetStream(), PlayerClass.xPosition); //Send
                                NtwrkStrm.Flush();
                                MyFormatter.Serialize(KvP.Value.GetStream(), PlayerClass.yPosition); //Send
                                NtwrkStrm.Flush();
                                MyFormatter.Serialize(KvP.Value.GetStream(), PlayerClass.zPosition); //Send
                                NtwrkStrm.Flush();
                                MyFormatter.Serialize(KvP.Value.GetStream(), PlayerClass.Rotation); //Send
                                NtwrkStrm.Flush();
                            } 
                        }
                        
                    }
                    */
/*    
                    
                     
                     */
/*static void GetSettingsFromUser()   //this may change into getting server setting later for stuff like max players. not sure yet.
       {
           Console.WriteLine("Please enter Server ip address.");
           serverIP = Console.ReadLine();
           Console.WriteLine("Please enter Database name.");
           database = Console.ReadLine();
           Console.WriteLine("Please enter User name");
           uid = Console.ReadLine();
           Console.WriteLine("Please enter Password.");
           password = Console.ReadLine();

           try
           {
               SettingsDictionary.Add("ServerIP", serverIP);
               SettingsDictionary.Add("DataBase", database);
               SettingsDictionary.Add("UID", uid);
               SettingsDictionary.Add("Password", password);
           }
           catch
           {
               Console.WriteLine("Adding Variables to Dictionary has failed. ");
           }

           try
           {
               IFormatter formatter = new BinaryFormatter();
               Stream stream = new FileStream(@"Settings.bin", FileMode.Create, FileAccess.Write, FileShare.None);
               formatter.Serialize(stream, SettingsDictionary);
               stream.Close();
           }
           catch
           {
               Console.WriteLine("Serialization failed.");
           }
       }

       static void Settings()
       {

           if (File.Exists(@"Settings.bin"))
           {
               try
               {
                   IFormatter formatter = new BinaryFormatter();
                   Stream stream = new FileStream(@"Settings.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                   SettingsDictionary = (Dictionary<string, string>)formatter.Deserialize(stream);
                   stream.Close();
                   Console.WriteLine("Settings file found, loaded Settings from it.");
               }
               catch
               {
                   Console.WriteLine("Could not load settings.bin");
               }
           }
           else
           {
               GetSettingsFromUser();
           }
       }*/


/*UNTIY CODES
  public void LoadLevel()
    {
        if (PlayerClass.Area != null)
        {
            NetworkStream NtwrkStrm = TcpClnt.GetStream();
            IFormatter Formatter = new BinaryFormatter();

            UnityEngine.Debug.Log("Loading Area Send Started");
            string type = "Loading New Scene";
            Formatter.Serialize(NtwrkStrm, type);
            NtwrkStrm.Flush();
            Formatter.Serialize(NtwrkStrm, PlayerClass.Area);
            NtwrkStrm.Flush();
            Formatter.Serialize(NtwrkStrm, PlayerClass.Name);
            NtwrkStrm.Flush(); 
        }
        else
        {
            string area = "none";

            NetworkStream NtwrkStrm = TcpClnt.GetStream();
            IFormatter Formatter = new BinaryFormatter();

            UnityEngine.Debug.Log("none Area Send Started");
            string type = "Loading New Scene";
            Formatter.Serialize(NtwrkStrm, type);
            NtwrkStrm.Flush();
            Formatter.Serialize(NtwrkStrm, area);
            NtwrkStrm.Flush();
            Formatter.Serialize(NtwrkStrm, PlayerClass.Name);
            NtwrkStrm.Flush();
        }
    }*/
/*else if (type == "Loading New Scene")
                {
                    string response = (string)MyFormatter.Deserialize(NtwrkStrm);
                    NtwrkStrm.Flush();
                    if (response == "Failed to add")
                    {
                        MMScript.LoadingStartAreaResponceHandler(response);
                        return;
                    }
                    else
                    {
                        GetCurrentPlayersInArea(PlayerClass.Area);
                        SceneManager.LoadScene("Starting_Area");
                        PlayerClass.Area = "Starting Area";
                        return;
                    }
                }
                else if (type == "Player Joined Starting Area")
                {
                    Lisst.Add((string)MyFormatter.Deserialize(NtwrkStrm));
                    plyermng.spawned = false;
                    plyermng.SpawnPlayer(Lisst, TcpClnt, PlayerClass.Name);
                }
                */
/* public void GetCurrentPlayersInArea(string area)
    {
        NetworkStream NtwrkStrm = TcpClnt.GetStream();
        IFormatter MyFormatter = new BinaryFormatter();

        try
        {
            string type = "Check for players in area";
            MyFormatter.Serialize(NtwrkStrm, type);//Send
            NtwrkStrm.Flush();
            MyFormatter.Serialize(NtwrkStrm, area);//Send
            NtwrkStrm.Flush();
            bool listEmpty = (bool)MyFormatter.Deserialize(NtwrkStrm); //Recieve
            NtwrkStrm.Flush();
            if (!listEmpty)
            {
                Lisst = (List<string>)MyFormatter.Deserialize(NtwrkStrm); //Recieve
                NtwrkStrm.Flush();
                if (Lisst.Count == 0)
                {
                    UnityEngine.Debug.Log("Responce is = to 0");
                    return;
                }
                else
                {
                    return;
                }
            }
            
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }*/
