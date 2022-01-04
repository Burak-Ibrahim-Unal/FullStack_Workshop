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
        private readonly IMapper _imapper;

        public MessageRepository(DataContext context, IMapper imapper)
        {
            _imapper = imapper;
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

            var messages = query.ProjectTo<MessageDto>(_imapper.ConfigurationProvider);

            return await PagedList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.pageSize);


        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public Task<IEnumerable<MessageDto>> GetMessageThread(int currentUserId, int recipientId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}