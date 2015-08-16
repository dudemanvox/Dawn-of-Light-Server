using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DOL.GS.PacketHandler;

namespace DOL.GS.Commands
{
    class SudoCommandHandler
    {
        [CmdAttribute(
        "&sudo",
        ePrivLevel.Player,
        "Sudoer accounts may use GM commands",
        "/sudo <command>")]
        public class VersionCommandHandler : AbstractCommandHandler, ICommandHandler
        {
            public void OnCommand(GameClient client, string[] args)
            {
                AssemblyName an = Assembly.GetAssembly(typeof(GameServer)).GetName();
                client.Out.SendMessage("Sudo Command Stub" + an.Version, eChatType.CT_System, eChatLoc.CL_SystemWindow);
            }
        }
    }
}
