using System;
using System.Threading.Tasks;
using Application.Core.Utilities;
using Application.Features.Comments.Commands;
using Application.Features.Comments.Queries;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;
        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;

        }


        public async Task SendComment(CreateCommentCommand.Command command)
        {
            var comment = await _mediator.Send(command);

            await Clients.Group(command.ActivityId.ToString())
                .SendAsync(Messages.ReceivedMessage, comment.Value);

        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var activityId = httpContext.Request.Query["activityId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, activityId);
            var result = await _mediator.Send(new GetCommentListQuery.Query { ActivityId = Guid.Parse(activityId) });
            await Clients.Caller.SendAsync(Messages.CommentsLoaded, result.Value);
            


        }

    }
}