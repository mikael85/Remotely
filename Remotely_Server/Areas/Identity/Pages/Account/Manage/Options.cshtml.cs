using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Remotely_Shared.Models;
using Remotely_Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Remotely_Server.Areas.Identity.Pages.Account.Manage
{
    public class OptionsModel : PageModel
    {
        public OptionsModel(DataService dataService)
        {
            this.DataService = dataService;
        }
        private DataService DataService { get; set; }

        [TempData]
        public string Message { get; set; }

        public RemotelyUserOptions Options { get; set; }

        public void OnGet()
        {
            Options = DataService.GetUserOptions(User.Identity.Name);
        }

        public IActionResult OnPost(Remotely_Shared.Models.RemotelyUserOptions options)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!options.CommandModeShortcutBash.StartsWith("/"))
            {
                options.CommandModeShortcutBash = "/" + options.CommandModeShortcutBash;
            }
            if (!options.CommandModeShortcutCMD.StartsWith("/"))
            {
                options.CommandModeShortcutCMD = "/" + options.CommandModeShortcutCMD;
            }
            if (!options.CommandModeShortcutPSCore.StartsWith("/"))
            {
                options.CommandModeShortcutPSCore = "/" + options.CommandModeShortcutPSCore;
            }
            if (!options.CommandModeShortcutWeb.StartsWith("/"))
            {
                options.CommandModeShortcutWeb = "/" + options.CommandModeShortcutWeb;
            }
            if (!options.CommandModeShortcutWinPS.StartsWith("/"))
            {
                options.CommandModeShortcutWinPS = "/" + options.CommandModeShortcutWinPS;
            }
            DataService.UpdateUserOptions(User.Identity.Name, options);
            Message = "Saved successfully.";
            return RedirectToPage();
        }
    }
}