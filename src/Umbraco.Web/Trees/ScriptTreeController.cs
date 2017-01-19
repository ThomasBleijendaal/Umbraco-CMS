﻿using Umbraco.Core;
using Umbraco.Core.IO;
using umbraco.BusinessLogic.Actions;
using Umbraco.Web.Models.Trees;
using System.Net.Http.Formatting;
using Umbraco.Core.Services;

namespace Umbraco.Web.Trees
{
    [Tree(Constants.Applications.Settings, "scripts", "Scripts", sortOrder: 4)]
    public class ScriptTreeController : FileSystemTreeController
    {
        protected override string FilePath
        {
            get { return SystemDirectories.Scripts; }
        }

        protected override string FileSearchPattern
        {
            get { return "*.js"; }
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();

            if (id == Constants.System.Root.ToInvariantString())
            {

                //refresh action
                menu.Items.Add<RefreshNode, ActionRefresh>(Services.TextService.Localize(string.Format("actions/{0}", ActionRefresh.Instance.Alias)), true);

                return menu;
            }

            // TODO: Wire up new delete dialog
            menu.Items.Add<ActionDelete>(Services.TextService.Localize(string.Format("actions/{0}", ActionDelete.Instance.Alias)));
            return menu;
        }

        protected override void OnRenderFileNode(ref TreeNode treeNode)
        {
            base.OnRenderFileNode(ref treeNode);
        }
    }
}
