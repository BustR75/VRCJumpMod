using System;
using UnityEngine;
using MelonLoader;
using VRC;
[assembly: MelonModInfo(typeof(Jump_Mod.JumpMod), "JumpMod", "1.0", "BustR75")]
[assembly: MelonModGame("VRChat", "VRChat")]
namespace Jump_Mod
{
    public static class BuildInfo
    {
        public const string Name = "JumpMod"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "BustR75"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://github.com/BustR75/VRCJumpMod"; // Download Link for the Mod.  (Set as null if none)
    }

    public class JumpMod : MelonMod {
        PlayerModComponentJump jump;
        Player localplayer = null;
        public override void OnApplicationStart()
        {
            MelonModLogger.Log("initial load");
            MelonModLogger.Log("<Controls>");
            MelonModLogger.Log("Page Up -> increase jump");
            MelonModLogger.Log("Page Down -> decrease jump");

        }

        public override void OnLevelWasLoaded(int level)
        {
            localplayer = Player.prop_Player_0;
            try
            {
                if (localplayer != null)
                {
                    jump = localplayer.gameObject.GetComponent<PlayerModComponentJump>();
                    if (jump == null)
                    {
                        jump = localplayer.gameObject.AddComponent<PlayerModComponentJump>();
                    }
                }
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("A Error Has Occured In Initialization \n" + e.ToString());
            }
        }   

        public override void OnUpdate()
        {
                try
                {
                    if (Input.GetKeyDown(KeyCode.PageUp))
                    {
                        CheckforNull();
                        jump.field_Single_0 += 1;
                        MelonModLogger.Log("Increased Jump to " + jump.field_Single_0);
                    }
                    if (Input.GetKeyDown(KeyCode.PageDown))
                    {
                        CheckforNull();
                        jump.field_Single_0 -= 1;
                        MelonModLogger.Log("Decreased Jump to " + jump.field_Single_0);
                    }
                }
                catch (Exception e)
                {
                    MelonModLogger.LogError("A Error Has Occured On Update \n" + e.ToString());
                }
            
               
        }
        private void CheckforNull()
        {
            if (jump == null)
            {
                localplayer = Player.prop_Player_0;
                jump = localplayer.gameObject.GetComponent<PlayerModComponentJump>();
                if (jump == null)
                {
                    jump = localplayer.gameObject.AddComponent<PlayerModComponentJump>();
                }
            }
        }
    }
}
