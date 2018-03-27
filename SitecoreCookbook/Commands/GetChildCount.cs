using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Commands
{
    /// <summary>
    /// Class for 'command' to get list of children
    /// </summary>
    public class GetChildCount : Command
    {
        public override void Execute(CommandContext context)
        {
            if (context.Items.Length==1)
            {
                
                SheerResponse.Alert(string.Format("Child count - {0}", context.Items[0].Children.Count));
            }
        }

        public override CommandState QueryState(CommandContext context)
        {
            if (context.Items.Length == 1)
            {
                if (context.Items[0].Children.Count==0)
                {
                    return CommandState.Hidden;
                }
            }
            return base.QueryState(context);
        }
    }
}