using HelloApi.Models;
using HelloApi.Models.Dtos;
using HelloApi.Repositories;

namespace HelloApi.Services
{
    //un servicio sirve para validaciones y manipulacion de datos
    //sirve como capa intermedia entre el controlador y el repositorio usando dtos
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }
        //pide un mensaje
        //devuelve un dto
        //crear un mensaje
        public async Task<MessageReadDto> CreateMessageAsync(string message)
        {
            var entity = await _repository.AddMessageAsync(message);
            return MapToReadDto(entity);
        }
        // aqui no pide
        // devuelve una lista
        // lista de mensajes
        public async Task<IEnumerable<MessageReadDto>> GetAllMessagesAsync()
        {
            var entities = await _repository.GetAllMessagesAsync();
            return entities.Select(MapToReadDto);
        }
        //pide un id
        //devuelve un dto 
        public async Task<MessageReadDto?> GetMessageByIdAsync(int id)
        {
            var entity = await _repository.GetMessageByIdAsync(id);
            return entity == null ? null : MapToReadDto(entity);
        }
        //pide un id y un mensaje
        //devuelve un dto
        //actualiza un mensaje
        public async Task<MessageReadDto?> UpdateMessageAsync(int id, string message)
        {
            var entity = new Message
            {
                Id = id,
                MessageText = message
            };

            var updated = await _repository.UpdateMessageAsync(entity);
            return updated == null ? null : MapToReadDto(updated);
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            return await _repository.DeleteMessageAsync(id);
        }

        //Para responder al controlador usamos un dto
        //transforma una entidad a un dto
        private static MessageReadDto MapToReadDto(Message message) => new()
        {
            Id = message.Id,
            Message = message.MessageText,
        };
    }
}
