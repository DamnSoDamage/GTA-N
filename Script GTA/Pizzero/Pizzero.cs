using System;
using GTANetworkServer;
using GTANetworkShared;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizze
{
    
    public class PizzaJob : Script
    {
        NetHandle Marker;
        bool entra;
        int i = 1;
        bool termina;
        NetHandle burguer;
        
        public PizzaJob()
        {
            API.onResourceStart += onResourceStartHandle;
            API.onPlayerConnected += PlayerConnectedHandle;
            API.onEntityEnterColShape += onEntityEnterColShapeHandler;
            API.onUpdate += OnUpdateHandler;
        }
         public void onResourceStartHandle()
        {

            API.createVehicle(VehicleHash.Faggio, new Vector3(-1172.722, -875.9897, 14.13326), new Vector3(0, 0, -59.00127), 91, 0);
            API.createVehicle(VehicleHash.Faggio, new Vector3(-1170.261, -879.2712, 14.14486), new Vector3(0, 0, -59.00127), 91, 0);
            API.createVehicle(VehicleHash.Faggio, new Vector3(-1168.975, - 883.1688, 14.11784), new Vector3(0, 0, -59.00127), 91, 0);

            var pos = new Vector3(-1181.81, - 873.1742, 12.9335);
            var rot = new Vector3(0, 0, 1f);
            

            
            Marker = API.createMarker(1, pos, new Vector3(), new Vector3(), new Vector3(2.5, 2.5, 2.5), 255, 255, 0, 0, 0);
            API.createCylinderColShape(pos, 2, 2);
            entra = false;
            
            



        }

        public DateTime LastAnnounce; 
        public void OnUpdateHandler()
        {
            Vector3[] checkpoints;
            checkpoints = new Vector3[8];
            checkpoints[1] = new Vector3(-1276.58, -901.6766, 9.6858);
            checkpoints[2] = new Vector3(-1358.222, -809.3616, 18.22151);
            checkpoints[3] = new Vector3(-1274.057, -911.7726, 10.18196);
            checkpoints[4] = new Vector3(-1215.538, -881.0832, 11.96667);

            if (DateTime.Now.Subtract(LastAnnounce).TotalMilliseconds >= 100) 
            {
                LastAnnounce = DateTime.Now; 
                if(entra == true)
                {
                    Marker = API.createMarker(1, checkpoints[i], new Vector3(), new Vector3(), new Vector3(2.5, 2.5, 2.5), 255, 255, 0, 0, 0);
                    API.createCylinderColShape(checkpoints[i], 2, 2);
                    i++;
                    entra = false;
                }
                
                

            }
        }
        public void onEntityEnterColShapeHandler(ColShape shape, NetHandle entity)
        {

            
            entra = true;
            termina = false;
            var player = API.getPlayerFromHandle(entity);
            if (i == 1)
            {
                API.triggerClientEvent(player, "MUSIC");
            }
            burguer = API.createObject(759729215, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            API.attachEntityToEntity(burguer, player, "IK_R_Hand", new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            API.sendChatMessageToPlayer(player, String.Format("Este es el punto del reparto ({0}/5) ", i));
               
                if (API.doesEntityExist(Marker))
                {   
                API.deleteColShape(shape);
                API.deleteEntity(Marker);

                }

            if (i == 5)
            {
                API.triggerClientEvent(player, "stop_music");
                API.sendNotificationToPlayer(player, "Música para");
            }



        }

        public void PlayerConnectedHandle(Client player)
        {
            burguer = API.createObject(759729215, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            API.attachEntityToEntity(burguer, player, "IK_R_Hand", new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            API.setPlayerSkin(player, PedHash.Ashley);
            var pos1 = new Vector3(-1172.722, -875.9897, 14.13326);
            API.setEntityPosition(player, pos1);
            var pos = new Vector3(-135.25, 80.49995, 71.03822);
            var rot = new Vector3(0, 0, 1f);
            if(i == 1)
            {
                API.deleteEntity(burguer);
            }

            



        }

        [Command("coords")]
        public void coords(Client player, string coordName)
        {
            Vector3 playerPosGet = API.getEntityPosition(player);
            var pPosX = (playerPosGet.X.ToString().Replace(',', '.') + ", ");
            var pPosY = (playerPosGet.Y.ToString().Replace(',', '.') + ", ");
            var pPosZ = (playerPosGet.Z.ToString().Replace(',', '.'));
            Vector3 playerRotGet = API.getEntityRotation(player);
            var pRotX = (playerRotGet.X.ToString().Replace(',', '.') + ", ");
            var pRotY = (playerRotGet.Y.ToString().Replace(',', '.') + ", ");
            var pRotZ = (playerRotGet.Z.ToString().Replace(',', '.'));

            API.sendChatMessageToPlayer(player, "Your position is: ~y~" + playerPosGet, "~w~Your rotation is: ~y~" + playerRotGet);
            StreamWriter coordsFile;
            if (!File.Exists("SavedCoords.txt"))
            {
                coordsFile = new StreamWriter("SavedCoords.txt");
            }
            else
            {
                coordsFile = File.AppendText("SavedCoords.txt");
            }
            API.sendChatMessageToPlayer(player, "~r~Coordenadas guardadas!");
            coordsFile.WriteLine("| " + coordName + " | " + "Saved Coordenates: " + pPosX + pPosY + pPosZ + " Rotation: " + pRotX + pRotY + pRotZ);
            coordsFile.Close();
        }

        [Command("crearvehiculo", GreedyArg = true)]
        public void Comando_Crearvehiculo(Client sender)
        {
            var Playerpos = API.getEntityPosition(sender);
            var Playerrot = API.getEntityRotation(sender);
            
            API.createVehicle(VehicleHash.Zentorno, Playerpos, Playerrot, 0, 0);

        }



    }
}