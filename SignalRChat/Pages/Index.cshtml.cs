using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace SignalRChat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHubContext<ChatHub> _chatHub;

        public IndexModel(ILogger<IndexModel> logger, IHubContext<ChatHub> chatHub)
        {
            _logger = logger;
            _chatHub = chatHub;
        }

        public async void OnGet()
        {
            await _chatHub.Clients.All.SendAsync("ReceiveMessage", "One", "Hello from Index Page");
        }
    }
}