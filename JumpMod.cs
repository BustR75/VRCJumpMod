using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using NET_SDK;
using NET_SDK.Reflection;
using NET_SDK.Harmony;
using VRC;

namespace Jump_Mod
{
    public static class BuildInfo
    {
        public const string Name = "JumpMod"; // Name of the Mod.  (MUST BE SET)
        public const string Author = null; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }
    public class JumpMod : MelonMod {
        bool didInit = false;
        PlayerModComponentJump jump;
        PlayerModComponentSpeed speed;
        Player localplayer = null;
        public override void OnApplicationStart()
        {
            MelonModLogger.Log("initial load");
            MelonModLogger.Log("<Controls>");
            MelonModLogger.Log("Page Up -> increase jump");
            MelonModLogger.Log("Page Down -> decrease jump");
            MelonModLogger.Log("Up Arrow -> increase speed");
            MelonModLogger.Log("Down Arrow -> decrease speed");

        }
        public override void OnLevelWasInitialized(int level)
        {
            didInit = false;
        }

        public override void OnLevelWasLoaded(int level)
        {
            localplayer = Player.prop_Player_0;
            try
            {
                jump  = localplayer.gameObject.GetComponent<PlayerModComponentJump>( );
                speed = localplayer.gameObject.GetComponent<PlayerModComponentSpeed>();
                if (IsNullorEmpty(jump))
                {
                    jump = localplayer.gameObject.AddComponent<PlayerModComponentJump>();
                }
                if (IsNullorEmpty(speed))
                {
                    speed = localplayer.gameObject.AddComponent<PlayerModComponentSpeed>();
                }
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("A Error Has Occured In Initiation \n" + e.ToString());
            }
        }

        public override void OnUpdate()
        {
            if (didInit) {
                try
                {
                    if (Input.GetKeyDown(KeyCode.PageUp))
                        jump.field_Single_0 += 1;
                    if (Input.GetKeyDown(KeyCode.PageDown))
                        jump.field_Single_0 -= 1;
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        speed.field_Single_0 += 1;
                        speed.field_Single_1 += 1;
                        speed.field_Single_2 += 1;
                        speed.field_Single_3 += 1;
                        speed.field_Single_4 += 1;
                        speed.field_Single_5 += 1;
                    }
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        speed.field_Single_0 -= 1;
                        speed.field_Single_1 -= 1;
                        speed.field_Single_2 -= 1;
                        speed.field_Single_3 -= 1;
                        speed.field_Single_4 -= 1;
                        speed.field_Single_5 -= 1;
                    }
                }
                catch (Exception e)
                {
                    MelonModLogger.LogError("A Error Has Occured On Update \n" + e.ToString());
                }
            }
                
        }

        public bool IsNullorEmpty<T>(T val)
        {
            bool toret = false;
            if (val.ToString() == "")
                toret = true;
            if (val == null)
                toret = true;
            return toret;
        }
    }
}
