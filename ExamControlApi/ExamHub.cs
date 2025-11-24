using Microsoft.AspNetCore.SignalR;

namespace ExamControlApi
{
    public class ExamHub : Hub
    {
        public async Task EndExam()
        {
            await Clients.All.SendAsync("ExamEnded");
        }
    }

}
