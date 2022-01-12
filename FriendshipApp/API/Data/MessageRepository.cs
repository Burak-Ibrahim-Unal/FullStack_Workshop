using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MessageRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<PagedList<MessageDto>> GetAllMessagesForUser(MessageParams messageParams)
        {
            var query = _context.Messages.OrderByDescending(message => message.DateSend).AsQueryable();

            query = messageParams.Container switch
            {
                "Inbox" => query.Where(user => user.RecipientUsername == messageParams.Username),
                "Outbox" => query.Where(user => user.SenderUsername == messageParams.Username),
                _ => query.Where(user => user.RecipientUsername == messageParams.Username && user.DateRead == null)
            };

            var messages = query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider);

            return await PagedList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.pageSize);


        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername)
        {
            var messages = await _context.Messages
                .Include(user => user.Sender).ThenInclude(photo => photo.Photos)
                .Include(user => user.Recipient).ThenInclude(photo => photo.Photos)
                .Where(message =>
                       message.Recipient.UserName == currentUsername
                    && message.Sender.UserName == recipientUsername
                    ||
                        message.Recipient.UserName == recipientUsername
                    && message.Sender.UserName == currentUsername

                )
                .OrderBy(message => message.DateSend)
                .ToListAsync();

            // var unreadMessages = _context.Messages
            //     .Where(message =>
            //            message.DateRead == null
            //         && message.Recipient.UserName == currentUsername)
            //     .ToList();

            var unreadMessages = messages.Where(message => 
                message.DateRead == null && message.RecipientUsername == currentUsername).ToList();


            if (unreadMessages.Any())
            {
                foreach (var message in unreadMessages)
                {
                    message.DateRead = DateTime.Now;
                }

                await _context.SaveChangesAsync();
            }

            return _mapper.Map<IEnumerable<MessageDto>>(messages);


        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}