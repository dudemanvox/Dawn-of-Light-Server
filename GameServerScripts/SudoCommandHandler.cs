using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DOL.GS.PacketHandler;

namespace DOL.GS.Commands
{
    [CmdAttribute(
        "&sudo",
        ePrivLevel.Player,
        "Sudoer accounts may use GM commands.",
        "/sudo player - Lists available player commands.",
        "/sudo speed <number> - Sets player's run speed.")]
    public class SudoCommandHandler : AbstractCommandHandler, ICommandHandler
    {

        public void OnCommand(GameClient client, string[] args)
        {
            if (client.Account.IsSudo)
            {
                if (args.Length == 1)
                {
                    DisplaySyntax(client);
                    return;
                }

                client.Account.PrivLevel = 2;

                switch (args[1])
                {
                    case "player":
                        {
                            List<string> tmp = new List<string>(args);
                            tmp.RemoveAt(0);
                            string[] newArgs = tmp.ToArray();
                            PlayerCommandHandler sudoPlayer = new PlayerCommandHandler();
                            sudoPlayer.OnCommand(client, newArgs);
                            client.Account.PrivLevel = 1;
                        }
                        break;

                    case "heal":
                        {
                            List<string> tmp = new List<string>(args);
                            tmp.RemoveAt(0);
                            string[] newArgs = tmp.ToArray();
                            HealCommandHandler sudoPlayer = new HealCommandHandler();
                            sudoPlayer.OnCommand(client, newArgs);
                            client.Account.PrivLevel = 1;
                        }
                        break;

                    case "speed":
                        {
                            List<string> tmp = new List<string>(args);
                            tmp.RemoveAt(0);
                            string[] newArgs = tmp.ToArray();
                            SpeedCommandHandler sudoPlayer = new SpeedCommandHandler();
                            sudoPlayer.OnCommand(client, newArgs);
                            client.Account.PrivLevel = 1;
                        }
                        break;

                    case "jump":
                        {
                            List<string> tmp = new List<string>(args);
                            tmp.RemoveAt(0);
                            string[] newArgs = tmp.ToArray();
                            JumpCommandHandler sudoPlayer = new JumpCommandHandler();
                            sudoPlayer.OnCommand(client, newArgs);
                            client.Account.PrivLevel = 1;
                        }
                        break;
                }
            }

            else
                {
                    client.Out.SendMessage("Command /sudo does not exist.", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                }
        }
    }
}